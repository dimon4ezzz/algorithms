using System;
using System.Collections.Generic;

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

        public static List<double> GetRandomList(uint amount)
        {
            var list = new List<double>();
            var random = new Random();

            for (int i = 0; i < amount; i++)
            {
                list.Add(random.Next() * random.NextDouble());
            }

            return list;
        }
    }
}
