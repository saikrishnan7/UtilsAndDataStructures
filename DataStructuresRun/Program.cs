using Problems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresRun
{
    class Program
    {
        static void Main(string[] args)
        {
            new SinglyLinkedListTester().Go();
            new DoublyLinkedListTester().Go();
            SampleProblems sp = new SampleProblems();
            sp.LetterCombinations("234");
        }
    }
}
