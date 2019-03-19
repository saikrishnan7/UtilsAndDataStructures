using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexDataStructures
{
    public class RandomizedCollection
    {
        private Dictionary<int, HashSet<int>> indexMapper;
        private List<int> values;
        private Random random;
        /** Initialize your data structure here. */
        public RandomizedCollection()
        {
            indexMapper = new Dictionary<int, HashSet<int>>();
            values = new List<int>();
            random = new Random();
        }

        /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
        public bool Insert(int val)
        {
            values.Add(val);
            bool retval = false;
            if (!indexMapper.ContainsKey(val))
            {
                indexMapper[val] = new HashSet<int>();
                retval = true;
            }
            indexMapper[val].Add(values.Count - 1);
            //Console.WriteLine(values[values.Count - 1]);
            return retval;
        }

        /** Removes a value from the set. Returns true if the set contained the specified element. */
        public bool Remove(int val)
        {
            if (!indexMapper.ContainsKey(val))
                return false;
            int lastVal = values[values.Count - 1];
            if (lastVal != val)
            {
                var desiredIndices = indexMapper[val];
                IEnumerator<int> e = desiredIndices.GetEnumerator();
                e.MoveNext();
                int index = e.Current;
                indexMapper[lastVal].Add(index);
                indexMapper[val].Remove(index);
                indexMapper[lastVal].Remove(values.Count - 1);
                values[index] = lastVal;
            }
            else
            {
                indexMapper[lastVal].Remove(values.Count - 1);
            }
            if (indexMapper[val].Count == 0)
                indexMapper.Remove(val);
            values.RemoveAt(values.Count - 1);
            return true;
        }

        /** Get a random element from the set. */
        public int GetRandom()
        {
            //Console.WriteLine(values.Count);
            int randVal = random.Next(values.Count);
            //Console.WriteLine(randVal);
            return values[randVal];
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
