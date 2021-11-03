using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using HW6;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Xunit;

namespace Tests
{
    public class HostBuilder : WebApplicationFactory<App.Startup>
    {
        protected override IHostBuilder CreateHostBuilder()
            => Host
                .CreateDefaultBuilder()
                .ConfigureWebHostDefaults(a => a
                    .UseStartup<App.Startup>()
                    .UseTestServer());
    }

    public class IntegrationTests : IClassFixture<HostBuilder>
    {
        private readonly HttpClient _client;

        public IntegrationTests(HostBuilder fixture)
        {
            _client = fixture.CreateClient();
        }

        private const string Localhost = "http://localhost:5000";

        [Theory]
        [InlineData("20", "plus", "13", "33")]
        [InlineData("5", "minus", "3.5", "1.5")]
        [InlineData("9", "divide", "8", "1.125")]
        [InlineData("-4", "multiply", "51.5", "-206.0")]
        public async Task TestCalculate_CorrectInput(string v1, string op, string v2, string expected)
        {
            await RunTest(v1, op, v2, expected);
        }

        [Theory]
        [InlineData("32", "the", "2", "Could not parse value 'the' to type HW6.Operation+Operation.")]
        [InlineData("ee", "plus", "5.9", "Could not parse value 'ee' to type System.Decimal.")]
        [InlineData("13", "plus", "haha", "Could not parse value 'haha' to type System.Decimal.")]
        [InlineData("131", "divide", "0", "Division by zero")]
        [InlineData("96.116", "divide", "0", "Division by zero")]
        public async Task TestCalculate_WrongInput(string v1, string op, string v2, string expected)
        {
            await RunTest(v1, op, v2, expected);
        }
        
        [Fact]
        public async Task TestNonExistentPage()
        {
            var response = await _client.GetAsync($"http://localhost:5000/c");
            var result = await response.Content.ReadAsStringAsync();
            Assert.Equal("Not Found", result);
        }
        
        private async Task RunTest(string v1, string op, string v2, string expected)
        {
            CultureInfo.CurrentCulture = new CultureInfo("en-us");
            var response = await _client.GetAsync($"{Localhost}/calculate?v1={v1}&operation={op}&v2={v2}");
            var result = await response.Content.ReadAsStringAsync();
            Assert.Equal(expected, result);
        }
    }
}