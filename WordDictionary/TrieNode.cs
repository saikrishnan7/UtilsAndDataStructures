using System;
using System.Collections.Generic;
using System.Text;

namespace WordDictionary
{
    internal class TrieNode
    {
        internal bool IsWord { get; set; }
        
        internal string Word { get; set; }
        
        internal TrieNode()
        {
            Children = new Dictionary<char, TrieNode>();
        }

        internal Dictionary<char, TrieNode> Children { get; private set; }
    }
}
