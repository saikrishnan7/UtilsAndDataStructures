﻿namespace Sorting
{
    public class MergeSortHelper
    {
        public SinglyLinkedListNode<int> MergeSort(
          SinglyLinkedListNode<int> head)
        {
            if (head?.Next == null)
                return head;
            var slowP = head;
            var fastP = head;
            SinglyLinkedListNode<int> prev = null;
            while (fastP?.Next != null)
            {
                prev = slowP;
                slowP = slowP.Next;
                fastP = fastP.Next.Next;
            }
            var head2 = slowP;
            if (prev != null) prev.Next = null;
            return SortedMergeSimpler(MergeSort(head), MergeSort(head2));
        }
        public SinglyLinkedListNode<int> SortedMerge(
            SinglyLinkedListNode<int> head1,
            SinglyLinkedListNode<int> head2)
        {
            SinglyLinkedListNode<int> mergedHead = null;
            SinglyLinkedListNode<int> mergedTail = null;
            while (head1 != null || head2 != null)
            {
                if (head1 == null)
                {
                    AddToMerged(ref mergedHead, ref mergedTail, head2);
                    head2 = head2.Next;
                }
                else if (head2 == null)
                {
                    AddToMerged(ref mergedHead, ref mergedTail, head1);
                    head1 = head1.Next;
                }
                else if (head1.Data > head2.Data)
                {
                    AddToMerged(ref mergedHead, ref mergedTail, head2);
                    head2 = head2.Next;
                }
                else
                {
                    AddToMerged(ref mergedHead, ref mergedTail, head1);
                    head1 = head1.Next;
                }
            }
            return mergedHead;
        }

        public SinglyLinkedListNode<int> SortedMergeSimpler(
            SinglyLinkedListNode<int> head1,
            SinglyLinkedListNode<int> head2)
        {
            if (head1 == null)
                return head2;
            if (head2 == null)
                return head1;
            SinglyLinkedListNode<int> mergedHead;
            if (head1.Data < head2.Data)
            {
                mergedHead = head1;
                mergedHead.Next = SortedMergeSimpler(head1.Next, head2);
            }
            else
            {
                mergedHead = head2;
                mergedHead.Next = SortedMergeSimpler(head1, head2.Next);
            }
            return mergedHead;
        }
        private void AddToMerged(ref SinglyLinkedListNode<int> mergedHead, ref SinglyLinkedListNode<int> mergedTail, SinglyLinkedListNode<int> node)
        {
            if ((mergedHead == null) && (mergedTail == null))
            {
                mergedHead = mergedTail = node;
            }
            else
            {
                mergedTail.Next = node;
                mergedTail = mergedTail.Next;
            }
        }
        public SinglyLinkedListNode<int> MergeAlternating(SinglyLinkedListNode<int> list1, SinglyLinkedListNode<int> list2)
        {
            SinglyLinkedListNode<int> merged = null, mergedHead=null;
            if (list1 == null)
            {
                return list2;
            }
            if (list2 == null)
            {
                return list1;
            }
            while (list2 != null && list1 != null)
            {
                if (merged == null)
                {
                    mergedHead = merged = list1;
                }
                else
                {
                    merged.Next = list1;
                    merged = merged.Next;
                }
                merged.Next = list2;
                merged = merged.Next;
                list1 = list1.Next;
                list2 = list2.Next;
            }
            if (list1 != null)
            {
                merged.Next = list1;
            }
            return mergedHead;
        }
        public SinglyLinkedListNode<int> ReverseKIntervals(SinglyLinkedListNode<int> head, int k)
        {
            var curr = head;
            var prevHead = head;
            var reversedTail = head;
            var n = k;
            var headTracker = 0;
            while(curr != null && k > 1)
            {
                while(k > 1 && curr.Next != null)
                {
                    curr = curr.Next;
                    k--;
                }
                if(k == 1 || curr.Next == null)
                {
                    var temp = curr.Next;
                    curr.Next = null;
                    var reversedHead = ReverseList(prevHead);
                    if (headTracker == 0)
                    {
                        head = reversedHead;
                        headTracker++;
                    }
                    else
                    {
                        reversedTail.Next = reversedHead;
                        reversedTail = prevHead;
                    }
                    prevHead = temp;
                    curr = temp;
                    if (k == 1)
                        k = n;
                }
            }
            return head;
        }

        private SinglyLinkedListNode<int> ReverseList(SinglyLinkedListNode<int> prevTail)
        {
            if (prevTail?.Next == null)
                return prevTail;
            var rev = ReverseList(prevTail.Next);
            prevTail.Next.Next = prevTail;
            prevTail.Next = null;
            return rev;
        }
    }
}

