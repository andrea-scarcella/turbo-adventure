using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reactive.Linq;
using System.Linq;
using System.Collections.Generic;

namespace Chapter12_LinqToRxTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void LinqToRx_SequenceEnumeration_LambdaGetsCalledForEachGeneratedSequenceElement()
        {
            var observable = Observable.Range(0, 10);
            int count = 0;
            observable.Subscribe(x => { count++; Console.WriteLine(x); });
            Assert.AreEqual(10, count);
        }
        [TestMethod]
        public void LinqToRx_GroupBy_EnumeratesValuesAndThenGroups()
        {
            // Arrange
            int count = 10;
            var observable = Observable.Range(0, count);
            var orderedSequence = Enumerable.Range(0, count);
            var orderedList = new List<int>();
            // Act
            observable.GroupBy(el => new { Odd = el % 2 == 1 }).Subscribe(x => x.Subscribe(orderedList.Add));
            // Assert
            Assert.AreEqual(count, orderedSequence.Zip(Enumerable.Range(0, count), (a, b) => new { AreEqual = a == b }).TakeWhile(el => el.AreEqual).Count());
            Assert.AreEqual(true, Enumerable.SequenceEqual(orderedSequence, orderedList));
        }
    }
}
