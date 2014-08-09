using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chapter12;
using System.Linq;
namespace Chapter12Tests
{
    [TestClass]
    public class FakeQueryProviderTests
    {
        [TestMethod]
        public void FakeQueryShouldReturnEmptyCollection()
        {
            //new FakeQuery<string>()
            var query = from x in new FakeQuery<string>()
                        where x.StartsWith("Abc")
                        select x.Length;
            Assert.AreEqual(0, query.Count());
        }
    }
}
