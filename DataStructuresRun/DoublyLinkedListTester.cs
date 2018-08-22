using LinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresRun
{
    public class DoublyLinkedListTester
    {
        private readonly int[] inputArray1 = { 1, 2, 3, 4, 5, 6 };
        private readonly string[] inputArray2 = { "a", "b", "c", "e", "f" };

        public void Go()
        {
            CreateListByFrontInsertThenRemoveFirst();
            CreateListByBackInsertThenRemoveLast();

            MergeLists();
            TestEquals();
        }
        private void CreateListByFrontInsertThenRemoveFirst()
        {
            DoubleCircularLinkedList<int> DoubleCircularLinkedList = new DoubleCircularLinkedList<int>();
            foreach (int num in inputArray1)
            {
                DoubleCircularLinkedList.InsertFirst(num);
            }
            Console.WriteLine(DoubleCircularLinkedList.RemoveFirst());
        }

        private void CreateListByBackInsertThenRemoveLast()
        {
            DoubleCircularLinkedList<int> DoubleCircularLinkedList = new DoubleCircularLinkedList<int>();
            foreach (int num in inputArray1)
            {
                DoubleCircularLinkedList.InsertLast(num);
            }
            Console.WriteLine(DoubleCircularLinkedList.RemoveLast());
        }

        private void MergeLists()
        {
            DoubleCircularLinkedList<string> list1 = new DoubleCircularLinkedList<string>();
            foreach (string str in inputArray2)
            {
                list1.InsertLast(str);
            }
            DoubleCircularLinkedList<string> list2 = new DoubleCircularLinkedList<string>();
            foreach (string str in inputArray2)
            {
                list2.InsertFirst(str);
            }
            DoubleCircularLinkedList<string> merged = list1.MergeWith(list2);
            //Console.WriteLine(merged);
            foreach(string s in merged)
            {
                Console.WriteLine(s);
            }
        }

        private void TestEquals()
        {
            DoubleCircularLinkedList<int> list1 = new DoubleCircularLinkedList<int>();
            foreach (int num in inputArray1)
            {
                list1.InsertLast(num);
            }
            DoubleCircularLinkedList<int> list2 = new DoubleCircularLinkedList<int>();
            foreach (int num in inputArray1.Reverse())
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
