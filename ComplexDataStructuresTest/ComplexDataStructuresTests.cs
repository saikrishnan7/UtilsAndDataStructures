using System;
using System.Collections.Generic;
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

        [TestMethod]

        public void TestTrie()
        {
            Trie trie = new Trie();
            trie.Insert("eat");
            Assert.IsTrue(trie.Search("eat"));
            trie.Insert("east");
            Assert.IsTrue(trie.StartsWith("eas"));
        }

        [TestMethod]
        public void TestRandomizedCollection()
        {
            RandomizedCollection rc = new RandomizedCollection();
            rc.Insert(1);
            rc.Insert(1);
            rc.Insert(2);
            rc.Insert(1);
            rc.Insert(2);
            rc.Insert(2);
            rc.Remove(1);
            rc.Remove(2);
            rc.Remove(2);
            rc.Remove(2);
            Assert.IsTrue(rc.GetRandom() == 1);
            Assert.IsTrue(rc.GetRandom() == 1);
            Assert.IsTrue(rc.GetRandom() == 1);
            Assert.IsTrue(rc.GetRandom() == 1);
            Assert.IsTrue(rc.GetRandom() == 1);
            Assert.IsTrue(rc.GetRandom() == 1);
        }

        [TestMethod]
        public void SnakeGameTest()
        {
            SnakeGame sg = new SnakeGame(3, 2, new int[,] { {1, 2}, { 0, 1 } });
            Assert.AreEqual(sg.Move("R"), 0);
            Assert.AreEqual(sg.Move("D"), 0);
            Assert.AreEqual(sg.Move("R"), 1);
            Assert.AreEqual(sg.Move("U"), 1);
            Assert.AreEqual(sg.Move("L"), 2);
            Assert.AreEqual(sg.Move("U"), -1);
        }

        [TestMethod]
        public void TestPoints()
        {
            //SortedList<int, Point> maxHeap = new SortedList<int, Point>();
            MaxHeap<Point> maxHeap = new MaxHeap<Point>();
            int[,] matrix = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            for(int i=0; i < matrix.GetLength(0); i++)
            {
                for(int j=0; j < matrix.GetLength(1); j++)
                {
                    maxHeap.Add(new Point(i, j, matrix[i, j]));
                }
            }
            Assert.AreEqual(maxHeap.ExtractMax().val, 9);
            Assert.AreEqual(maxHeap.ExtractMax().val, 8);
            Assert.AreEqual(maxHeap.ExtractMax().val, 7);
            Assert.AreEqual(maxHeap.ExtractMax().val, 6);
            Assert.AreEqual(maxHeap.ExtractMax().val, 5);
            Assert.AreEqual(maxHeap.ExtractMax().val, 4);
            Assert.AreEqual(maxHeap.ExtractMax().val, 3);
            Assert.AreEqual(maxHeap.ExtractMax().val, 2);
            Assert.AreEqual(maxHeap.ExtractMax().val, 1);
        }
    }
}
