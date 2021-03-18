using DataStructureHelper;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    public class DoubleCircularLinkedList<T> : IEnumerable<T>
    {
        private DoublyLinkedListNode<T> _head;
        private DoublyLinkedListNode<T> _tail;
        private int _length;

        public DoublyLinkedListNode<T> Head
        {
            get => _head;
            private set => _head = value;
        }

        public DoublyLinkedListNode<T> Tail
        {
            get => _tail;
            private set => _tail = value;
        }

        public int Length
        {
            get => _length;
            private set => _length = value;
        }

        public DoubleCircularLinkedList()
        {
            _head = _tail = null;
            _length = 0;
        }

        public DoublyLinkedListNode<T> InsertFirst(T data)
        {
            var node = new DoublyLinkedListNode<T>(data);
            if (Head == null)
            {
                Head = Tail = node;
            }
            else
            {
                node.Next = Head;
                node.Prev = Tail;
                Tail.Next = node;
                node.Next.Prev = node;
                Head = node;
            }
            _length++;
            return Head;
        }

        public DoublyLinkedListNode<T> InsertLast(T data)
        {
            var node = new DoublyLinkedListNode<T>(data);
            if (Tail == null)
            {
                Head = Tail = node;
            }
            else
            {
                Tail.Next = node;
                node.Next = Head;
                Head.Prev = node;
                node.Prev = Tail;
                Tail = node;
            }
            _length++;
            return Head;
        }

        public DoubleCircularLinkedList<T> RemoveLast()
        {
            if (this == null)
                return null;
            Tail = Tail.Prev;
            Tail.Next = Tail.Next.Next;
            Tail.Next.Prev = Tail;
            _length--;
            return this;
        }

        public DoubleCircularLinkedList<T> RemoveFirst()
        {
            if (this == null)
                return null;
            Head = Head.Next;
            Head.Prev = Head.Prev.Prev;
            Head.Prev.Next = Head;
            _length--;
            return this;
        }
        public DoubleCircularLinkedList<T> MergeWith(DoubleCircularLinkedList<T> list2)
        {
            if (list2 != null)
            {
                Tail.Next = list2.Head;
                Tail = list2.Tail;
                list2.Tail.Next = Head;
                Head.Prev = Tail;
                _length += list2._length;
            }
            return this;
        }

        public override string ToString()
        {
            var count = 0;
            var sb = new StringBuilder();
            var head = Head;
            while (head != null && count != Length)
            {
                sb.Append(head.Data);
                sb.Append("<-->");
                head = head.Next;
                count++;
            }
            return sb.ToString().Substring(0, sb.Length - 4);
        }

        public override bool Equals(object obj)
        {
            var count = 0;
            if (obj == null)
                return false;
            var list = (DoubleCircularLinkedList<T>)obj;
            var n1 = Head;
            var n2 = list.Head;
            while (n1 != null && count != Length)
            {
                if (n1 != n2)
                {
                    return false;
                }
                n1 = n1.Next;
                n2 = n2.Next;
                count++;
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
            var count = 0;
            while(node != null && count < _length)
            {
                yield return node.Data;
                node = node.Next;
                count++;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public static bool operator ==(DoubleCircularLinkedList<T> obj1, DoubleCircularLinkedList<T> obj2)
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

        public static bool operator !=(DoubleCircularLinkedList<T> obj1, DoubleCircularLinkedList<T> obj2)
        {
            return !(obj1 == obj2);
        }
    }
}
