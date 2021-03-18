using System;

namespace WordDictionary
{
    internal class Program
    {
        private static void Main()
        {
            var trie = new Trie();
            var lc = new LetterCombinationsOfAPhoneNumber();
            trie.InsertWord("Applecart");
            trie.InsertWord("Mango-man");
            trie.InsertWord("Interview");
            Console.WriteLine($"Trie contains prefix 'Mango': {trie.StartsWithPrefix("Mango")}");
            Console.WriteLine($"Trie contains prefix 'Apple': {trie.StartsWithPrefix("Apple")}");
            Console.WriteLine($"Trie contains word 'Interview': {trie.SearchWord("Interview")}");
            Console.WriteLine($"Trie contains word 'DropBox': {trie.SearchWord("DropBox")}");
            foreach (var letterCombination in lc.GetLetterCombinations("23"))
            {
                Console.WriteLine(letterCombination);
            }
        }
    }
}
