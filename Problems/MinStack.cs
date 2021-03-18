using System;
using System.Collections.Generic;

namespace Problems
{
    public class MinStack<T> : ComplexDataStructures.Stack<T> where T : struct
    {
        private readonly ComplexDataStructures.Stack<T> _minStack;

        public MinStack()
        {
            _minStack = new ComplexDataStructures.Stack<T>();
        }
        public override void Push(T item)
        {
            var comparer = Comparer<T>.Default;
            base.Push(item);
            if (_minStack.IsEmpty())
            {
                _minStack.Push(item);
            }
            else
            {
                if (comparer.Compare(item, _minStack.Peek()) <= 0)
                {
                    _minStack.Push(item);
                }
                else
                {
                    _minStack.Push(_minStack.Peek());
                }
            }
        }
        public override T Pop()
        {
            _minStack.Pop();
            return base.Pop();   
        }

        public T Min()
        {
            if (_minStack.Size == 0)
                throw new InvalidOperationException("Cannot employ Min() when stack is empty");
            return _minStack.Peek();
        }
    }
}
