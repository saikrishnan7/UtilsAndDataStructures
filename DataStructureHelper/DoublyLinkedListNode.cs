using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureHelper
{
    public class DoublyLinkedListNode<T> 
    {
        private T _data;
        private DoublyLinkedListNode<T> _next;
        private DoublyLinkedListNode<T> _prev;
        public DoublyLinkedListNode(T data)
        {
            _data = data;
            _next = null;
            _prev = null;
        }

        public T Data { get => _data; set => _data = value; }

        public DoublyLinkedListNode<T> Next { get => _next; set => _next = value; }

        public DoublyLinkedListNode<T> Prev { get => _prev; set => _prev = value; }

        public void CreateAddNodeAfter(T data, DoublyLinkedListNode<T> currentNode)
        {
            DoublyLinkedListNode<T> newNode = new DoublyLinkedListNode<T>(data);
            DoublyLinkedListNode<T> nextCopy = currentNode.Next;
            DoublyLinkedListNode<T> prevCopy = currentNode.Prev;
            currentNode.Next = newNode;
            newNode.Prev = currentNode;
            newNode.Next = nextCopy;
            newNode.Next.Prev = newNode;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            else
            {
                DoublyLinkedListNode<T> node = (DoublyLinkedListNode<T>)obj;
                return Data.Equals(node.Data);
            }
        }

        public override int GetHashCode()
        {
            int hash = 97;
            hash = hash * 143 + (Data == null ? 0 : Data.GetHashCode());
            hash = hash * 143 + (Next == null ? 0 : Next.GetHashCode());
            hash = hash * 143 + (Prev == null ? 0 : Prev.GetHashCode());
            return hash;
        }

        public override string ToString()
        {
            return _data.ToString();
        }

        public static bool operator ==(DoublyLinkedListNode<T> obj1, DoublyLinkedListNode<T> obj2)
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

        // this is second one '!='
        public static bool operator !=(DoublyLinkedListNode<T> obj1, DoublyLinkedListNode<T> obj2)
        {
            return !(obj1 == obj2);
        }
    }
}
