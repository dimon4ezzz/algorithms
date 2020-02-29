using System;
using NUnit.Framework;

namespace Recursio.Tests
{
    [TestFixture, Description("Тестирование нахождения определителя матрицы")]
    public class DeterminantTest
    {
        private Determinant Determinant;

        [SetUp]
        public void Init()
        {
            Determinant = new Determinant();
        }

        [TearDown]
        public void TearDown()
        {
            Console.WriteLine($"Вызовов: {Determinant.CallsAmount}");
        }

        [Test, Description("Тестирование матрицы 1×1")]
        public void OneNumberTest()
        {
            double expected = 1;
            var matrix = new double[1, 1] { { 1 } };
            var got = Determinant.GetDeterminant(matrix);

            Assert.AreEqual(expected, got);
        }

        [Test, Description("Тестирование матрицы 2×2")]
        public void TwoDimensionalTest()
        {
            double expected = -2;
            var matrix = new double[2, 2] { { 1, 2 }, { 3, 4 } };
            var got = Determinant.GetDeterminant(matrix);

            Assert.AreEqual(expected, got);
        }

        [Test, Description("Тестирование матрицы 3×3")]
        public void ThreeDimensionalTest()
        {
            double expected = -6.0;
            var matrix = new double[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 7, 9 } };
            var got = Determinant.GetDeterminant(matrix);

            Assert.AreEqual(expected, got);
        }

        [Test, Description("Тестирование дробных чисел в матрице 3×3")]
        public void NonIntegerInputTest()
        {
            double expected = 247.672;
            double delta = 1E-3;
            var matrix = new double[3, 3] { { 2.5, 7.1, -1.2 }, { -0.1, 9.9, 1.0 }, { 8.6, 4.1, 3.7 } };
            var got = Determinant.GetDeterminant(matrix);

            Assert.AreEqual(expected, got, delta);
        }

        [Test, Description("Тестирование пустой матрицы на вход")]
        public void EmptyMatrixTest()
        {
            var matrix = new double[0,0];
            Assert.Throws<ArgumentException>(() => Determinant.GetDeterminant(matrix));
        }

        [Test, Description("Тестирование прямоугольной матрицы на вход")]
        public void NonSquareMatrixTest()
        {
            var matrix = new double[1, 2];
            Assert.Throws<ArgumentException>(() => Determinant.GetDeterminant(matrix));
        }
    }
}