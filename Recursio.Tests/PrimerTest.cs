using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Recursio.Tests
{
    [TestFixture, Description("Тестирование нахождения простых множиетелей числа")]
    public class PrimerTest
    {
        public Primer Primer;

        [SetUp]
        public void Init()
        {
            Primer = new Primer();
        }

        [TearDown]
        public void TearDown()
        {
            Console.WriteLine($"Вызовов: {Primer.CallsAmount}");
        }

        [Test, Description("Тестирование числа 1")]
        public void OneTest()
        {
            ulong number = 1;
            var got = Primer.GetPrimes(number);

            Assert.AreEqual(0, got.Count);
        }

        [Test, Description("Тестирование некоторого заведомо простого числа")]
        public void PrimeTest()
        {
            var expected = new List<ulong> { 41 };

            ulong number = 41;
            var got = Primer.GetPrimes(number);

            Assert.AreEqual(expected, got);
        }

        [Test, Description("Тестирование не простого числа, у которого много простых множителей")]
        public void ComplexTest()
        {
            var expected = new List<ulong> { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47 };

            ulong number = 614_889_782_588_491_410;
            var got = Primer.GetPrimes(number);

            Assert.AreEqual(expected, got);
        }

        [Test, Description("Тестирование большого количества одинаковых простых множителей")]
        public void LotOfMultipliersTest()
        {
            var expected = new List<ulong> { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2,2, 2, 2, 2, 2, 2, 2 };

            ulong number = 9_223_372_036_854_775_808;
            var got = Primer.GetPrimes(number);

            Assert.AreEqual(expected, got);
        }

        [Test, Description("Тестирование числа 0")]
        public void ZeroTest()
        {
            Assert.Throws<ArgumentException>(() => Primer.GetPrimes(0));
        }
    }
}
