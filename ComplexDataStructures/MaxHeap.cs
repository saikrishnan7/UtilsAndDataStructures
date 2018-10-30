using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexDataStructures
{
    public class MaxHeap<T> where T : IComparable<T>
    {
        private T[] heapElements;
        private int size;

        public MaxHeap(int size)
        {
            heapElements = new T[size];
            size = 0;
        }

        public MaxHeap()
        {
            size = 0;
            heapElements = new T[128];
        }
        public T Max { get { return size != 0 ? heapElements[0] : throw new Exception("Heap is empty"); } }

        public void Add(T data)
        {
            if (heapElements.Length == size)
            {
                T[] temp = new T[heapElements.Length * 2];
                int counter = 0;
                foreach (T t in heapElements)
                {
                    temp[counter++] = t;
                }
                heapElements = temp;
                size = counter;
            }
            heapElements[size] = data;
            size++;
            for(int i=size/2; i >= 0; i--)
                MaxHeapify(i);
        }

        public MaxHeap<T> BuildMaxHeap(T[] a)
        {
            foreach (T item in a)
            {
                Add(item);
            }
            return this;
        }

        public T ExtractMax()
        {
            Swap(0, size - 1);
            T returnVal = heapElements[size - 1];
            size--;
            MaxHeapify(0);
            return returnVal;
        }

        private void MaxHeapify(int i)
        {
            int rightChildIndex = 2 * i + 2;
            int leftChildIndex = 2 * i + 1;
            int maxIndex = i;
            if (leftChildIndex < size && heapElements[leftChildIndex].CompareTo(heapElements[i]) == 1)
            {
                maxIndex = leftChildIndex;
            }
            if (rightChildIndex < size && heapElements[rightChildIndex].CompareTo(heapElements[maxIndex]) == 1)
            {
                maxIndex = rightChildIndex;
            }
            if (maxIndex != i)
            {
                Swap(maxIndex, i);
                MaxHeapify(maxIndex);
            }
        }

        private void Swap(int maxIndex, int index)
        {
            T temp = heapElements[maxIndex];
            heapElements[maxIndex] = heapElements[index];
            heapElements[index] = temp;
        }
    }
}
