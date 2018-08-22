using ComplexDataStructures;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Problems
{
    public class SampleProblems
    {
        public SampleProblems()
        {
        }

        public IList<IList<int>> ThreeSum(int[] nums)
        {
            Array.Sort(nums);
            var solutionSet = new HashSet<IList<int>>();
            int target = -1;
            for (int i = 0; i < nums.Length - 2; i++)
            {
                int j = i + 1;
                int k = nums.Length - 1;
                if (nums[i] <= 0 && i == 0 || i > 0 && nums[i] != nums[i - 1])
                {
                    while (j < k)
                    {
                        if (j > i + 1 && nums[j] == nums[j - 1])
                        {
                            j++;
                            continue;
                        }
                        else if (k < nums.Length - 1 && nums[k] == nums[k + 1])
                        {
                            k--;
                            continue;
                        }
                        target = nums[i] + nums[j] + nums[k];
                        if (target == 0)
                        {
                            IList<int> innerList = new List<int>();
                            innerList.Add(nums[i]);
                            innerList.Add(nums[j]);
                            innerList.Add(nums[k]);
                            solutionSet.Add(innerList);
                            j++;
                            k--;
                        }
                        else if (target < 0)
                        {
                            j++;
                        }
                        else
                        {
                            k--;
                        }
                    }
                }
            }
            return solutionSet.ToList();
        }

        public int HammingDistance(int x, int y)
        {
            int res = 0;
            for (int i = 0; i < 31 && !(x==0 && y==0); i++)
            {
                int xx = x % 2;
                int yy = y % 2;
                if (xx != yy)
                {
                    res++;
                }
                x = x / 2;
                y = y / 2;
            }
            return res;
        }
    }
}
