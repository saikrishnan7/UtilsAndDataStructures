using DataStructureHelper;
using LinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    public class CtCiList
    {
        public SinglyLinkedList<T> RemoveDuplicateNodes<T>(SinglyLinkedList<T> originalList)
        {
            SinglyLinkedListNode<T> ptr = originalList.Head;
            SinglyLinkedListNode<T> runner = originalList.Head;

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
            SinglyLinkedListNode<T> current = originalList.Head;
            SinglyLinkedListNode<T> kth = originalList.Head;
            int count = 0;
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
            SinglyLinkedList<int> newList = new SinglyLinkedList<int>();
            SinglyLinkedListNode<int> curr = list.Head;
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
            int carry = 0;
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
            Stack<int> buff = new Stack<int>();
            var cur = list.Head;
            int length = 0;
            while (cur != null)
            {
                cur = cur.Next;
                length++;
            }
            cur = list.Head;
            for(int i=0; i < length/2;i++)
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
