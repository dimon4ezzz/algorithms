using System;
using NUnit.Framework;

namespace Recursio.Tests
{
    [TestFixture]
    public class ExpressionerTest
    {
        public Expressioner Expressioner;

        [SetUp]
        public void Init()
        {
            Expressioner = new Expressioner();
        }

        [TearDown]
        public void TearDown()
        {
            Console.WriteLine($"Вызовов: {Expressioner.CallsAmount}");
        }

        [Test]
        [TestCase(1)]
        [TestCase(0)]
        [TestCase(0.5)]
        [TestCase(-1)]
        [TestCase(100)]
        [TestCase(-100)]
        public void NumericTest(decimal expected)
        {
            var got = Expressioner.Calculate(expected.ToString(), expected);

            Assert.AreEqual(expected, got);
        }

        [Test]
        [TestCase(1)]
        [TestCase(0)]
        [TestCase(0.5)]
        [TestCase(-1)]
        [TestCase(100)]
        [TestCase(-100)]
        public void JustTest(decimal expected)
        {
            var got = Expressioner.Calculate("x", expected);

            Assert.AreEqual(expected, got);
        }

        [Test]
        [TestCase(1, 2, 3)]
        [TestCase(1, 0, 1)]
        [TestCase(-8, 0.5, -7.5)]
        public void TestSum(decimal left, decimal right, decimal expected)
        {
            var _string = $"{left}+{right}";
            var got = Expressioner.Calculate(_string, 0);

            Assert.AreEqual(expected, got);
        }

        [Test]
        [TestCase(3, 2, 1)]
        [TestCase(1, 0, 1)]
        [TestCase(-8, 0.5, -8.5)]
        public void TestMinus(decimal left, decimal right, decimal expected)
        {
            var _string = $"{left}-{right}";
            var got = Expressioner.Calculate(_string, 0);

            Assert.AreEqual(expected, got);
        }

        [Test]
        [TestCase(3, 2, 6)]
        [TestCase(1, 0, 0)]
        [TestCase(-8, 0.5, -4)]
        public void TestMultiply(decimal left, decimal right, decimal expected)
        {
            var _string = $"{left}*{right}";
            var got = Expressioner.Calculate(_string, 0);

            Assert.AreEqual(expected, got);
        }

        [Test]
        [TestCase(6, 2, 3)]
        [TestCase(0, 1, 0)]
        [TestCase(-8, 0.5, -16)]
        public void TestDivide(decimal left, decimal right, decimal expected)
        {
            var _string = $"{left}/{right}";
            var got = Expressioner.Calculate(_string, 0);

            Assert.AreEqual(expected, got);
        }

        [Test]
        [TestCase("-9+7*x*x+12/2*x-1+1*1", 4, 127)]
        public void TestExpression(string _string, decimal input, decimal expected)
        {
            var got = Expressioner.Calculate(_string, input);

            Assert.AreEqual(expected, got);
        }

        [Test]
        public void TestDividedByZero()
        {
            Assert.Throws<DivideByZeroException>(() => Expressioner.Calculate("x/0", 1) );
        }

        [Test]
        public void TestWrongInput()
        {
            Assert.Throws<FormatException>(() => Expressioner.Calculate("z", 1));
        }

        [Test]
        [TestCase(null)]
        [TestCase("  ")]
        [TestCase("\t\n\u2000")]
        public void TestEmpty(string _string)
        {
            Assert.Throws<ArgumentNullException>(() => Expressioner.Calculate(_string, 1));
        }
    }
}