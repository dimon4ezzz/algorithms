using System;

namespace Benchmark
{
    public static class Generator
    {
        public static double[,] GenerateMatrix(uint amount)
        {
            var matrix = new double[amount, amount];
            var rand = new Random();

            for (uint i = 0; i < amount; i++)
                for (uint j = 0; j < amount; j++)
                    matrix[i, j] = rand.Next(9_999) * rand.NextDouble();

            return matrix;
        }
    }
}