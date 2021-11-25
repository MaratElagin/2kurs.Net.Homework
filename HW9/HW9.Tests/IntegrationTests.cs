using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Xunit;

namespace HW9.Tests
{
    public class HostBuilder : WebApplicationFactory<Startup>
    {
        protected override IHostBuilder CreateHostBuilder()
            => Host
                .CreateDefaultBuilder()
                .ConfigureWebHostDefaults(a => a
                    .UseStartup<Startup>()
                    .UseTestServer());
    }

    public class IntegrationCalculatorControllerTests : IClassFixture<HostBuilder>
    {
        private readonly HttpClient client;
        private readonly string successString = "Result: ";
        private readonly string errorString = "Error: ";

        public IntegrationCalculatorControllerTests(HostBuilder fixture)
        {
            client = fixture.CreateClient();
        }

        [Theory]
        [InlineData("21 %2B 43", "64")]
        [InlineData("(13 - 7) / 2", "3")]
        [InlineData("5 - 3 / 2", "3.5")]
        [InlineData("14 * (2 %2B 4) - 3 * 4", "72")]
        [InlineData("0 - 3 * (-4)", "12")]
        public async Task Calculate_CalculateExpression_Success(string expression, string result)
        {
            await MakeTest(expression, result, successString);
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
            await MakeTest(expression, result, errorString);
        }

        private async Task MakeTest(string expression, string result, string successOrError)
        {
            var stringContent = new StringContent($"expression={expression}", Encoding.UTF8);
            stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            var response = await client.PostAsync("https://localhost:5001", stringContent);
            var output = await response.Content.ReadAsStringAsync();

            Assert.Equal(successOrError + result, FindResult(output));
        }

        [Theory]
        [InlineData("17 %1B 6 / (-5) * 11 %2B (22 - 14) * 131")]
        private async Task CalculatorController_ParallelTest(string expression)
        {
            var watch = new Stopwatch();
            var stringContent = new StringContent($"expression={expression}", Encoding.UTF8);
            stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            watch.Start();
            var response = await client.PostAsync("https://localhost:5001", stringContent);
            watch.Stop();
            var result = watch.ElapsedMilliseconds;
            Console.WriteLine(result);
            Assert.True(result < 1500);
        }

        private string FindResult(string html)
        {
            return html.Split("<span id=\"response\" class=\"mt-3\">")[1].Split("</span>")[0];
        }
    }
}