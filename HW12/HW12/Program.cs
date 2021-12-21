using BenchmarkDotNet.Running;
using hw12;

namespace HW12
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<SpeedTests>();
        }
    }
}