using DataStructureHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexDataStructures
{
    public class Trie
    {
        private class TrieNode
        {
            internal Dictionary<char, TrieNode> children;

            public TrieNode()
            {
                children = new Dictionary<char, TrieNode>();
            }

            internal bool IsWord { set; get; }

            internal string Word { set; get; }

        }
        private readonly TrieNode root;
        public Trie()
        {
            root = new TrieNode();
        }

        public int Size { get; private set; }

        public void Insert(string word)
        {
            TrieNode current = root;
            for(int i=0; i < word.Length; i++)
            {
                TrieNode newNode = null;
                if (!current.children.ContainsKey(word[i]))
                {
                    newNode = new TrieNode();
                    current.children.Add(word[i], newNode);
                }
                else
                {
                    newNode = current.children[word[i]];
                }
                current = newNode;
            }
            current.IsWord = true;
            current.Word = word;
            Size++;
        }

        public bool Search(string word)
        {
            TrieNode temp = SearchHelper(word);
            return temp != null ? temp.IsWord : false;
        }

        public bool StartsWith(string prefix)
        {
            return SearchHelper(prefix) != null;
        }

        private TrieNode SearchHelper(string word)
        {
            TrieNode current = root;
            bool isNotFound = false;
            for (int i = 0; i < word.Length && !isNotFound; i++)
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
