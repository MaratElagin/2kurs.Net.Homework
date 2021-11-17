using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Xunit;

namespace HW8.Tests
{
    public class HostBuilder : WebApplicationFactory<Startup>
    {
        protected override IHostBuilder CreateHostBuilder() =>
            Host
                .CreateDefaultBuilder()
                .ConfigureWebHostDefaults(a => a
                    .UseStartup<Startup>()
                    .UseTestServer());
    }
    
    public class IntegrationTests : IClassFixture<HostBuilder>
    {
        private const string Path = "https://localhost:5001/Calculator/Calculate";
        private readonly HttpClient _client;
        
        public IntegrationTests(HostBuilder fixture)
        {
            _client = fixture.CreateClient();
        }

        [Theory]
        [InlineData("2", "plus", "59", "61")]
        [InlineData("11", "minus", "17", "-6")]
        [InlineData("3", "divide", "1", "3")]
        [InlineData("2021", "multiply", "4", "8084")]
        public async Task Calculate_ValidArguments_CorrectResult(string v1, string op, string v2, string excepted)
        {
            await MakeGeneralPartTests(v1, op, v2, excepted);
        }
        
        [Theory]
        [InlineData("invalid", "plus", "5", "invalid или 5 не являются числами. Введите числа")]
        [InlineData("5", "minus", "error", "5 или error не являются числами. Введите числа")]
        [InlineData("5", "power", "5", "power - недопустимая операция. Допустимые: plus, minus, multiply или divide")]
        [InlineData("301", "divide", "0", "Деление на 0. Результат не определён")]
        public async Task Calculate_InvalidArguments_ErrorMessage(string v1, string op, string v2, string excepted)
        {
            await MakeGeneralPartTests(v1, op, v2, excepted);
        }

        private async Task MakeGeneralPartTests(string v1, string op, string v2, string excepted)
        {
            var response = await _client.GetAsync($"{Path}?val1={v1}&operation={op}&val2={v2}");
            var result = await response.Content.ReadAsStringAsync();
            Assert.Equal(excepted, result);
        }
    }
}