using LinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresRun
{
    public class SinglyLinkedListTester
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
            SinglyLinkedList<int> singlyLinkedList = new SinglyLinkedList<int>();
            foreach(int num in inputArray1)
            {
                singlyLinkedList.InsertFirst(num);
            }
            Console.WriteLine(singlyLinkedList.RemoveFirst());
        }

        private void CreateListByBackInsertThenRemoveLast()
        {
            SinglyLinkedList<int> singlyLinkedList = new SinglyLinkedList<int>();
            foreach (int num in inputArray1)
            {
                singlyLinkedList.InsertLast(num);
            }
            Console.WriteLine(singlyLinkedList.RemoveLast());
        }

        private void MergeLists()
        {
            SinglyLinkedList<string> list1 = new SinglyLinkedList<string>();
            foreach (string str in inputArray2)
            {
                list1.InsertLast(str);
            }
            SinglyLinkedList<string> list2 = new SinglyLinkedList<string>();
            foreach (string str in inputArray2)
            {
                list2.InsertFirst(str);
            }
            SinglyLinkedList<string> merged = list1.MergeWith(list2);
            //Console.WriteLine(merged);
            foreach(string s in merged)
            {
                Console.WriteLine(s);
            }
        }

        private void TestEquals()
        {
            SinglyLinkedList<int> list1 = new SinglyLinkedList<int>();
            foreach (int num in inputArray1)
            {
                list1.InsertLast(num);
            }
            SinglyLinkedList<int> list2 = new SinglyLinkedList<int>();
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
