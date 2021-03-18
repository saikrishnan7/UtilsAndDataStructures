using LinkedList;
using System;
using System.Linq;

namespace DataStructuresRun
{
    public class DoublyLinkedListTester
    {
        private readonly int[] _inputArray1 = { 1, 2, 3, 4, 5, 6 };
        private readonly string[] _inputArray2 = { "a", "b", "c", "e", "f" };

        public void Go()
        {
            CreateListByFrontInsertThenRemoveFirst();
            CreateListByBackInsertThenRemoveLast();

            MergeLists();
            TestEquals();
        }
        private void CreateListByFrontInsertThenRemoveFirst()
        {
            var doubleCircularLinkedList = new DoubleCircularLinkedList<int>();
            foreach (var num in _inputArray1)
            {
                doubleCircularLinkedList.InsertFirst(num);
            }
            Console.WriteLine(doubleCircularLinkedList.RemoveFirst());
        }

        private void CreateListByBackInsertThenRemoveLast()
        {
            var doubleCircularLinkedList = new DoubleCircularLinkedList<int>();
            foreach (var num in _inputArray1)
            {
                doubleCircularLinkedList.InsertLast(num);
            }
            Console.WriteLine(doubleCircularLinkedList.RemoveLast());
        }

        private void MergeLists()
        {
            var list1 = new DoubleCircularLinkedList<string>();
            foreach (var str in _inputArray2)
            {
                list1.InsertLast(str);
            }
            var list2 = new DoubleCircularLinkedList<string>();
            foreach (var str in _inputArray2)
            {
                list2.InsertFirst(str);
            }
            var merged = list1.MergeWith(list2);
            //Console.WriteLine(merged);
            foreach(var s in merged)
            {
                Console.WriteLine(s);
            }
        }

        private void TestEquals()
        {
            var list1 = new DoubleCircularLinkedList<int>();
            foreach (var num in _inputArray1)
            {
                list1.InsertLast(num);
            }
            var list2 = new DoubleCircularLinkedList<int>();
            foreach (var num in _inputArray1.Reverse())
            {
                list2.InsertFirst(num);
            }
            if (list1 == list2)
                Console.WriteLine("'==' works");
            if (list1.Equals(list2))
                Console.WriteLine("Equals also works");

        }
    }
}
