using System.Collections.Generic;
using NUnit.Framework;

namespace Extensions.Tests
{
    [TestFixture]
    public class ListExtensionTest
    {
        private IList<double> List;

        [SetUp]
        public void Setup()
        {
            List = new List<double>() { 9, 8 };
        }

        [Test]
        public void TestSwap()
        {
            var expected = new List<double>() { 8, 9 };
            List.Swap(0, 1);
            
            Assert.AreEqual(expected, List);
        }
    }
}