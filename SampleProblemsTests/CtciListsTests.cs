using LinkedList;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems;
using System;

namespace SampleProblemsTests
{
    [TestClass]
    public class CtciListsTests
    {
        [TestMethod]
        public void RemoveDuplicatesTest()
        {
            SinglyLinkedList<int> list = new SinglyLinkedList<int>();
            for (int i = 0; i < 10; i++)
            {
                list.InsertFirst(i);
                list.InsertLast(i);
            }
            CtCiList ctcliListExamples = new CtCiList();
            var modifiedList = ctcliListExamples.RemoveDuplicateNodes(list);
            Assert.AreEqual(modifiedList.Length, 10);
            Assert.AreEqual(modifiedList.Tail.Data, 0);
        }
        [TestMethod]
        public void RemoveKthFromLastTest()
        {
            SinglyLinkedList<int> list = new SinglyLinkedList<int>();
            for (int i = 0; i < 10; i++)
            {
                list.InsertFirst(i);
            }
            CtCiList ctcliListExamples = new CtCiList();
            var modifiedList = ctcliListExamples.RemoveKthFromLast(list, 4);
            Assert.AreEqual(modifiedList.Length, 9);
        }
        [TestMethod]
        public void RemoveMiddle()
        {
            SinglyLinkedList<int> list = new SinglyLinkedList<int>();
            for (int i = 0; i < 10; i++)
            {
                list.InsertFirst(i);
            }
            CtCiList ctcliListExamples = new CtCiList();
            var modifiedList = ctcliListExamples.RemoveMiddleNode(list, list.Head.Next.Next.Next.Next.Next.Next);
            Assert.AreEqual(modifiedList.Length, 9);
            Assert.AreEqual(modifiedList.Head.Next.Next.Next.Next.Next.Next.Data, 2);
        }

        [TestMethod]
        public void PartitionListTest()
        {
            SinglyLinkedList<int> list = new SinglyLinkedList<int>();
            int[] nums = new int[] { 3, 5, 8, 5, 10, 2, 1 };
            foreach (int num in nums)
            {
                list.InsertLast(num);
            }
            CtCiList ctcliListExamples = new CtCiList();
            var modifiedList = ctcliListExamples.PartitionList(list, 8);
            Assert.AreNotEqual(modifiedList.Tail.Data, 1);
        }

        [TestMethod]
        public void SumListsTest()
        {
            SinglyLinkedList<int> list1 = new SinglyLinkedList<int>();
            SinglyLinkedList<int> list2 = new SinglyLinkedList<int>();
            int[] nums = new int[] { 3, 5, 8 };
            foreach (int num in nums)
            {
                list1.InsertLast(num);
                list2.InsertFirst(num);

            }
            CtCiList ctcliListExamples = new CtCiList();
            var modifiedList = ctcliListExamples.SumLists(list1.Head, list2.Head);
            Assert.AreEqual(modifiedList.Tail.Data, 1);
        }

        [TestMethod]
        public void PalindromeListTest()
        {
            SinglyLinkedList<int> list1 = new SinglyLinkedList<int>();
            for (int i = 0; i < 4; i++)
            {
                list1.InsertFirst(i);
                //if(i != 0)
                    list1.InsertLast(i);
            }
            CtCiList ctcliListExamples = new CtCiList();
            Assert.IsTrue(ctcliListExamples.IsListPalindrome(list1));
        }
    }
}