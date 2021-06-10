using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexDataStructures
{
    public class PriorityQueue<T> where T : IComparable<T>
    {
        private const int FrontIndex = 1;

        private readonly List<T> _data;

        public int Count => _data.Count - 1;

        private readonly IComparer<T> _comparer;

        public PriorityQueue(IComparer<T> comparer = null)
        {
            if (comparer == null)
            {
                if(typeof(IComparable<T>).IsAssignableFrom(typeof(T)))
                {
                    comparer = Comparer<T>.Default;
                }
            }
            _comparer = comparer ?? throw new 
                ArgumentNullException($"You must specify a default comparer for the {nameof(PriorityQueue<T>)} class");
            _data = new List<T>
            {
                default
            };
        }

        public void Enqueue(T item)
        {
            _data.Add(item);
            UpHeap(_data.Count - 1);
        }

        public T Dequeue()
        {
            if (Count == 0)
                throw new Exception($"The ${nameof(PriorityQueue<T>)} is empty, cannot dequeue an empty queue");
            Swap(FrontIndex, _data.Count - 1);
            var item = _data[_data.Count - 1];
            _data.RemoveAt(_data.Count - 1);
            DownHeap(FrontIndex);
            return item;
        }

        public T Peek()
        {
            if (Count == 0)
                throw new Exception($"The ${nameof(PriorityQueue<T>)} is empty, cannot peek an empty queue");
            return _data[FrontIndex];
        }

        public bool IsEmpty()
        {
            return Count == 0;
        }

        private void DownHeap(int parentIndex)
        {
            var leftIndex = 2 * parentIndex;
            var rightIndex = 2 * parentIndex + 1;
            var priorityIndex = parentIndex;
            if (priorityIndex >= 1 && leftIndex < _data.Count && 
                _comparer.Compare(_data[priorityIndex], _data[leftIndex]) == 1)
            {
                priorityIndex = leftIndex;
            }

            if (priorityIndex >= 1 && rightIndex < _data.Count &&
                _comparer.Compare(_data[priorityIndex], _data[rightIndex]) == 1)
            {
                priorityIndex = rightIndex;
            }

            if (priorityIndex != parentIndex)
            {
                Swap(priorityIndex, parentIndex);
                DownHeap(priorityIndex);
            }
        }

        private void UpHeap(int childIndex)
        {
            var parentIndex = childIndex / 2;
            if (parentIndex >= 1 && _comparer.Compare(_data[parentIndex], _data[childIndex]) == 1)
            {
                Swap(parentIndex, childIndex);
                UpHeap(parentIndex);
            }
        }

        private void Swap(int index1, int index2)
        {
            var temp = _data[index1];
            _data[index1] = _data[index2];
            _data[index2] = temp;
        }

        #region StaticObjectBuilder

        private static IComparer<T> ReverseOrderComparer => Comparer<T>.Create((x, y) => y.CompareTo(x));

        private static IComparer<T> NaturalOrderComparer => Comparer<T>.Create((x, y) => x.CompareTo(y));

        public static PriorityQueue<T> BuildMaxPriorityQueue(List<T> elements) => BuildMaxHeap(elements);

        public static PriorityQueue<T> BuildMinPriorityQueue(List<T> elements) => BuildMinHeap(elements);

        private static PriorityQueue<T> BuildMinHeap(List<T> elements)
        { 
            return BuildHeap(NaturalOrderComparer, elements);
        }

        private static PriorityQueue<T> BuildMaxHeap(List<T> elements)
        {
            return BuildHeap(ReverseOrderComparer, elements);
        }

        private static PriorityQueue<T> BuildHeap(IComparer<T> comparer, List<T> elements)
        {
            if (elements == null)
                throw new ArgumentNullException(nameof(elements), "The list passed for heap creation can not be null");
            var heap = new PriorityQueue<T>(comparer);
            elements.ForEach(e => heap._data.Add(e));
            for (var i = heap._data.Count / 2; i >= 1; i--)
            {
                heap.DownHeap(i);
            }
            return heap;
        }
        #endregion
    }
}
