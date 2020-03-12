using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Sorting.Tests
{
    [TestFixture]
    public class QuickSortTest
    {
        private const int DEFAULT_CAPACITY = 1500;

        private QuickSort QuickSort;

        [SetUp]
        public void Setup()
        {
            QuickSort = new QuickSort();
        }

        [TearDown]
        public void TearDown()
        {
            Console.WriteLine($"Вызовов: {QuickSort.CallsAmount}");
        }

        [Test]
        public void TestSort()
        {
            var list = GetRandomList() as List<double>;
            QuickSort.Sort(list);

            for (int i = 1; i < list.Count; i++)
            {
                Assert.IsTrue(list[i] >= list[i - 1]);
            }
        }

        [Test]
        public void TestEmptyList()
        {
            var list = new List<byte>();
            QuickSort.Sort(list);
            
            Assert.AreEqual(QuickSort.CallsAmount, 1);
        }

        [Test]
        public void TestListWithOneItem()
        {
            var list = new List<byte>() {0};
            QuickSort.Sort(list);

            Assert.AreEqual(QuickSort.CallsAmount, 1);
        }

        [Test]
        public void TestWrongStart()
        {
            var list = new List<byte>() { 1, 2 };
            Assert.Throws<ArgumentException>(() => QuickSort.Sort(list, 1, 0));
        }

        [Test]
        public void TestNullList()
        {
            Assert.Throws<ArgumentNullException>(() => QuickSort.Sort(null as List<byte>));
        }

        [Test]
        public void TestNullListOnExtendedFunction()
        {
            Assert.Throws<ArgumentNullException>(() => QuickSort.Sort(null as List<byte>, 0, 1));
        }

        [Test]
        public void TestOutOfRangeStart()
        {
            var list = new List<byte>() { 1, 2 };
            Assert.Throws<ArgumentOutOfRangeException>(() => QuickSort.Sort(list, 2, 3));
        }

        [Test]
        public void TestOutOfRangeEnd()
        {
            var list = new List<byte>() { 1, 2 };
            Assert.Throws<ArgumentOutOfRangeException>(() => QuickSort.Sort(list, 0, 2));
        }

        private IList<double> GetRandomList(uint amount = DEFAULT_CAPACITY)
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
