using System;
using BenchmarkDotNet.Attributes;
using Recursio;

namespace Benchmark
{
    public class PrimerBenchmark
    {
        private Primer Primer;
        private Random Random;

        [GlobalSetup]
        public void Setup()
        {
            Primer = new Primer();
            Random = new Random();
        }

        [IterationSetup]
        public void Reset() => Primer.ResetCounter();

        [Benchmark]
        public void Primerio()
        {
            var number = (ulong) Random.Next();
            Primer.GetPrimes(number);
            Console.WriteLine(Primer.CallsAmount);
        }
    }
}
