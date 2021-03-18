using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordDictionary
{
    internal class Trie
    {
        private readonly TrieNode _rootNode;

        internal Trie()
        {
            _rootNode = new TrieNode();
        }
        
        internal int Count { get; private set; }

        internal void InsertWord(string word)
        {
            var currentNode = _rootNode;
            foreach (var c in word)
            {
                TrieNode tempNode;
                if (!currentNode.Children.ContainsKey(c))
                {
                    tempNode = new TrieNode();
                    currentNode.Children.Add(c, tempNode);
                }
                else
                {
                    tempNode = currentNode.Children[c];
                }
                currentNode = tempNode;
            }

            currentNode.IsWord = true;
            currentNode.Word = word;
            Count++;
        }

        internal bool SearchWord(string word)
        {
            var result = SearchHelper(word);
            return result != null && result.IsWord;
        }

        internal bool StartsWithPrefix(string prefix)
        {
            var result = SearchHelper(prefix);
            return result != null;
        }

        private TrieNode SearchHelper(string word)
        {
            var currentNode = _rootNode;
            foreach (var c in word)
            {
                TrieNode tempNode;
                if (!currentNode.Children.ContainsKey(c))
                {
                    return null;
                }

                tempNode = currentNode.Children[c];

                currentNode = tempNode;
            }

            return currentNode;
        }

        internal bool SearchWordInNode(string word, TrieNode node)
        {
            for (var i = 0; i < word.Length; i++)
            {
                if (!node.Children.ContainsKey(word[i]))
                {
                    if (word[i] == '.')
                    {
                        if (node.Children.Keys.Any(child => SearchWordInNode(word[(i + 1)..], node.Children[child])))
                        {
                            return true;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    node = node.Children[word[i]];
                }
            }

            return node.IsWord;
        }
    }
}
