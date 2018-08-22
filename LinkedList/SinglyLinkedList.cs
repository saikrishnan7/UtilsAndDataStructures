using DataStructureHelper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class SinglyLinkedList<T> : IEnumerable<T>
    {
        private SinglyLinkedListNode<T> _head;
        private SinglyLinkedListNode<T> _tail;
        private int _length;

        public SinglyLinkedListNode<T> Head
        {
            get => _head;
            private set => _head = value;
        }

        public SinglyLinkedListNode<T> Tail
        {
            get => _tail;
            private set => _tail = value;
        }

        public int Length
        {
            get => _length;
            private set => _length = value;
        }

        public SinglyLinkedList()
        {
            _head = _tail = null;
            _length = 0;
        }

        public SinglyLinkedList<T> InsertFirst(T data)
        {
            SinglyLinkedListNode<T> node = new SinglyLinkedListNode<T>(data);
            if (Head == null)
            {
                Head = Tail = node;
            }
            else
            {
                node.Next = Head;
                Head = node;
            }
            _length++;
            return this;
        }

        public SinglyLinkedList<T> InsertLast(T data)
        {
            SinglyLinkedListNode<T> node = new SinglyLinkedListNode<T>(data);
            if (Tail == null)
            {
                Head = Tail = node;
            }
            else
            {
                Tail.Next = node;
                Tail = node;
            }
            _length++;
            return this;
        }

        public SinglyLinkedList<T> RemoveLast()
        {
            var node = Head;
            for(int i = 0; i < _length - 2; i++)
            {
                node = node.Next;
            }
            Tail = node;
            node.Next = null;
            _length--;
            return this;
        }

        public SinglyLinkedList<T> RemoveFirst()
        {
            var headCopy = Head;
            Head = Head.Next;
            headCopy = null;
            _length--;
            return this;
        }

        public SinglyLinkedList<T> MergeWith(SinglyLinkedList<T> list2)
        {
            if (list2 != null)
            {
                Tail.Next = list2.Head;
                Tail = list2.Tail;
                _length += list2._length;
            }
            return this;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            SinglyLinkedListNode<T> head = Head;
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
            else
            {
                SinglyLinkedList<T> list = (SinglyLinkedList<T>)obj;
                SinglyLinkedListNode<T> n1 = Head;
                SinglyLinkedListNode<T> n2 = list.Head;
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
        }

        public override int GetHashCode()
        {
            int hash = 97;
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
