using System.Collections.Generic;
using System.Net.Http;
using HW10;
using JetBrains.dotMemoryUnit;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Xunit;
using Xunit.Abstractions;


namespace HW13.Tests
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

    public class IntegrationTests : IClassFixture<HostBuilder>
    {
        private readonly HostBuilder _factory;
        private ITestOutputHelper _output;

        public IntegrationTests(HostBuilder factory, ITestOutputHelper output)
        {
            _output = output;
            DotMemoryUnitTestOutput.SetOutputMethod(output.WriteLine);
            _factory = factory;
        }

        [DotMemoryUnit(FailIfRunWithoutSupport = false, CollectAllocations = true)]
        [Theory]
        [MemberData(nameof(GenerateData))]
        public void CalculatorController_ReturnCorrectResult(string op)
            => MakeTestAsync(op);

        private void MakeTestAsync(string expression)
        {
            var client = _factory.CreateClient();
            var memoryBefore = dotMemory.Check();

            client
                .PostAsync("/Calculator/Calculate", new StringContent("expression=" + expression))
                .GetAwaiter()
                .GetResult();
            
            dotMemory.Check(memory =>
            {
                _output.WriteLine(memory.GetTrafficFrom(memoryBefore).CollectedMemory.SizeInBytes.ToString());
                Assert.True(
                    memory
                        .GetTrafficFrom(memoryBefore)
                        .Where(a => a.Type == typeof(string))
                        .AllocatedMemory.SizeInBytes < 2000000);
            });
        }

        public static IEnumerable<object[]> GenerateData()
        {
            for (var i = 0; i < 100; i++)
            {
                yield return new object[] {i + "Plus" + i};
            }
        }
    }
}