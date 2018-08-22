using ComplexDataStructures;
using System;

namespace Problems
{
    public class QueueWithStacks<T>
    {
        private Stack<T> addStack;
        private Stack<T> retrieveStack;
        private int _size;

        public QueueWithStacks()
        {
            addStack = new Stack<T>();
            retrieveStack = new Stack<T>();
            _size = 0;
        }

        public int Size { get => _size; private set => _size = value; }

        public T Peek()
        {
            if (_size == 0)
                throw new InvalidOperationException("Cannot peek an empty Queue");
            if (retrieveStack.Size == 0)
            {
                if (addStack.Size != 0)
                {
                    foreach (T t in addStack)
                    {
                        retrieveStack.Push(t);
                    }
                    return retrieveStack.Peek();
                }
                else
                {
                    throw new InvalidOperationException("Cannot peek an empty Queue");
                }
            }
            return retrieveStack.Peek();
        }

        public void Enqueue(T item)
        {
            addStack.Push(item);
            _size++;
        }

        public T Dequeue()
        {
            if (_size == 0)
                throw new InvalidOperationException("Cannot pop an empty Queue");
            if (retrieveStack.Size == 0)
            {
                if (addStack.Size != 0)
                {
                    foreach (T t in addStack)
                    {
                        retrieveStack.Push(t);
                    }
                    return retrieveStack.Pop();
                }
                else
                {
                    throw new InvalidOperationException("Cannot pop an empty Queue");
                }
            }
            _size--;
            return retrieveStack.Pop();
        }

        public bool IsEmpty()
        {
            return _size == 0;
        }
    }
}
