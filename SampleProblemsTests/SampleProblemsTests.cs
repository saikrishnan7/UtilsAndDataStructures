using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems;

namespace SampleProblemsTests
{
    [TestClass]
    public class SampleProblemsTests
    {
        [TestMethod]
        public void TestQueueWithStacks()
        {
            var queue = new QueueWithStacks<int>();
            queue.Enqueue(5);
            queue.Enqueue(4);
            queue.Enqueue(3);
            Assert.AreEqual(queue.Peek(), 5);
            queue.Dequeue();
            Assert.AreEqual(queue.Peek(), 4);
        }

        [TestMethod]
        public void ThreeSumTest()
        {
            SampleProblems prob = new SampleProblems();
            int[] input = { -2, 0, 0, 2, 2 }; //-4,-1,-1,0,1,2
            var solutionSet = prob.ThreeSum(input);
            Assert.AreEqual(solutionSet.Count, 1);
            int[] diffInput = { -4, -1, -1, 0, 1, 2 };
            solutionSet = prob.ThreeSum(diffInput);
            Assert.AreEqual(solutionSet.Count, 2);
        }

        [TestMethod]
        public void HammingTest()
        {
            SampleProblems prob = new SampleProblems();

            Assert.AreEqual(prob.HammingDistance(1, 4), 2);
        }

        [TestMethod]
        public void ToLowerTest()
        {
            SampleProblems prob = new SampleProblems();
            Assert.AreEqual(prob.ToLowerCase("HELLO"), "hello");
        }

        [TestMethod]
        public void PeakIndexInMountainArrayTest()
        {
            int[] A = { 0, 1, 0 };
            SampleProblems prob = new SampleProblems();
            Assert.AreEqual(prob.PeakIndexInMountainArray(A), 1);
        }

        [TestMethod]
        public void CountAndSayTest()
        {
            SampleProblems prob = new SampleProblems();
            Assert.AreEqual(prob.CountAndSay(6), "312211");
        }
        [TestMethod]
        public void strStrTest()
        {
            SampleProblems prob = new SampleProblems();
            Assert.AreEqual(prob.StrStr("mississippi", "issip"), 4);
        }
        [TestMethod]
        public void ColumnNumberTest()
        {
            SampleProblems prob = new SampleProblems();
            Assert.AreEqual(prob.TitleToNumber("ZY"), 701);
        }

        [TestMethod]
        public void CountSubstringTest()
        {
            SampleProblems prob = new SampleProblems();
            Assert.AreEqual(prob.CountSubstrings("xkjkqlajprjwefilxgpdpebieswu"), 30);
        }
        [TestMethod]
        public void LevelOrderTest()
        {
            TreeNode root = new TreeNode(3)
            {
                right = new TreeNode(19),
                left = new TreeNode(20)
            };
            root.right.left = new TreeNode(5);
            root.right.right = new TreeNode(18);
            SampleProblems prob = new SampleProblems();
            Assert.AreEqual(prob.LevelOrder(root)[0][0], 3);
            Assert.AreEqual(prob.LevelOrder(root)[1][0], 20);
            Assert.AreEqual(prob.LevelOrder(root)[1][1], 19);
            Assert.AreEqual(prob.LevelOrder(root)[2][0], 5);
            Assert.AreEqual(prob.LevelOrder(root)[2][1], 18);
        }
        [TestMethod]
        public void MoveZeroesTest()
        {
            int[] a = new int[] { 1, 10, -1, 11, 5, 0, -7, 0, 25, -35 };
            SampleProblems prob = new SampleProblems();
            Assert.AreEqual(prob.MoveZeroes(a)[3], 10);
        }
        [TestMethod]
        public void QuickSortTest()
        {
            int[] a = new int[] { 55, 23, 2, 26, 29, 11, 8, 78, 24, 42, 48 };
            SampleProblems prob = new SampleProblems();
            prob.QuickSortIterative(a);
            Assert.AreEqual(a[10], 78);
            Assert.AreEqual(a[9], 55);
        }
        [TestMethod]
        public void RotateArrayTest()
        {
            int[] a = new int[] { 55, 23, 2, 26, 29, 11, 8, 78, 24, 42, 48 };
            SampleProblems prob = new SampleProblems();
            prob.RotateArray(a, 2);
            Assert.AreEqual(a[10], 24);
            Assert.AreEqual(a[9], 78);
        }
        [TestMethod]
        public void MinMaxIndexTest()
        {
            //int[] a = new int[] { 1,1,1,1,1,1,1,1,1,1,1,2,5,5,5,5,5,5,5,5,5,5,8,8,8,8,8,8,9,9,9,9,9,9,9,9,11,11,11,11 };
            int[] a = new int[] { 1, 1, 2 };
            SampleProblems prob = new SampleProblems();
            Tuple<int, int> interval = prob.GetMinMaxIndex(a, 2);
            Assert.AreEqual(interval.Item1, 2);
            Assert.AreEqual(interval.Item2, 2);
        }
        [TestMethod]
        public void BuySellStockTest()
        {
            int[] a = new int[] { 7, 1, 2, 8, 6, 11, 2, 8 };
            SampleProblems prob = new SampleProblems();
            Tuple<int, int> interval = prob.GetBestBuySell(a);
            Assert.AreEqual(interval.Item1, 1);
            Assert.AreEqual(interval.Item2, 11);
        }

