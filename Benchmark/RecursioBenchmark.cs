using BenchmarkDotNet.Attributes;
using Recursio;

namespace Benchmark
{
    public class RecursioBenchmark
    {
        private Determinant Determinant;

        private double[,] Matrix;

        [Params(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11)]
        public uint Amount;

        [GlobalSetup]
        public void Setup()
        {
            Matrix = Generator.GenerateMatrix(Amount);
            Determinant = new Determinant();
        }

        [IterationSetup]
        public void Reset() => Determinant.ResetCounter();

        [Benchmark]
        public void Determinantio()
        {
            Determinant.GetDeterminant(Matrix);
            System.Console.WriteLine(Determinant.CallsAmount);
        }
    }
}
