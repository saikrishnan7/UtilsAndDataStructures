using LinkedList;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ComplexDataStructures
{
    public class Stack<T> : IEnumerable<T>
    {
        private readonly SinglyLinkedList<T> _list;
        private int _size;

        public Stack()
        {
            _list = new SinglyLinkedList<T>();
            _size = 0;
        }

        public int Size { get => _size; private set => _size = value; }

        public T Peek()
        {
            if (_size == 0)
                throw new InvalidOperationException("Cannot peek an empty Stack");
            return _list.Head.Data; 
        }

        public virtual void Push(T item)
        {
            _list.InsertFirst(item);
            _size++;
        }

        public virtual T Pop()
        {
            if (_size == 0)
                throw new InvalidOperationException("Cannot pop an empty Stack");
            var item = _list.Head.Data;
            _list.RemoveFirst();
            _size--;
            return item;
        }

        public bool IsEmpty()
        {
            return _size == 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
