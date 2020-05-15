using System;
using NUnit.Framework;

namespace Matrixing.Tests
{
    [TestFixture]
    [TestOf(typeof(Matrix))]
    public class MatrixTest
    {
        private static readonly Random _random = new Random();
        
        // TODO test of RowsCount

        // TODO test of ColumnsCount

        // TODO test of this[,]

        // TODO tests of wrong new Matrix(int, int)

        // TODO tests of wrong new Matrix(double[,])

        // TODO tests of sum

        // TODO tests of minus

        // TODO test of AreSame

        [Test, Description("Тестирование увеличения матрицы")]
        [TestCase(2, 2, 1, 1, 1, 2)]
        [TestCase(3, 2, 1, 1, 1, 4)]
        [TestCase(6, 2, 1, 1, 1, 6)]
        public void TestEnlarging(int rows, int columns, int testIndexI, int testIndexJ, int testNumber, int expectedSize)
        {
            var matrix = new Matrix(rows, columns);
            matrix[testIndexI, testIndexJ] = testNumber;
            matrix.MakeSquareAndEven();
            
            Assert.AreEqual(expectedSize, matrix.RowsCount);
            Assert.AreEqual(expectedSize, matrix.ColumnsCount);
            Assert.AreEqual(testNumber, matrix[testIndexI, testIndexJ]);
        }

        [Test, Description("Тестирование получения части матрицы")]
        [TestCase(4, 4)]
        public void TestFirstQuarterMatrix(int rows, int columns)
        {
            var half = rows / 2;
            var matrix = new Matrix(rows, columns);
            for (var i = 0; i < rows; i++)
                for (var j = 0; j < columns; j++)
                    matrix[i, j] = _random.NextDouble();

            var quarter = matrix.GetHalfMatrix(0);
            for (var i = 0; i < quarter.RowsCount; i++)
                for (var j = 0; j < quarter.ColumnsCount; j++)
                    Assert.AreEqual(matrix[i, j], quarter[i, j]);
        }

        [Test, Description("Тестирование получения части матрицы")]
        [TestCase(4, 4)]
        public void TestSecondQuarterMatrix(int rows, int columns)
        {
            var half = rows / 2;
            var matrix = new Matrix(rows, columns);
            for (var i = 0; i < rows; i++)
                for (var j = 0; j < columns; j++)
                    matrix[i, j] = _random.NextDouble();

            var quarter = matrix.GetHalfMatrix(1);
            for (var i = 0; i < quarter.RowsCount; i++)
                for (var j = 0; j < quarter.ColumnsCount; j++)
                    Assert.AreEqual(matrix[i + half, j], quarter[i, j]);
        }

        [Test, Description("Тестирование получения части матрицы")]
        [TestCase(4, 4)]
        public void TestThirdQuarterMatrix(int rows, int columns)
        {
            var half = rows / 2;
            var matrix = new Matrix(rows, columns);
            for (var i = 0; i < rows; i++)
                for (var j = 0; j < columns; j++)
                    matrix[i, j] = _random.NextDouble();

            var quarter = matrix.GetHalfMatrix(2);
            for (var i = 0; i < quarter.RowsCount; i++)
                for (var j = 0; j < quarter.ColumnsCount; j++)
                    Assert.AreEqual(matrix[i, j + half], quarter[i, j]);
        }

        [Test, Description("Тестирование получения части матрицы")]
        [TestCase(4, 4)]
        public void TestFourthQuarterMatrix(int rows, int columns)
        {
            var half = rows / 2;
            var matrix = new Matrix(rows, columns);
            for (var i = 0; i < rows; i++)
                for (var j = 0; j < columns; j++)
                    matrix[i, j] = _random.NextDouble();

            var quarter = matrix.GetHalfMatrix(3);
            for (var i = 0; i < quarter.RowsCount; i++)
                for (var j = 0; j < quarter.ColumnsCount; j++)
                    Assert.AreEqual(matrix[i + half, j + half], quarter[i, j]);
        }
    }
}