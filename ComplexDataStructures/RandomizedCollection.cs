using System;
using System.Collections.Generic;

namespace ComplexDataStructures
{
    public class RandomizedCollection
    {
        private readonly Dictionary<int, HashSet<int>> _indexMapper;
        private readonly List<int> _values;
        private readonly Random _random;
        /** Initialize your data structure here. */
        public RandomizedCollection()
        {
            _indexMapper = new Dictionary<int, HashSet<int>>();
            _values = new List<int>();
            _random = new Random();
        }

        /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
        public bool Insert(int val)
        {
            _values.Add(val);
            var retval = false;
            if (!_indexMapper.ContainsKey(val))
            {
                _indexMapper[val] = new HashSet<int>();
                retval = true;
            }
            _indexMapper[val].Add(_values.Count - 1);
            //Console.WriteLine(values[values.Count - 1]);
            return retval;
        }

        /** Removes a value from the set. Returns true if the set contained the specified element. */
        public bool Remove(int val)
        {
            if (!_indexMapper.ContainsKey(val))
                return false;
            var lastVal = _values[_values.Count - 1];
            if (lastVal != val)
            {
                var desiredIndices = _indexMapper[val];
                IEnumerator<int> e = desiredIndices.GetEnumerator();
                e.MoveNext();
                var index = e.Current;
                _indexMapper[lastVal].Add(index);
                _indexMapper[val].Remove(index);
                _indexMapper[lastVal].Remove(_values.Count - 1);
                _values[index] = lastVal;
            }
            else
            {
                _indexMapper[lastVal].Remove(_values.Count - 1);
            }
            if (_indexMapper[val].Count == 0)
                _indexMapper.Remove(val);
            _values.RemoveAt(_values.Count - 1);
            return true;
        }

        /** Get a random element from the set. */
        public int GetRandom()
        {
            //Console.WriteLine(values.Count);
            var randVal = _random.Next(_values.Count);
            //Console.WriteLine(randVal);
            return _values[randVal];
        }
    }

    /**
     * Your RandomizedCollection object will be instantiated and called as such:
     * RandomizedCollection obj = new RandomizedCollection();
     * bool param_1 = obj.Insert(val);
     * bool param_2 = obj.Remove(val);
     * int param_3 = obj.GetRandom();
     */
}
