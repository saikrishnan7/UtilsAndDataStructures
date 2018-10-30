using System;

namespace ComplexDataStructures
{
    public class MinHeap<T> where T : IComparable<T>
    {
        private T[] heapElements;
        private int size;

        public MinHeap(int size)
        {
            heapElements = new T[size];
            size = 0;
        }

        public MinHeap()
        {
            size = 0;
            heapElements = new T[128];
        }
        public T Min { get { return size != 0 ? heapElements[0] : throw new Exception("Heap is empty"); } }

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
            for(int i = size/2; i >= 0; i--)
                MinHeapify(i);
        }

        public MinHeap<T> BuildMinHeap(T[] a)
        {
            foreach (T item in a)
            {
                Add(item);
            }
            return this;
        }

        public T ExtractMin()
        {
            Swap(0, size - 1);
            T returnVal = heapElements[size - 1];
            size--;
            MinHeapify(0);
            return returnVal;
        }

        private void MinHeapify(int i)
        {
            int rightChildIndex = 2 * i + 2;
            int leftChildIndex = 2 * i + 1;
            int minIndex = i;
            if (leftChildIndex < size && heapElements[leftChildIndex].CompareTo(heapElements[i]) == -1)
            {
                minIndex = leftChildIndex;
            }
            if (rightChildIndex < size && heapElements[rightChildIndex].CompareTo(heapElements[minIndex]) == -1)
            {
                minIndex = rightChildIndex;
            }
            if (minIndex != i)
            {
                Swap(minIndex, i);
                MinHeapify(minIndex);
            }
        }

        private void Swap(int minIndex, int index)
        {
            T temp = heapElements[minIndex];
            heapElements[minIndex] = heapElements[index];
            heapElements[index] = temp;
        }
    }
}
