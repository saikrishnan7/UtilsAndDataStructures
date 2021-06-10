using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComplexDataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PriorityQueueTests
{
    [TestClass]
    public class PriorityQueueOperationsTests
    {
        private readonly Random _r = new Random();

        [TestMethod]
        public void DequeueMaxHeapSmallListTest()
        {
            var list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var maxHeap = PriorityQueue<int>.BuildMaxPriorityQueue(list);
            Assert.AreEqual(maxHeap.Dequeue(), 10);
            Assert.AreEqual(maxHeap.Dequeue(), 9);
            Assert.AreEqual(maxHeap.Peek(), 8);
            Assert.AreEqual(maxHeap.Count, 8);
        }

        [TestMethod]
        public void BuildMinHeapSmallListTest()
        {
            var list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            list.Reverse();
            var minHeap = PriorityQueue<int>.BuildMinPriorityQueue(list);
            Assert.AreEqual(minHeap.Dequeue(), 1);
            Assert.AreEqual(minHeap.Dequeue(), 2);
            Assert.AreEqual(minHeap.Peek(), 3);
            Assert.AreEqual(minHeap.Count, 8);
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
            Assert.AreEqual(maxHeap.Dequeue(), 1000000);
            Assert.AreEqual(maxHeap.Dequeue(), 999999);
            Assert.AreEqual(maxHeap.Peek(), 999998);
            Assert.AreEqual(maxHeap.Count, 2999999);
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
            Assert.AreEqual(minHeap.Dequeue(), -2000000);
            Assert.AreEqual(minHeap.Dequeue(), -1999999);
            Assert.AreEqual(minHeap.Peek(), -1999998);
            Assert.AreEqual(minHeap.Count, 2999999);
        }

        [TestMethod]
        public void DequeueMaxHeapSmallListDuplicatesTest()
        {
            var list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 8, 8, 8, 8, 9, 9, 9, 10, 10 };
            var maxHeap = PriorityQueue<int>.BuildMaxPriorityQueue(list);
            Assert.AreEqual(maxHeap.Dequeue(), 10);
            Assert.AreEqual(maxHeap.Dequeue(), 10);
            Assert.AreEqual(maxHeap.Peek(), 9);
            maxHeap.Enqueue(10);
            Assert.AreEqual(maxHeap.Dequeue(), 10);
            Assert.AreEqual(maxHeap.Count, 15);
        }

        [TestMethod]
        public void BuildMinHeapSmallListDuplicatesTest()
        {
            var list = new List<int>() { 1, 1, 2, 3, 3, 3, 4, 5, 6, 7, 8, 8, 8, 8, 8, 9, 9, 9, 10, 10 };
            list.Reverse();
            var minHeap = PriorityQueue<int>.BuildMinPriorityQueue(list);
            Assert.AreEqual(minHeap.Dequeue(), 1);
            Assert.AreEqual(minHeap.Dequeue(), 1);
            Assert.AreEqual(minHeap.Dequeue(), 2);
            minHeap.Enqueue(1);
            Assert.AreEqual(minHeap.Peek(), 1);
            Assert.AreEqual(minHeap.Count, 18);
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
