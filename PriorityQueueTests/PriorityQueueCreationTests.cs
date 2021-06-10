using ComplexDataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace PriorityQueueTests
{
    [TestClass]
    public class PriorityQueueCreationTests
    {
        private readonly Random _r = new Random();
        [TestMethod]
        public void BuildMaxHeapSmallListTest()
        {
            var list = new List<int>() {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            var maxHeap = PriorityQueue<int>.BuildMaxPriorityQueue(list);
            Assert.AreEqual(maxHeap.Peek(), 10);
        }

        [TestMethod]
        public void BuildMinHeapSmallListTest()
        {
            var list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            list.Reverse();
            var minHeap = PriorityQueue<int>.BuildMinPriorityQueue(list);
            Assert.AreEqual(minHeap.Peek(), 1);
        }

        [TestMethod]
        public void BuildMaxHeapBigListTest()
        {
            var list = new List<int>();
            for (var i = -2000000; i <= 1000000; i++)
            {
                list.Add(i);
            }
            Shuffle(list);
            var maxHeap = PriorityQueue<int>.BuildMaxPriorityQueue(list);
            Assert.AreEqual(maxHeap.Peek(), 1000000);
        }

        [TestMethod]
        public void BuildMinHeapBigListTest()
        {
            var list = new List<int>();
            for (var i = -2000000; i <= 1000000; i++)
            {
                list.Add(i);
            }
            Shuffle(list);
            var minHeap = PriorityQueue<int>.BuildMinPriorityQueue(list);
            Assert.AreEqual(minHeap.Peek(), -2000000);
        }

        [TestMethod]
        public void BuildEmptyMinHeapTest()
        {
            var minHeap = PriorityQueue<int>.BuildMinPriorityQueue(new List<int>());
            Assert.ThrowsException<Exception>(() => minHeap.Peek());
            Assert.ThrowsException<Exception>(() => minHeap.Dequeue());
            minHeap.Enqueue(1);
            minHeap.Enqueue(2);
            Assert.AreEqual(2, minHeap.Count);
            Assert.AreEqual(minHeap.Dequeue(), 1);
            Assert.AreEqual(minHeap.Peek(), 2);
        }

        [TestMethod]
        public void BuildEmptyMaxHeapTest()
        {
            var maxHeap = PriorityQueue<int>.BuildMaxPriorityQueue(new List<int>());
            Assert.ThrowsException<Exception>(() => maxHeap.Peek());
            Assert.ThrowsException<Exception>(() => maxHeap.Dequeue());
            maxHeap.Enqueue(1);
            maxHeap.Enqueue(2);
            Assert.AreEqual(2, maxHeap.Count);
            Assert.AreEqual(maxHeap.Dequeue(), 2);
            Assert.AreEqual(maxHeap.Peek(), 1);
        }

        private void Shuffle(List<int> list)
        {
            var count = list.Count;
            while (count > 1)
            {
                count--;
                var randomIndex = _r.Next(count);
                var temp = list[count];
                list[count] = list[randomIndex];
                list[randomIndex] = temp;
            }
        }
    }
}
