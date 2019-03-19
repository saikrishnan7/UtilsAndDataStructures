using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problems
{
    public class LFUCache
    {
        private readonly int capacity;
        private Dictionary<int, LinkedListNode<Tuple<int, int, int>>> dict;
        private Dictionary<int, LinkedList<Tuple<int, int, int>>> evictionTracker;
        private int size;
        private int minFreq;
        public LFUCache(int capacity)
        {
            this.capacity = capacity;
            dict = new Dictionary<int, LinkedListNode<Tuple<int, int, int>>>();
            evictionTracker = new Dictionary<int, LinkedList<Tuple<int, int, int>>>();
            size = 0;
            minFreq = 0;
        }

        public int Get(int key)
        {
            if (size == 0 || !dict.ContainsKey(key))
                return -1;
            else
            {
                var node = dict[key];
                int count = node.Value.Item3;
                evictionTracker[count].Remove(node);
                if (!evictionTracker.ContainsKey(count + 1))
                    evictionTracker[count + 1] = new LinkedList<Tuple<int, int, int>>();
                evictionTracker[count + 1].AddLast(node);
                dict[key].Value = new Tuple<int, int, int>(key, node.Value.Item2, count + 1);
                while (evictionTracker[minFreq].Count == 0)
                {
                    minFreq++;
                }
                return dict[key].Value.Item2;
            }
        }

        public void Put(int key, int value)
        {
            if (capacity > 0)
            {
                if (size < capacity || dict.ContainsKey(key))
                {
                    if (!dict.ContainsKey(key))
                    {
                        var tuple = new Tuple<int, int, int>(key, value, 1);
                        var node = new LinkedListNode<Tuple<int, int, int>>(tuple);
                        dict.Add(key, node);
                        if (!evictionTracker.ContainsKey(1))
                            evictionTracker[1] = new LinkedList<Tuple<int, int, int>>();
                        evictionTracker[1].AddLast(node);
                        minFreq = 1;
                        size++;
                    }
                    else
                    {
                        var node = dict[key];
                        int count = node.Value.Item3;
                        evictionTracker[count].Remove(node);
                        if (!evictionTracker.ContainsKey(count + 1))
                            evictionTracker[count + 1] = new LinkedList<Tuple<int, int, int>>();
                        evictionTracker[count + 1].AddLast(node);
                        dict[key].Value = new Tuple<int, int, int>(key, value, count + 1);
                    } 
                }
                else
                {
                    var nodeToBeRemoved = evictionTracker[minFreq].First;
                    Console.WriteLine(minFreq);
                    evictionTracker[minFreq].RemoveFirst();
                    //Console.WriteLine(minFreq);
                    dict.Remove(nodeToBeRemoved.Value.Item1);
                    size--;
                    Put(key, value);
                }
                while (evictionTracker[minFreq].Count == 0)
                {
                    minFreq++;
                }
            }
        }
    }
}
