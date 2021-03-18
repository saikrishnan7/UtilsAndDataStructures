using LinkedList;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ComplexDataStructures
{
    public class Queue<T> : IEnumerable<T>
    {
        private readonly SinglyLinkedList<T> _list;
        private int _size;

        public Queue()
        {
            _list = new SinglyLinkedList<T>();
            _size = 0;
        }

        public int Size { get => _size; private set => _size = value; }

        public T Peek()
        {
            if (_size == 0)
                throw new InvalidOperationException("Cannot peek an empty Queue");
            return _list.Head.Data;
        }

        public void Enqueue(T item)
        {
            _list.InsertLast(item);
            _size++;
        }

        public T Dequeue()
        {
            if (_size == 0)
                throw new InvalidOperationException("Cannot dequeue an empty Queue");
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
