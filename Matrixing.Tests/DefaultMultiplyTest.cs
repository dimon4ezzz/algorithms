using NUnit.Framework;

namespace Matrixing.Tests
{
    [TestFixture]
    [TestOf(typeof(DefaultMultiply))]
    public class DefaultMultiplyTest
    {
        [Test, Description("Тестирует обычное умножение матриц")]
        public void Test()
        {
            var left = new Matrix(new double[,]{
                { 1, 2 }, { 3, 4 }
            });
            var right = new Matrix(new double[,]{
                { 3, 1 }, { 4, 2 }
            });

            var expected = new Matrix(new double[,]{
                { 11, 5 }, { 25, 11 }
            });

            var got = new DefaultMultiply().Multiply(left, right);

            for (var i = 0; i < 2; i++)
                for (var j = 0; j < 2; j++)
                    Assert.AreEqual(expected[i,j], got[i,j]);
        }
    }
}