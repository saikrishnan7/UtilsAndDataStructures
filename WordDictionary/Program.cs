using System;

namespace WordDictionary
{
    internal class Program
    {
        private static void Main()
        {
            //var trie = new Trie();
            //var lc = new LetterCombinationsOfAPhoneNumber();
            //trie.InsertWord("Applecart");
            //trie.InsertWord("Mango-man");
            //trie.InsertWord("Interview");
            //Console.WriteLine($"Trie contains prefix 'Mango': {trie.StartsWithPrefix("Mango")}");
            //Console.WriteLine($"Trie contains prefix 'Apple': {trie.StartsWithPrefix("Apple")}");
            //Console.WriteLine($"Trie contains word 'Interview': {trie.SearchWord("Interview")}");
            //Console.WriteLine($"Trie contains word 'DropBox': {trie.SearchWord("DropBox")}");
            //foreach (var letterCombination in lc.GetLetterCombinations("23"))
            //{
            //    Console.WriteLine(letterCombination);
            //}

            //[[-95,76],[17,7],[-55,-58],[53,20],[-69,-8],[-57,87],[-2,-42],[-10,-87],[-36,-57],[97,-39],[97,49]]
            // 5
            //

            var kClosest = new KClosest();
            var points = new int[11][];
            points[0] = new int[2] { -95, 76 };
            points[1] = new int[2] { 17, 7 };
            points[2] = new int[2] { -55, -58 };
            points[3] = new int[2] { 53, 20 }; 
            points[4] = new int[2] { -69, -8 };
            points[5] = new int[2] { -57, 87 };
            points[6] = new int[2] { -2, -42 };
            points[7] = new int[2] { -10, -87 };
            points[8] = new int[2] { -36, -57 };
            points[9] = new int[2] { 97, -39 };
            points[10] = new int[2] { 97, 49 };
            var result = kClosest.GetKClosestPoints(points, 5);
            var firstIndex = result[0];
        }
    }
}
