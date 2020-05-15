using System;
using NUnit.Framework;

namespace Matrixing.Tests
{
    [TestFixture]
    [TestOf(typeof(StrassenMultiply))]
    public class StrassenTest
    {
        private const int DEFAULT_LENGTH = 50;
        private static readonly Random _random = new Random();
        
        [Test, Description("Ds t ytntcm ghjdthznm tnj")]
        public void Test()
        {
            var left = new Matrix(DEFAULT_LENGTH, DEFAULT_LENGTH);
            var right = new Matrix(DEFAULT_LENGTH, DEFAULT_LENGTH);

            Console.WriteLine("Созданы матрицы");
            for (var i = 0; i < DEFAULT_LENGTH; i++)
            {
                for (var j = 0; j < DEFAULT_LENGTH; j++)
                {
                    left[i, j] = _random.NextDouble();
                    right[i, j] = _random.NextDouble();
                }
            }

            Console.WriteLine("Заполнены матрицы");
            var expected = new DefaultMultiply().Multiply(left, right);
            Console.WriteLine("Первый способ is done");
            var got = new StrassenMultiply().Multiply(left, right);
            Console.WriteLine("Второй способ готов");

            for (var i = 0; i < DEFAULT_LENGTH; i++)
                for (var j = 0; j < DEFAULT_LENGTH; j++)
                    Assert.AreEqual(expected[i, j], got[i, j]);
        }
    }
}
