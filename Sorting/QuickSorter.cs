using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class QuickSorter
    {
        public Random Random;

        private class Pair
        {
            public readonly int Number;
            public readonly int Index;

            public Pair(int number, int index)
            {
                Number = number;
                Index = index;
            }
        }

        public QuickSorter()
        {
            Random = new Random();
        }
        public void QuickSort(int[] arr)
        {
            QuickSortHelper(arr, 0, arr.Length - 1);
        }

        private void QuickSortHelper(int[] arr, int start, int end)
        {
            if (start >= end)
                return;
            var chosenPivotIndex = Random.Next(start, end);
            var finalPivotIndex = Partition(arr, chosenPivotIndex, start, end);
            QuickSortHelper(arr, 0, finalPivotIndex - 1);
            QuickSortHelper(arr, finalPivotIndex + 1, end);
        }

        private int Partition(int[] arr, int chosenPivotIndex, int start, int end)
        {
            Swap(arr, start, chosenPivotIndex);
            var pivot = arr[start];
            var smallerIndex = start; 
            for (var biggerIndex = start+1; biggerIndex <= end; biggerIndex++)
            {
                if (arr[biggerIndex] < pivot)
                {
                    smallerIndex++;
                    Swap(arr, smallerIndex, biggerIndex);
                }
            }
            Swap(arr, smallerIndex, start);
            return smallerIndex;
        }

        private void Swap(int[] arr, int a, int b)
        {
            var temp = arr[a];
            arr[a] = arr[b];
            arr[b] = temp;
        }

        public void OrderElements(int[] arr, int k)
        {
            var set = new SortedSet<Pair>(Comparer<Pair>.Create((x, y) => 
                x.Number == y.Number ? x.Index.CompareTo(y.Index) : x.Number.CompareTo(y.Number)));
            for (var i = 0; i < arr.Length; i++)
            {
                if (set.Count < k)
                {
                    set.Add(new Pair(arr[i], i));
                }
                else
                {
                    if (arr[i] > set.Min.Number)
                    {
                        set.Remove(set.Min);
                        set.Add(new Pair(arr[i], i));
                    }
                }
            }
        }
    }
}
