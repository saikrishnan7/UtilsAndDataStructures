using System;
using System.Collections.Generic;

namespace Problems
{
    public class MinStack<T> : ComplexDataStructures.Stack<T> where T : struct
    {
        private ComplexDataStructures.Stack<T> minStack;

        public MinStack()
        {
            minStack = new ComplexDataStructures.Stack<T>();
        }
        public override void Push(T item)
        {
            var comparer = Comparer<T>.Default;
            base.Push(item);
            if (minStack.IsEmpty())
            {
                minStack.Push(item);
            }
            else
            {
                if (comparer.Compare(item, minStack.Peek()) <= 0)
                {
                    minStack.Push(item);
                }
                else
                {
                    minStack.Push(minStack.Peek());
                }
            }
        }
        public override T Pop()
        {
            minStack.Pop();
            return base.Pop();   
        }

        public T Min()
        {
            if (minStack.Size == 0)
                throw new InvalidOperationException("Cannot employ Min() when stack is empty");
            return minStack.Peek();
        }
    }
}
