using Problems;

namespace DataStructuresRun
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            new SinglyLinkedListTester().Go();
            new DoublyLinkedListTester().Go();
            var sp = new SampleProblems();
            sp.LetterCombinations("234");
        }
    }
}
