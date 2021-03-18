using DataStructureHelper;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    public class SinglyLinkedList<T> : IEnumerable<T>
    {
        public SinglyLinkedListNode<T> Head { get; private set; }

        public SinglyLinkedListNode<T> Tail { get; private set; }

        public int Length { get; private set; }

        public SinglyLinkedList()
        {
            Head = Tail = null;
            Length = 0;
        }

        public SinglyLinkedList<T> InsertFirst(T data)
        {
            var node = new SinglyLinkedListNode<T>(data);
            if (Head == null)
            {
                Head = Tail = node;
            }
            else
            {
                node.Next = Head;
                Head = node;
            }
            Length++;
            return this;
        }

        public SinglyLinkedList<T> InsertLast(T data)
        {
            var node = new SinglyLinkedListNode<T>(data);
            if (Tail == null)
            {
                Head = Tail = node;
            }
            else
            {
                Tail.Next = node;
                Tail = node;
            }
            Length++;
            return this;
        }

        public SinglyLinkedList<T> RemoveLast()
        {
            var node = Head;
            for(var i = 0; i < Length - 2; i++)
            {
                node = node.Next;
            }
            Tail = node;
            node.Next = null;
            Length--;
            return this;
        }

        public SinglyLinkedList<T> RemoveFirst()
        {
            var headCopy = Head;
            Head = Head.Next;
            headCopy = null;
            Length--;
            return this;
        }

        public SinglyLinkedList<T> RemoveNext(SinglyLinkedListNode<T> node)
        {
            if (node.Next == Tail)
            {
                Tail = node;
                node.Next = null;
            }
            else
            {
                node.Next = node.Next.Next;
            }
            Length--;
            return this;
        }

        public SinglyLinkedList<T> MergeWith(SinglyLinkedList<T> list2)
        {
            if (list2 != null)
            {
                Tail.Next = list2.Head;
                Tail = list2.Tail;
                Length += list2.Length;
            }
            return this;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            var head = Head;
            while (head != null)
            {
                sb.Append(head.Data);
                sb.Append("-->");
                head = head.Next; 
            }
            return sb.ToString().Substring(0, sb.Length - 3);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            var list = (SinglyLinkedList<T>)obj;
            var n1 = Head;
            var n2 = list.Head;
            while (n1 != null)
            {
                if (n1 != n2)
                {
                    return false;
                }
                n1 = n1.Next;
                n2 = n2.Next;
            }
            return true;
        }

        public override int GetHashCode()
        {
            var hash = 97;
            hash = hash * 143 + (Head == null ? 0 : Head.GetHashCode());
            hash = hash * 143 + (Tail == null ? 0 : Tail.GetHashCode());
            hash = hash * 143 + (Length.GetHashCode());
            return hash;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = Head;
            while(node != null)
            {
                yield return node.Data;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public static bool operator ==(SinglyLinkedList<T> obj1, SinglyLinkedList<T> obj2)
        {
            if (ReferenceEquals(obj1, obj2))
            {
                return true;
            }

            if (obj1 is null)
            {
                return false;
            }
            if (obj2 is null)
            {
                return false;
            }

            return obj1.Equals(obj2);
        }

        public static bool operator !=(SinglyLinkedList<T> obj1, SinglyLinkedList<T> obj2)
        {
            return !(obj1 == obj2);
        }
    }
}
