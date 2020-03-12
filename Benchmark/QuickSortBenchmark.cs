using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using Sorting;

namespace Benchmark
{
    public class QuickSortBenchmark
    {
        public QuickSort QuickSort;

        [Params(10, 100, 1000, 2000, 3000)]
        public uint Amount;

        public List<double> List;

        [GlobalSetup]
        public void Setup()
        {
            QuickSort = new QuickSort();
            List = Generator.GetRandomList(Amount);
        }

        [IterationSetup]
        public void Reset() => QuickSort.ResetCounter();

        [Benchmark]
        public void SortBenchmark()
        {
            QuickSort.Sort(List);
        }
    }
}
