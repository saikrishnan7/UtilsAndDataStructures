using System;

namespace ComplexDataStructures
{
    public class MinHeap<T> where T : IComparable<T>
    {
        private T[] _heapElements;
        private int _size;

        public MinHeap(int size)
        {
            _heapElements = new T[size];
            size = 0;
        }

        public MinHeap()
        {
            _size = 0;
            _heapElements = new T[128];
        }
        public T Min { get { return _size != 0 ? _heapElements[0] : throw new Exception("Heap is empty"); } }

        public void Add(T data)
        {
            if (_heapElements.Length == _size)
            {
                var temp = new T[_heapElements.Length * 2];
                var counter = 0;
                foreach (var t in _heapElements)
                {
                    temp[counter++] = t;
                }
                _heapElements = temp;
                _size = counter;
            }
            _heapElements[_size] = data;
            _size++;
            for(var i = _size/2; i >= 0; i--)
                MinHeapify(i);
        }

        public MinHeap<T> BuildMinHeap(T[] a)
        {
            foreach (var item in a)
            {
                Add(item);
            }
            return this;
        }

        public T ExtractMin()
        {
            Swap(0, _size - 1);
            var returnVal = _heapElements[_size - 1];
            _size--;
            MinHeapify(0);
            return returnVal;
        }

        private void MinHeapify(int i)
        {
            var rightChildIndex = 2 * i + 2;
            var leftChildIndex = 2 * i + 1;
            var minIndex = i;
            if (leftChildIndex < _size && _heapElements[leftChildIndex].CompareTo(_heapElements[i]) == -1)
            {
                minIndex = leftChildIndex;
            }
            if (rightChildIndex < _size && _heapElements[rightChildIndex].CompareTo(_heapElements[minIndex]) == -1)
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
            var temp = _heapElements[minIndex];
            _heapElements[minIndex] = _heapElements[index];
            _heapElements[index] = temp;
        }
    }
}
