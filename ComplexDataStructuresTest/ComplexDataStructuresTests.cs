using System;
using ComplexDataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComplexDataStructuresTest
{
    [TestClass]
    public class ComplexDataStructuresTests
    {
        [TestMethod]
        public void TestMinHeap()
        {
            MinHeap<int> minHeap = new MinHeap<int>(20);
            int[] a = { 1, 2, 3, 4, 5, 6, 17, 18, 19, 28, 37, 66, 55, 44, 33, 22, 11, -1, -2, -7, 3, -4, -5, -6 };
            //int[] a = { 1, 2, 3 };
            //foreach (int num in a)
            //{
            //    minHeap.Add(num);
            //}
            for (int i = 0; i < 200; i++)
                minHeap.Add(i);
            Assert.AreEqual(minHeap.Min, 0);
            Assert.AreEqual(minHeap.ExtractMin(), 0);
            Assert.AreEqual(minHeap.Min, 1);

        }

        [TestMethod]
        public void TestMaxHeap()
        {
            MaxHeap<int> maxHeap = new MaxHeap<int>(3);
            int[] a = { 1, 2, 3, 4, 5, 6, 17, 18, 19, 28, 37, 66, 55, 44, 33, 22, 11, -1, -2, -7, 3, -4, -5, -6 };
            //int[] a = { 1, 2, 3 };
            //foreach (int num in a)
            //{
            //    maxHeap.Add(num);
            //}
            for (int i = 0; i < 200; i++)
                maxHeap.Add(i);
            Assert.AreEqual(maxHeap.Max, 199);
            Assert.AreEqual(maxHeap.ExtractMax(), 199);
            Assert.AreEqual(maxHeap.Max, 198);

        }
    }
}
