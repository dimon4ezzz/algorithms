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
            var expected = new SortedSet<uint> { 1 };

            uint number = 1;
            var got = Primer.GetPrimes(number);

            Assert.AreEqual(expected, got);
        }

        [Test, Description("Тестирование некоторого заведомо простого числа")]
        public void PrimeTest()
        {
            var expected = new SortedSet<uint> { 1, 41 };

            uint number = 41;
            var got = Primer.GetPrimes(number);

            Assert.AreEqual(expected, got);
        }

        [Test, Description("Тестирование не простого числа, у которого много простых множителей")]
        public void ComplexTest()
        {
            var expected = new SortedSet<uint> { 1, 2, 3, 5, 7, 11 };

            uint number = 2310;
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
