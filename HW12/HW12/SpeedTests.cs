using System.Net.Http;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using HW12;
using HW8;


namespace hw12
{
    [MinColumn]
    [MaxColumn]
    public class SpeedTests
    {
        private HttpClient _fSharpClient;
        private HttpClient _cSharpClient;

        private const string FSharpUrl = "https://localhost:5001/calculate";
        private const string CSharpUrl = "https://localhost:5001/calculator/calculate";
        
        [GlobalSetup]
        public void Setup()
        {
            _fSharpClient = new CustomWebApplicationFactory<HW6.App.Startup>().CreateDefaultClient();
            _cSharpClient = new CustomWebApplicationFactory<Startup>().CreateDefaultClient();
        }

        //1+2 
        [Benchmark(Description = "F# 1+2")]
        public async Task OnePlusTwoFSharp() =>
            await _fSharpClient.GetAsync(FSharpUrl + "?v1=1&operation=plus&v2=2");
        
        
        [Benchmark(Description = "C# 1+2")]
        public async Task OnePlusTwoCSharp() =>
            await _cSharpClient.GetAsync(CSharpUrl + "?val1=1&operation=plus&val2=2");
        
        //23-3
        [Benchmark(Description = "F# 23-3")]
        public async Task TwentyThreeMinusThreeFSharp() =>
            await _fSharpClient.GetAsync(FSharpUrl + "?v1=23&operation=minus&v2=3");
        
        [Benchmark(Description = "C# 23-3")]
        public async Task TwentyThreeMinusThreeCSharp() =>
            await _cSharpClient.GetAsync(CSharpUrl + "?val1=23&operation=minus&val2=3");
        
        //2*4
        [Benchmark(Description = "F# 2*4")]
        public async Task TwoMultiplyFourFSharp() =>
            await _fSharpClient.GetAsync(FSharpUrl + "?v1=2&operation=multiply&v2=4");
        
        [Benchmark(Description = "C# 2*4")]
        public async Task TwoMultiplyFourCSharp() =>
            await _cSharpClient.GetAsync(CSharpUrl + "?val1=2&operation=multiply&val2=4");
        
        //10/5
        [Benchmark(Description = "F# 10/5")]
        public async Task TenDivideFiveFSharp() =>
            await _fSharpClient.GetAsync(FSharpUrl + "?v1=10&operation=divide&v2=5");
        
        [Benchmark(Description = "C# 10/5")]
        public async Task TenDivideFiveCSharp() =>
            await _cSharpClient.GetAsync(CSharpUrl + "?val1=10&operation=divide&val2=5");
    }
}