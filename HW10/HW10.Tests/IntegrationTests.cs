using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using HW10.Services.Database;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Xunit;

namespace HW10.Tests
{
    public class HostBuilder : WebApplicationFactory<Startup>
    {
        protected override IHostBuilder CreateHostBuilder()
            => Host
                .CreateDefaultBuilder()
                .ConfigureWebHostDefaults(a => a
                    .UseStartup<Startup>()
                    .UseTestServer())
                .ConfigureServices(a => a.AddDbContext<ApplicationContext>(options =>
                    options.UseInMemoryDatabase("DBForTests")));
    }

    public class IntegrationCalculatorControllerTests : IClassFixture<HostBuilder>
    {
        private readonly HttpClient _client;
        private readonly string _successString = "Result: ";
        private readonly string _errorString = "Error: ";
        private static readonly Uri Uri = new("https://localhost:5001/Calculator/Calculate");

        public IntegrationCalculatorControllerTests(HostBuilder fixture)
        {
            _client = fixture.CreateClient();
        }

        [Theory]
        [InlineData("21 %2B 43", "64")]
        [InlineData("(13 - 7) / 2", "3")]
        [InlineData("5 - 3 / 2", "3.5")]
        [InlineData("14 * (2 %2B 4) - 3 * 4", "72")]
        [InlineData("0 - 3 * (-4)", "12")]
        public async Task Calculate_CalculateExpression_Success(string expression, string result)
        {
            await MakeTest(expression, result, _successString);
        }

        [Theory]
        [InlineData("", "Empty string")]
        [InlineData("10 + i", "Unknown character i")]
        [InlineData("(201 - 1,2,3) * 7", "Unknown character ,")]
        [InlineData("2 - x - 23", "Unknown character x")]
        [InlineData("2 - 2,23,1 - 23", "Unknown character ,")]
        [InlineData("8 %2B 34 - / 2", "There are two operations in a row: - and /")]
        [InlineData("4 - 10 * (/10 %2B 2)", "After opening parenthesis only minus can be (/")]
        [InlineData("10 - 2 * (10 - 1 /)", "There is only a number before the closing parenthesis /)")]
        public async Task Calculate_CalculateExpression_Error(string expression, string result)
        {
            await MakeTest(expression, result, _errorString);
        }

        private async Task MakeTest(string expression, string result, string successOrError)
        {
            var stringContent = new StringContent($"expression={expression}", Encoding.UTF8);
            stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            var response = await _client.PostAsync("https://localhost:5001/Calculator/Calculate", stringContent);
            var output = await response.Content.ReadAsStringAsync();

            Assert.Equal(successOrError + result, GetResult(output));
        }

        [Fact]
        private async Task CalculatorController_CashedTest()
        {
            var rnd = new Random();
            var operations = new char[] {'+', '-', '*', '/'};
            var randomOperation = operations[rnd.Next(0, 4)];
            var expression = $"{rnd.Next(0, int.MaxValue / 2)} {randomOperation} {rnd.Next(0, int.MaxValue / 2)}";
            var str = $"expression={expression}";
            var stringContent = new StringContent(str, Encoding.UTF8);
            stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

            var timeBefore = await MeasureTime(stringContent);
            var timeAfter = await MeasureTime(stringContent);
            Assert.True(timeBefore - timeAfter > 1000);
        }

        private async Task<long> MeasureTime(HttpContent stringContent)
        {
            var watch = new Stopwatch();
            watch.Start();
            using var response = await _client.PostAsync(Uri, stringContent);
            watch.Stop();
            return watch.ElapsedMilliseconds;
        }

        private string GetResult(string html) =>
            html.Split("<span id=\"response\" class=\"mt-3\">")[1].Split("</span>")[0];
    }
}