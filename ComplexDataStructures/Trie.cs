using System.Collections.Generic;

namespace ComplexDataStructures
{
    public class Trie
    {
        private class TrieNode
        {
            internal readonly Dictionary<char, TrieNode> children;

            public TrieNode()
            {
                children = new Dictionary<char, TrieNode>();
            }

            internal bool IsWord { set; get; }
        }
        private readonly TrieNode _root;
        public Trie()
        {
            _root = new TrieNode();
        }

        public int Size { get; private set; }

        public void Insert(string word)
        {
            var current = _root;
            foreach (var t in word)
            {
                TrieNode newNode;
                if (!current.children.ContainsKey(t))
                {
                    newNode = new TrieNode();
                    current.children.Add(t, newNode);
                }
                else
                {
                    newNode = current.children[t];
                }
                current = newNode;
            }
            current.IsWord = true;
            Size++;
        }

        public bool Search(string word)
        {
            var temp = SearchHelper(word);
            return temp?.IsWord ?? false;
        }

        public bool StartsWith(string prefix)
        {
            return SearchHelper(prefix) != null;
        }

        private TrieNode SearchHelper(string word)
        {
            var current = _root;
            var isNotFound = false;
            for (var i = 0; i < word.Length && !isNotFound; i++)
            {
                TrieNode newNode = null;
                if (!current.children.ContainsKey(word[i]))
                {
                    isNotFound = true;
                }
                else
                {
                    newNode = current.children[word[i]];
                }
                current = newNode;
            }
            return current;
        }
    }
}
