using DataStructureHelper;
using LinkedList;
using System.Collections.Generic;

namespace Problems
{
    public class CtCiList
    {
        public SinglyLinkedList<T> RemoveDuplicateNodes<T>(SinglyLinkedList<T> originalList)
        {
            var ptr = originalList.Head;
            var runner = originalList.Head;

            while (ptr != null)
            {
                while (runner.Next != null)
                {
                    if (ptr.Data.Equals(runner.Next.Data))
                    {
                        originalList.RemoveNext(runner);
                    }
                    else
                    {
                        runner = runner.Next;
                    }
                }
                ptr = ptr.Next;
                runner = ptr;
            }
            return originalList;
        }

        public SinglyLinkedList<T> RemoveKthFromLast<T>(SinglyLinkedList<T> originalList, int k)
        {
            var current = originalList.Head;
            var kth = originalList.Head;
            var count = 0;
            while (count < k)
            {
                kth = kth.Next;
                count++;
            }
            while(kth.Next != null)
            {
                kth = kth.Next;
                current = current.Next;
            }
            originalList.RemoveNext(current);
            return originalList;
        }

        public SinglyLinkedList<T> RemoveMiddleNode<T>(SinglyLinkedList<T> list, SinglyLinkedListNode<T> middleNode)
        {
            middleNode.Data = middleNode.Next.Data;
            return list.RemoveNext(middleNode);
        }

        public SinglyLinkedList<int> PartitionList(SinglyLinkedList<int> list, int value)
        {
            var newList = new SinglyLinkedList<int>();
            var curr = list.Head;
            while(curr != null)
            {
                if(curr.Data < value)
                {
                    newList.InsertFirst(curr.Data);
                }
                else
                {
                    newList.InsertLast(curr.Data);
                }
                curr = curr.Next;
            }
            return newList;
        }

        public SinglyLinkedList<int> SumLists(SinglyLinkedListNode<int> node1, SinglyLinkedListNode<int> node2)
        {
            /*if (node1 == null)
                return node2;
            if (node2 == null)
                return node1;*/
            var node3 = new SinglyLinkedListNode<int>(0);
            var retList = new SinglyLinkedList<int>();
            var retVal = node3;
            var carry = 0;
            while(node1 != null && node2 != null)
            {
                node3.Data = (node1.Data + node2.Data + carry) % 10;
                carry = (node1.Data + node2.Data + carry) / 10;
                node3.Next = new SinglyLinkedListNode<int>(0);
                node3 = node3.Next;
                node2 = node2.Next;
                node1 = node1.Next;
            }
            while(node1 != null)
            {
                node3.Data = (node1.Data + carry) % 10;
                carry = (node1.Data + carry) / 10;
                node3.Next = new SinglyLinkedListNode<int>(0);
                node3 = node3.Next;
                node1 = node1.Next;
            }
            while (node1 != null)
            {
                node3.Data = (node2.Data + carry) % 10;
                carry = (node2.Data + carry) / 10;
                node3.Next = new SinglyLinkedListNode<int>(0);
                node3 = node3.Next;
                node2 = node2.Next;
            }
            if(carry != 0)
            {
                node3.Data = carry;
            }
            while(retVal != null)
            {
                retList.InsertLast(retVal.Data);
                retVal = retVal.Next;
            }
            return retList;
        }
        public bool IsListPalindrome(SinglyLinkedList<int> list) 
        {
            var buff = new Stack<int>();
            var cur = list.Head;
            var length = 0;
            while (cur != null)
            {
                cur = cur.Next;
                length++;
            }
            cur = list.Head;
            for(var i=0; i < length/2;i++)
            {
                buff.Push(cur.Data);
                cur = cur.Next;
            }
            cur = length % 2 == 1 ? cur.Next : cur;
            while(cur != null && cur.Data == buff.Pop())
            {
                cur = cur.Next;
            }
            return cur == null;
        }

        public SinglyLinkedList<T> ReverseList<T>(SinglyLinkedList<T> list)
        {
            var current = list.Head;
            var next = list.Head.Next;
            while(next != null)
            {
                var nextOfNext = next.Next;
                next.Next = current;
                if (current == list.Head)
                    current.Next = null;
                current = next;
                next = nextOfNext;
            }
            return null;
        }
    }
}
