using ComplexDataStructures;
using System;

namespace Problems
{
    public class QueueWithStacks<T>
    {
        private readonly Stack<T> _addStack;
        private readonly Stack<T> _retrieveStack;
        private int _size;

        public QueueWithStacks()
        {
            _addStack = new Stack<T>();
            _retrieveStack = new Stack<T>();
            _size = 0;
        }

        public int Size { get => _size; private set => _size = value; }

        public T Peek()
        {
            if (_size == 0)
                throw new InvalidOperationException("Cannot peek an empty Queue");
            if (_retrieveStack.Size == 0)
            {
                if (_addStack.Size != 0)
                {
                    foreach (var t in _addStack)
                    {
                        _retrieveStack.Push(t);
                    }
                    return _retrieveStack.Peek();
                }

                throw new InvalidOperationException("Cannot peek an empty Queue");
            }
            return _retrieveStack.Peek();
        }

        public void Enqueue(T item)
        {
            _addStack.Push(item);
            _size++;
        }

        public T Dequeue()
        {
            if (_size == 0)
                throw new InvalidOperationException("Cannot pop an empty Queue");
            if (_retrieveStack.Size == 0)
            {
                if (_addStack.Size != 0)
                {
                    foreach (var t in _addStack)
                    {
                        _retrieveStack.Push(t);
                    }
                    return _retrieveStack.Pop();
                }

                throw new InvalidOperationException("Cannot pop an empty Queue");
            }
            _size--;
            return _retrieveStack.Pop();
        }

        public bool IsEmpty()
        {
            return _size == 0;
        }
    }
}
