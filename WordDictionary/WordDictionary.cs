using System;
using System.Collections.Generic;
using System.Text;

namespace WordDictionary
{
    public class WordDictionary
    {
        private readonly Trie _trie;

        public WordDictionary()
        {
            _trie = new Trie();
        }

        public void AddWord(string word)
        {
            _trie.InsertWord(word);
        }

        //public bool Search(string word)
        //{

        //}
    }
}
