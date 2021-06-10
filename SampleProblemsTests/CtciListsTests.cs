using LinkedList;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems;


namespace SampleProblemsTests
{
    [TestClass]
    public class CtciListsTests
    {
        [TestMethod]
        public void RemoveDuplicatesTest()
        {
            var list = new SinglyLinkedList<int>();
            for (var i = 0; i < 10; i++)
            {
                list.InsertFirst(i);
                list.InsertLast(i);
            }
            var ctcliListExamples = new CtCiList();
            var modifiedList = ctcliListExamples.RemoveDuplicateNodes(list);
            Assert.AreEqual(modifiedList.Length, 10);
            Assert.AreEqual(modifiedList.Tail.Data, 0);
        }
        [TestMethod]
        public void RemoveKthFromLastTest()
        {
            var list = new SinglyLinkedList<int>();
            for (var i = 0; i < 10; i++)
            {
                list.InsertFirst(i);
            }
            var ctcliListExamples = new CtCiList();
            var modifiedList = ctcliListExamples.RemoveKthFromLast(list, 4);
            Assert.AreEqual(modifiedList.Length, 9);
        }
        [TestMethod]
        public void RemoveMiddle()
        {
            var list = new SinglyLinkedList<int>();
            for (var i = 0; i < 10; i++)
            {
                list.InsertFirst(i);
            }
            var ctcliListExamples = new CtCiList();
            var modifiedList = ctcliListExamples.RemoveMiddleNode(list, list.Head.Next.Next.Next.Next.Next.Next);
            Assert.AreEqual(modifiedList.Length, 9);
            Assert.AreEqual(modifiedList.Head.Next.Next.Next.Next.Next.Next.Data, 2);
        }

        [TestMethod]
        public void PartitionListTest()
        {
            var list = new SinglyLinkedList<int>();
            var nums = new[] { 3, 5, 8, 5, 10, 2, 1 };
            foreach (var num in nums)
            {
                list.InsertLast(num);
            }
            var ctcliListExamples = new CtCiList();
            var modifiedList = ctcliListExamples.PartitionList(list, 8);
            Assert.AreNotEqual(modifiedList.Tail.Data, 1);
        }

        [TestMethod]
        public void SumListsTest()
        {
            var list1 = new SinglyLinkedList<int>();
            var list2 = new SinglyLinkedList<int>();
            var nums = new[] { 3, 5, 8 };
            foreach (var num in nums)
            {
                list1.InsertLast(num);
                list2.InsertFirst(num);

            }
            var ctcliListExamples = new CtCiList();
            var modifiedList = ctcliListExamples.SumLists(list1.Head, list2.Head);
            Assert.AreEqual(modifiedList.Tail.Data, 1);
        }

        [TestMethod]
        public void PalindromeListTest()
        {
            var list1 = new SinglyLinkedList<int>();
            for (var i = 0; i < 4; i++)
            {
                list1.InsertFirst(i);
                //if(i != 0)
                    list1.InsertLast(i);
            }
            var ctcliListExamples = new CtCiList();
            Assert.IsTrue(ctcliListExamples.IsListPalindrome(list1));
        }
    }
}