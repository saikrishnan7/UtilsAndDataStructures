using System;

namespace ComplexDataStructures
{
    public class MaxHeap<T> where T : IComparable<T>
    {
        private T[] _heapElements;
        private int _size;

        public MaxHeap(int size)
        {
            _heapElements = new T[size];
            size = 0;
        }

        public MaxHeap()
        {
            _size = 0;
            _heapElements = new T[128];
        }
        public T Max { get { return _size != 0 ? _heapElements[0] : throw new Exception("Heap is empty"); } }

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
            for(var i=_size/2; i >= 0; i--)
                MaxHeapify(i);
        }

        public MaxHeap<T> BuildMaxHeap(T[] a)
        {
            foreach (var item in a)
            {
                Add(item);
            }
            return this;
        }

        public T ExtractMax()
        {
            Swap(0, _size - 1);
            var returnVal = _heapElements[_size - 1];
            _size--;
            MaxHeapify(0);
            return returnVal;
        }

        private void MaxHeapify(int i)
        {
            var rightChildIndex = 2 * i + 2;
            var leftChildIndex = 2 * i + 1;
            var maxIndex = i;
            if (leftChildIndex < _size && _heapElements[leftChildIndex].CompareTo(_heapElements[i]) == 1)
            {
                maxIndex = leftChildIndex;
            }
            if (rightChildIndex < _size && _heapElements[rightChildIndex].CompareTo(_heapElements[maxIndex]) == 1)
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
            var temp = _heapElements[maxIndex];
            _heapElements[maxIndex] = _heapElements[index];
            _heapElements[index] = temp;
        }
    }
}
