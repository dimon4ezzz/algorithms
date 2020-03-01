using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Recursio.Tests
{
    [TestFixture]
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

        [Test]
        public void OneTest()
        {
            var expected = new SortedSet<uint> { 1 };

            uint number = 1;
            var got = Primer.GetPrimes(number);

            Assert.AreEqual(expected, got);
        }

        [Test]
        public void PrimeTest()
        {
            var expected = new SortedSet<uint> { 1, 41 };

            uint number = 41;
            var got = Primer.GetPrimes(number);

            Assert.AreEqual(expected, got);
        }

        [Test]
        public void ComplexTest()
        {
            var expected = new SortedSet<uint> { 1, 2, 3, 5, 7, 11 };

            uint number = 2310;
            var got = Primer.GetPrimes(number);

            Assert.AreEqual(expected, got);
        }

        [Test]
        public void ZeroTest()
        {
            Assert.Throws<ArgumentException>(() => Primer.GetPrimes(0));
        }
    }
}
