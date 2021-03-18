using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sorting;

namespace SortHelperTests
{
    [TestClass]
    public class SortHelperTests
    {
        [TestMethod]
        public void MergeSortHelperTests()
        {
            var nodeToBeSorted = CreateList();
            var mergeSortHelper = new MergeSortHelper();
            var sortedHead = mergeSortHelper.MergeSort(nodeToBeSorted);
            Assert.AreEqual(sortedHead.data, 1);
            Assert.AreEqual(sortedHead.Next.data, 3);
            Assert.AreEqual(sortedHead.Next.Next.data, 4);
            Assert.AreEqual(sortedHead.Next.Next.Next.data, 6);
            Assert.AreEqual(sortedHead.Next.Next.Next.Next.data, 9);
            Assert.AreEqual(sortedHead.Next.Next.Next.Next.Next.data, 11);
            Assert.AreEqual(sortedHead.Next.Next.Next.Next.Next.Next.data, 18);
        }
        [TestMethod]
        public void MergeListsHelperTests()
        {
            var node1 = new SinglyLinkedListNode<int>(1);
            var head1 = node1;
            var node2 = node1.Next = new SinglyLinkedListNode<int>(3);
            var node3 = node2.Next = new SinglyLinkedListNode<int>(5);
            var node4 = new SinglyLinkedListNode<int>(4);
            var head2 = node4;
            var node5 = node4.Next = new SinglyLinkedListNode<int>(2);
            var mergedHead = new MergeSortHelper().MergeAlternating(head1, head2);
            mergedHead.GetType();
        }
        private SinglyLinkedListNode<int> CreateList()
        {
            var node1 = new SinglyLinkedListNode<int>(3);
            var head = node1;
            var node2 = node1.Next = new SinglyLinkedListNode<int>(18);
            var node3 = node2.Next = new SinglyLinkedListNode<int>(4);
            var node4 = node3.Next = new SinglyLinkedListNode<int>(1);
            var node5 = node4.Next = new SinglyLinkedListNode<int>(11);
            var node6 = node5.Next = new SinglyLinkedListNode<int>(9);
            var node7 = node6.Next = new SinglyLinkedListNode<int>(6);
            return head;
        }
        [TestMethod]
        public void ReverseKIntervalsTest()
        {
            var nodeToBeSorted = CreateList();
            var mergeSortHelper = new MergeSortHelper();
            var answer = mergeSortHelper.ReverseKIntervals(nodeToBeSorted, 1);
            var debugStopper = answer.ToString();

        }
    }
}