        [TestMethod]
        public void MergeIntervalsTest()
        {
            var intervals = new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(1, 5), new Tuple<int, int>(3, 7), new Tuple<int, int>(4, 6),
                new Tuple<int, int>(6, 8), new Tuple<int, int>(10, 12), new Tuple<int, int>(11, 15)
            };
            SampleProblems prob = new SampleProblems();
            var mergedIntervals = prob.MergeIntervals(intervals);
            Assert.IsTrue(mergedIntervals.Count == 2);
            //Assert.IsTrue(mergedIntervals[0].Item2 == 3);
            //Assert.IsTrue(mergedIntervals[0].Item1 == 0);
            //Assert.IsTrue(mergedIntervals[1].Item2 == 9);
            //Assert.IsTrue(mergedIntervals[1].Item1 == 7);
            //Assert.IsTrue(mergedIntervals[2].Item2 == 9);
            //Assert.IsTrue(mergedIntervals[2].Item1 == 7);
        }

        [TestMethod]
        public void TwoSumTest()
        {
            int[] a = new int[] { 7, 1, 2, 8, 6, 11, 2, 8 };
            SampleProblems prob = new SampleProblems();
            Assert.IsFalse(prob.IsValidTwoSum(a, 21));
        }

        [TestMethod]
        public void FindPythTripletsTest()
        {
            int[] nums = { 3, 4, 5, 12, 13, 6, 8, 10, 9, 16, 25 };
            SampleProblems prob = new SampleProblems();
            Assert.IsTrue(prob.FindPythTriplets(nums).Count > 1);
        }
        [TestMethod]
        public void IntegerDivisionTest()
        {
            int val = new SampleProblems().IntegerDivision(-40, -4);
            Assert.IsTrue(val == 10);
        }
        [TestMethod]
        public void ArrayProductTest()
        {
            int[] a = { 8, 2, 3, 4, 5, 6, 7, 7 };
            int[] result = new SampleProblems().ProductOfAllButSelf(a);
            Assert.AreEqual(result[3], 7 * 7 * 8 * 60 * 3);
        }
        [TestMethod]
        public void CellCompeteTest()
        {
            int[] a = { 1, 1, 1, 0, 1, 1, 1, 1 };
            int days = 2;
            int[] result = new SampleProblems().CellCompete(a, days);
            Assert.AreEqual(result.Length, 8);
        }
        [TestMethod]
        public void LadderLengthTest()
        {
            string beginWord = "hot";
            string endWord = "dog";
            var words = new List<string>() { "hot", "dog", "cog", "pot", "dot" };
            var sp = new SampleProblems();
            int ladder = sp.LadderLength(beginWord, endWord, words);
            Assert.AreEqual(ladder, 3);
        }

        [TestMethod]
        public void CountIterativeTest()
        {
            var sp = new SampleProblems();
            int ans = sp.CountIterative(6, 10);
            Assert.IsFalse(ans == 0);
        }

        [TestMethod]
        public void CountRecursiveTest()
        {
            var sp = new SampleProblems();
            int ans = sp.CountRecursive(6, 10);
            Assert.IsTrue(ans == sp.CountIterative(6, 10));
        }

        [TestMethod]
        public void TestPartition()
        {
            var sp = new SampleProblems();
            var ans = sp.PartitionLabelsAlternate("ababcbacadefegdehijhklij");
            Assert.IsTrue(ans.Count > 1);
        }
        [TestMethod]
        public void RotateImage()
        {
            int[,] matrix = new int[,] 
            { 
                { 1, 2, 3 }, 
                { 4, 5, 6 },
                { 7, 8, 9 } 
            };
            var sp = new SampleProblems();
            sp.Rotate(matrix);
            Assert.AreEqual(7, matrix[0, 0]);
        }
        [TestMethod]
        public void TestTrap()
        {
            int[] a = { 0, 1, 0, 0, 0, 0, 0, 2 };
            var sp = new SampleProblems();
            //var ans = sp.Trap(a);
            //Assert.AreEqual(ans, 5);
        }

        [TestMethod]
        public void TestSearch()
        {
            char[,] board = { { 'C', 'A', 'A' }, { 'A', 'A', 'A' }, { 'B', 'C', 'D' } };
            string searchWord = "AAB";
            var sp = new SampleProblems();
            Assert.IsTrue(sp.Exist(board, searchWord));
        }

        [TestMethod]
        public void TestWildcard()
        {
            var sp = new SampleProblems();
            Assert.IsTrue(sp.IsMatch("acdcb", "a*c?b"));
        }

        [TestMethod]
        public void TestReverseWords()
        {
            var sp = new SampleProblems();
            char[] input = new char[] { 't', 'h', 'e', ' ', 's', 'k', 'y', ' ', 'i', 's', ' ', 'b', 'l', 'u', 'e' };
            sp.ReverseWords(input);
            Assert.IsTrue(input[0] == 'b');
        }
    }
}
