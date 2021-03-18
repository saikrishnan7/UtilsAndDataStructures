using System;
using System.Collections.Generic;

namespace Problems
{
    public class LfuCache
    {
        private readonly int _capacity;
        private readonly Dictionary<int, LinkedListNode<Tuple<int, int, int>>> _dict;
        private readonly Dictionary<int, LinkedList<Tuple<int, int, int>>> _evictionTracker;
        private int _size;
        private int _minFreq;
        public LfuCache(int capacity)
        {
            this._capacity = capacity;
            _dict = new Dictionary<int, LinkedListNode<Tuple<int, int, int>>>();
            _evictionTracker = new Dictionary<int, LinkedList<Tuple<int, int, int>>>();
            _size = 0;
            _minFreq = 0;
        }

        public int Get(int key)
        {
            if (_size == 0 || !_dict.ContainsKey(key))
                return -1;
            var node = _dict[key];
            var count = node.Value.Item3;
            _evictionTracker[count].Remove(node);
            if (!_evictionTracker.ContainsKey(count + 1))
                _evictionTracker[count + 1] = new LinkedList<Tuple<int, int, int>>();
            _evictionTracker[count + 1].AddLast(node);
            _dict[key].Value = new Tuple<int, int, int>(key, node.Value.Item2, count + 1);
            while (_evictionTracker[_minFreq].Count == 0)
            {
                _minFreq++;
            }
            return _dict[key].Value.Item2;
        }

        public void Put(int key, int value)
        {
            if (_capacity > 0)
            {
                if (_size < _capacity || _dict.ContainsKey(key))
                {
                    if (!_dict.ContainsKey(key))
                    {
                        var tuple = new Tuple<int, int, int>(key, value, 1);
                        var node = new LinkedListNode<Tuple<int, int, int>>(tuple);
                        _dict.Add(key, node);
                        if (!_evictionTracker.ContainsKey(1))
                            _evictionTracker[1] = new LinkedList<Tuple<int, int, int>>();
                        _evictionTracker[1].AddLast(node);
                        _minFreq = 1;
                        _size++;
                    }
                    else
                    {
                        var node = _dict[key];
                        var count = node.Value.Item3;
                        _evictionTracker[count].Remove(node);
                        if (!_evictionTracker.ContainsKey(count + 1))
                            _evictionTracker[count + 1] = new LinkedList<Tuple<int, int, int>>();
                        _evictionTracker[count + 1].AddLast(node);
                        _dict[key].Value = new Tuple<int, int, int>(key, value, count + 1);
                    } 
                }
                else
                {
                    var nodeToBeRemoved = _evictionTracker[_minFreq].First;
                    Console.WriteLine(_minFreq);
                    _evictionTracker[_minFreq].RemoveFirst();
                    //Console.WriteLine(minFreq);
                    _dict.Remove(nodeToBeRemoved.Value.Item1);
                    _size--;
                    Put(key, value);
                }
                while (_evictionTracker[_minFreq].Count == 0)
                {
                    _minFreq++;
                }
            }
        }
    }
}
