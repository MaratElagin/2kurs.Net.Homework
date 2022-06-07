using System;
using BenchmarkDotNet.Running;

namespace HW13
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<MemoryTests>();   
        }
    }
}