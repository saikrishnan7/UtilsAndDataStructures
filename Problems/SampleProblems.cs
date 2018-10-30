using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
                            IList<int> innerList = new List<int>
                            {
                                nums[i],
                                nums[j],
                                nums[k]
                            };
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
            for (int i = 0; i < 31 && !(x == 0 && y == 0); i++)
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

        public string ToLowerCase(string str)
        {
            StringBuilder replacement = new StringBuilder(str);
            for (int i = 0; i < str.Length; i++)
            {
                replacement[i] = str[i];
                if (str[i] >= 65 && str[i] <= 90)
                    replacement[i] = (char)(str[i] + 32);
            }
            return replacement.ToString();
        }

        public int PeakIndexInMountainArray(int[] A)
        {
            int peak = int.MinValue;
            for (int i = 0; i < A.Length - 1 && peak != i;)
            {
                if (A[i + 1] > A[i])
                    i++;
                else
                    peak = i;
            }
            return peak;
        }

        public int[][] Transpose(int[][] A)
        {
            int rows = A[0].Length;
            int columns = A.Length;
            int[][] transpose = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                transpose[i] = new int[columns];
            }
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    transpose[i][j] = A[j][i];
                }
            }
            return transpose;
        }

        public IList<string> SubdomainVisits(string[] cpdomains)
        {
            var outputList = new List<string>();
            Dictionary<string, int> visitCountMap = new Dictionary<string, int>();
            foreach (string cpdomain in cpdomains)
            {
                string[] subParts = cpdomain.Split('.');
                string[] domainSplit = cpdomain.Split(' ');
                visitCountMap.Add(domainSplit[1], int.Parse(domainSplit[0]));
                if (!visitCountMap.ContainsKey(subParts[subParts.Length - 1]))
                    visitCountMap.Add(subParts[subParts.Length - 1], int.Parse(domainSplit[0]));
                else
                    visitCountMap[subParts[subParts.Length - 1]] += int.Parse(domainSplit[0]);
                if (subParts.Length == 3)
                {
                    if (!visitCountMap.ContainsKey(subParts[subParts.Length - 2] + "." + subParts[subParts.Length - 1]))
                        visitCountMap.Add(subParts[subParts.Length - 2] + "." + subParts[subParts.Length - 1], int.Parse(domainSplit[0]));
                    else
                    {
                        visitCountMap[subParts[subParts.Length - 2] + "." + subParts[subParts.Length - 1]] += int.Parse(domainSplit[0]);
                    }
                }
            }
            foreach (string key in visitCountMap.Keys)
            {
                outputList.Add(visitCountMap[key] + " " + key);
            }
            return outputList;
        }

        public Tuple<int, int> GetBestBuySell(int[] a)
        {
            int minPrice = int.MaxValue;
            int maxProfit = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] < minPrice)
                    minPrice = a[i];
                if (a[i] - minPrice > maxProfit)
                    maxProfit = a[i] - minPrice;
            }
            return new Tuple<int, int>(minPrice, minPrice + maxProfit);
        }

        public List<Tuple<int, int>> MergeIntervals(List<Tuple<int, int>> intervals)
        {
            var merged = new List<Tuple<int, int>>();
            for (int i = 0; i < intervals.Count; i++)
            {
                if (merged.Count == 0 || (i > 0 && intervals[i].Item1 >= merged.Last().Item2))
                {
                    merged.Add(new Tuple<int, int>(intervals[i].Item1, intervals[i].Item2));

                }
                else if (intervals[i].Item2 > merged.Last().Item1)
                {
                    int currentMin = Math.Min(merged.Last().Item1, intervals[i].Item1);
                    int currentMax = Math.Max(merged.Last().Item2, intervals[i].Item2);
                    merged.RemoveAt(merged.Count - 1);
                    merged.Add(new Tuple<int, int>(currentMin, currentMax));
                }

            }
            return merged;
        }

        public bool IsValidTwoSum(int[] a, int v)
        {
            var dict = new Dictionary<int, int>();
            foreach (int num in a)
            {
                if (dict.ContainsKey(num))
                    dict[num]++;
                else
                {
                    dict.Add(num, 1);
                }
            }
            foreach (int num in a)
            {
                int searchKey = v - num;
                if (dict.ContainsKey(searchKey))
                {
                    return searchKey == num ? dict[searchKey] > 1 : true;
                }
            }
            return false;
        }

        public Tuple<int, int> GetMinMaxIndex(int[] a, int v)
        {
            return new Tuple<int, int>(GetLowIndex(a, v), GetHighIndex(a, v));
        }

        private int GetLowIndex(int[] a, int v)
        {
            int lo = 0;
            int hi = a.Length - 1;
            int mid = (lo + hi) / 2;
            while (lo <= hi)
            {
                if (a[mid] >= v)
                {
                    hi = mid - 1;
                }
                else
                {
                    lo = mid + 1;
                }
                if (a[lo] == v)
                    return lo;
                mid = (lo + hi) / 2;
            }
            return -1;
        }

        private int GetHighIndex(int[] a, int v)
        {
            int lo = 0;
            int hi = a.Length - 1;
            int mid = (lo + hi) / 2;
            while (lo <= hi)
            {
                if (a[mid] > v)
                {
                    hi = mid - 1;
                }
                else
                {
                    lo = mid + 1;
                }
                if (a[hi] == v)
                    return hi;
                mid = (lo + hi) / 2;
            }
            return -1;
        }


        public IList<string> LetterCombinations(string digits)
        {
            if (digits == "")
                return new List<string>();
            IList<string> result = new List<string>();
            Dictionary<char, char[]> phonePad = new Dictionary<char, char[]>
            {
                { '2', new char[] { 'a', 'b', 'c' } },
                { '3', new char[] { 'd', 'e', 'f' } },
                { '4', new char[] { 'g', 'h', 'i' } },
                { '5', new char[] { 'j', 'k', 'l' } },
                { '6', new char[] { 'm', 'n', 'o' } },
                { '7', new char[] { 'p', 'q', 'r', 's' } },
                { '8', new char[] { 't', 'u', 'v' } },
                { '9', new char[] { 'w', 'x', 'y', 'z' } }
            };
            return LetterCombinationHelper(phonePad, digits, result);

        }
        private IList<string> LetterCombinationHelper(Dictionary<char, char[]> phonePad, string digits, IList<string> result)
        {
            string sourceString = "";
            for (int i = 0; i < digits.Length; i++)
            {
                while (result.Count != i + 1)
                {
                    if (result.Count > 0)
                    {
                        sourceString = result[0];
                        result[0] = "";
                    }

                    foreach (char letter in phonePad[digits[i]])
                    {
                        result.Add(sourceString + letter);
                    }
                }

            }
            int resultCount = result.Count;
            return result;
        }

        public string CountAndSay(int n)
        {
            string[] outputArray = new string[n + 1];
            outputArray[0] = "1";
            for (int i = 1; i <= n; i++)
                outputArray[i] = GetStringRep(outputArray[i - 1]);
            return outputArray[n - 1];
        }
        private string GetStringRep(string inputString)
        {
            int countChar = 1;
            string finalString = "";
            if (inputString.Length == 1)
            {
                return "1" + inputString;
            }
            int i = 0;
            while (i < inputString.Length - 1)
            {
                while (inputString[i] == inputString[i + 1])
                {
                    countChar++;
                    i++;
                }
                finalString += countChar + "" + inputString[i];

            }
            return finalString;
        }
        public int StrStr(string haystack, string needle)
        {
            if (haystack.Length < needle.Length)
                return -1;
            if (needle == "")
                return 0;
            for (int i = 0; i < haystack.Length; i++)
            {
                if (needle[0] == haystack[i])
                {
                    int count = 0;
                    for (int j = 0, k = i; j < needle.Length && k < haystack.Length; j++, k++)
                    {
                        if (needle[j] == haystack[k])
                        {
                            count++;
                        }
                        else
                        {
                            i = j;
                            break;
                        }
                    }
                    if (count == needle.Length)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        public int TitleToNumber(string s)
        {
            int i = 0;
            double columnNumber = 0;

            for (int j = s.Length - 1; j >= 0; j--)
            {
                columnNumber += ((s[j] - 'A') + 1) * Math.Pow(26, i++);
            }
            return Convert.ToInt32(columnNumber);
        }
        public int CountSubstrings(string s)
        {
            List<string> strings = new List<string>();
            int length = s.Length;
            string[] numCombinations = new string[Convert.ToInt32(Math.Pow(2, length))];
            for (int i = 0; i < numCombinations.Length; i++)
            {
                numCombinations[i] = Convert.ToString(i, 2).PadLeft(length, '0');
            }
            foreach (string str in numCombinations)
            {
                StringBuilder sb = new StringBuilder();
                for (int j = 0; j < str.Length; j++)
                {
                    if (str[j] == '0')
                        sb.Append('\0');
                    if (str[j] == '1')
                        sb.Append(s[j]);
                }
                string stringToBeAdded = sb.ToString().Trim('\0');
                if (stringToBeAdded != "" && !stringToBeAdded.Contains("\0"))
                    strings.Add(stringToBeAdded);
            }
            int palindromicStrings = GetCountOfPalindromicStrings(strings);
            return palindromicStrings;
        }

        private int GetCountOfPalindromicStrings(List<string> strings)
        {
            int count = 0;
            foreach (string str in strings)
            {
                if (IsPalindrome(str))
                    count++;
            }
            return count;
        }

        private bool IsPalindrome(string s)
        {
            if (s.Length == 0 || s.Length == 1)
                return true;
            StringBuilder sb = new StringBuilder();
            foreach (char c in s)
            {
                if (char.IsLetterOrDigit(c))
                    sb.Append(c);
            }
            s = sb.ToString().ToLower();
            bool isPalindrome = true;
            for (int i = 0, j = s.Length - 1; i < s.Length / 2 && isPalindrome; i++, j--)
            {
                if (s[i] != s[j])
                {
                    isPalindrome = false;
                }
            }
            return isPalindrome;
        }
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            System.Collections.Generic.Queue<TreeNode> q = new System.Collections.Generic.Queue<TreeNode>();
            q.Enqueue(root);
            IList<IList<int>> output = new List<IList<int>>();
            while (q.Count != 0)
            {
                int size = q.Count;
                IList<int> intermediate = new List<int>();
                for (int i = 0; i < size; i++)
                {
                    if (q.Peek().left != null)
                        q.Enqueue(q.Peek().left);
                    if (q.Peek().right != null)
                        q.Enqueue(q.Peek().right);
                    intermediate.Add(q.Peek().val);
                    q.Dequeue();
                }
                output.Add(intermediate);
            }
            return output;
        }
        public int[] MoveZeroes(int[] a)
        {
            int zeroCount = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == 0)
                {
                    zeroCount++;
                }
            }
            int temp = zeroCount;
            for (int i = a.Length - 1, j = a.Length - 1; i >= 0; i--)
            {
                if (a[i] != 0)
                {
                    a[j] = a[i];
                    j--;
                }

            }
            for (int i = 0; i < temp; i++)
                a[i] = 0;
            return a;
        }
        public void QuickSort(int[] arr)
        {
            int lo = 0;
            int hi = arr.Length - 1;
            QuickSortHelper(arr, lo, hi);
        }

        public void QuickSortIterative(int[] arr)
        {
            int lo = 0;
            int hi = arr.Length - 1;
            var stack = new Stack<Tuple<int, int>>();
            stack.Push(new Tuple<int, int>(lo, hi));
            while (stack.Count != 0)
            {
                lo = stack.Peek().Item1;
                hi = stack.Peek().Item2;
                stack.Pop();
                int pivotIndex = Partition(arr, lo, hi);
                if (pivotIndex - 1 > lo)
                    stack.Push(new Tuple<int, int>(lo, pivotIndex - 1));
                if (pivotIndex + 1 < hi)
                    stack.Push(new Tuple<int, int>(pivotIndex + 1, hi));

            }
        }
        private void QuickSortHelper(int[] a, int lo, int hi)
        {
            if (lo < hi)
            {
                int pivotIndex = Partition(a, lo, hi);
                QuickSortHelper(a, lo, pivotIndex - 1);
                QuickSortHelper(a, pivotIndex + 1, hi);
            }
            return;
        }
        private int Partition(int[] a, int lo, int hi)
        {
            int pivot = a[hi];
            int i = lo;
            for (int j = lo; j < hi; j++)
            {
                if (a[j] < pivot)
                {
                    Swap(a, i, j);
                    i++;
                }
            }
            Swap(a, i, hi);
            return i;
        }
        private void Swap(int[] arr, int i, int j)
        {
            int temp = arr[j];
            arr[j] = arr[i];
            arr[i] = temp;
        }

        public void RotateArray(int[] a, int rotations)
        {
            if (rotations > a.Length)
                rotations = rotations % a.Length;
            if (rotations < 0)
                rotations = rotations + a.Length;
            Array.Reverse(a);
            Array.Reverse(a, 0, rotations);
            Array.Reverse(a, rotations, a.Length - rotations);
        }

        public HashSet<IList<int>> FindPythTriplets(int[] nums)
        {
            Array.Sort(nums);
            var solutionSet = new HashSet<IList<int>>();
            for (int i = 0; i < nums.Length - 2; i++)
            {
                int j = i + 1;
                int k = nums.Length - 1;

                if (i == 0 || i > 0 && nums[i] != nums[i - 1])
                {
                    int target = -1;
                    while (j < k && target <= 0)
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
                        int a2 = nums[i] * nums[i];
                        int b2 = nums[j] * nums[j];
                        int c2 = nums[k] * nums[k];
                        target = a2 + b2 + (-c2);
                        if (target == 0)
                        {
                            IList<int> innerList = new List<int>
                            {
                                nums[i],
                                nums[j],
                                nums[k]
                            };
                            solutionSet.Add(innerList);
                            j++;
                            k--;
                        }
                        else if (target < 0)
                        {
                            k--;
                        }
                    }
                }

            }
            return solutionSet;
        }

        public int IntegerDivision(int dividend, int divisor)
        {
            int sign = 1;
            if (divisor < 0 || dividend < 0)
            {
                if (divisor < 0)
                {
                    divisor = -divisor;
                    sign = -sign;
                }
                if (dividend < 0)
                {
                    dividend = -dividend;
                    sign = -sign;
                }
            }
            if (divisor == 1)
                return dividend * sign;
            else if (divisor == 0)
                return -1 * sign;
            else if (dividend == divisor)
                return 1 * sign;
            else if (dividend == 0)
                return 0;
            else if (dividend < divisor)
                return 0;
            else
            {
                int quotient = 1;
                int temp = divisor;
                while (temp < dividend)
                {
                    quotient <<= 1;
                    temp <<= 1;
                    if (temp > dividend)
                    {
                        temp >>= 1;
                        quotient >>= 1;
                        return sign * (quotient + IntegerDivision(dividend - temp, divisor));
                    }
                }
                return quotient * sign;
            }
        }
        public int IntegerDivisionIterative(int dividend, int divisor)
        {
            if (divisor == 1)
                return dividend;
            else if (divisor == 0)
                return -1;
            else if (dividend == divisor)
                return 1;
            else if (dividend == 0)
                return 0;
            else if (dividend < divisor)
                return 0;
            else
            {
                int temp = divisor;
                int quotient = 1;
                int retVal = 0;
                while (temp < dividend)
                {
                    temp <<= 1;
                    quotient <<= 1;
                    while (temp > dividend)
                    {
                        temp >>= 1;
                        quotient >>= 1;
                        retVal += quotient;
                        dividend -= temp;
                        if (temp == dividend)
                        {
                            return retVal;
                        }
                        temp = divisor;
                    }
                }
                return quotient;
            }
        }
        public int[] ProductOfAllButSelf(int[] a)
        {
            int temp = 1;
            int[] b = new int[a.Length];
            b[0] = 1;
            for (int i = 1; i < a.Length; i++)
            {
                temp *= a[i - 1];
                b[i] = temp;
            }
            temp = 1;
            for (int i = a.Length - 2; i >= 0; i--)
            {
                temp *= a[i + 1];
                b[i] *= temp;
            }
            return b;
        }
        public int[] CellCompete(int[] states, int days)
        {
            int prevState = -1;
            int nextState = 0;
            int[] nextStates = new int[states.Length];
            while (days > 0)
            {
                for (int i = 0; i < states.Length; i++)
                {
                    prevState = i == 0 ? 0 : states[i - 1];
                    nextState = i == states.Length - 1 ? 0 : states[i + 1];
                    nextStates[i] = prevState ^ nextState;
                }
                states = CopyNewStatesToStates(states, nextStates);
                days--;
            }
            return states;
        }

        private int[] CopyNewStatesToStates(int[] states, int[] nextStates)
        {
            for (int i = 0; i < states.Length; i++)
            {
                states[i] = nextStates[i];
            }
            return states;
        }
        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            var visited = new bool[wordList.Count];
            int transformationCount = 0;
            if (!wordList.Contains(endWord))
                return 0;
            else
            {
                if (beginWord.Length == 1 && endWord.Length == 1)
                    return 2;
                if (CheckIfOneCharAway(beginWord, endWord))
                    return 2;
                var q = new Queue<string>();
                q.Enqueue(beginWord);
                while (q.Count > 0)
                {
                    int size = q.Count;
                    transformationCount++;
                    for (int j = 0; j < size; j++)
                    {
                        string currWord = q.Dequeue();
                        for (int i = 0; i < wordList.Count; i++)
                        {
                            if (!visited[i])
                            {
                                string nextWord = wordList[i];
                                if (CheckIfOneCharAway(currWord, nextWord))
                                {
                                    if (nextWord == endWord)
                                        return transformationCount + 1;
                                    else
                                    {
                                        q.Enqueue(nextWord);
                                        visited[i] = true;
                                    }
                                }
                            }

                        }
                    }
                }
            }
            return 0;
        }

        public int CountIterative(int digit, int length)
        {
            var b = new List<List<int>>() { new List<int> { 4, 6 }, new List<int> { 6, 8 }, new List<int> { 7, 9 }, new List<int> { 4, 8 }, new List<int> { 0, 3, 9 }, new List<int> { }, new List<int> { 1, 7, 0 }, new List<int> { 2, 6 }, new List<int> { 1, 3 }, new List<int> { 2, 4 } };
            int[,] matrix = new int[length, 10];
            for (int dig = 0; dig <= 9; dig++)
            {
                matrix[0, dig] = 1;
            }
            for (int len = 1; len < length; len++)
            {
                for (int dig = 0; dig <= 9; dig++)
                {
                    int sum = 0;
                    foreach (int i in b[dig])
                    {
                        sum += matrix[len - 1, i];
                    }
                    matrix[len, dig] = sum;
                }
            }
            return matrix[length - 1, digit];
        }
        public int CountRecursive(int digit, int length)
        {
            var numberList = new List<string>(); 
            var dict = new Dictionary<char, List<char>>()
            {
                {'0', new List<char> { '4', '6' }},
                {'1', new List<char> { '6', '8' }},
                {'2', new List<char> { '7', '9' }},
                {'3', new List<char> { '4', '8' }},
                {'4', new List<char> { '0', '3', '9' }},
                {'5', new List<char> {}},
                {'6', new List<char> { '0', '1', '7' }},
                {'7', new List<char> { '2', '6' }},
                {'8', new List<char> { '1', '3'}},
                {'9', new List<char> {'2', '4' }}
            };
            return CountRecursiveHelper(dict, numberList, (char)(digit+'0'), length);
        }

        private int CountRecursiveHelper(Dictionary<char, List<char>> dict, List<string> numberList, char digit, int length, int i = 1, string sourceString = "6")
        {
            if(i == length)
            {
                numberList.Add(sourceString);
            }
            else
            {
                foreach(char c in dict[digit])
                {
                    CountRecursiveHelper(dict, numberList, c, length, i + 1, sourceString + c);
                }
            }
            return numberList.Count;
        }

        private bool CheckIfOneCharAway(string word1, string word2)
        {
            int mismatch = 0;
            for (int i = 0; i < word1.Length && mismatch < 2; i++)
            {
                if (word1[i] != word2[i])
                    mismatch++;
            }
            return mismatch == 1;
        }

        public IList<int> PartitionLabels(string s)
        {
            var output = new List<int>();
            int start = 1;
            bool noCharOnRight = true;
            int i = 0;
            string s1 = s[i].ToString();
            while (i < s.Length)
            {
                for (int j = 0; j < s1.Length && noCharOnRight; j++)
                {
                    if (s.Substring(start).Contains(s1[j]))
                    {
                        s1 += s[start];
                        noCharOnRight = false;
                    }
                    if (j == s1.Length - 1)
                    {
                        output.Add(s1.Length);
                        s1 = start < s.Length ? s[start].ToString() : "";
                    }
                }
                noCharOnRight = true;
                i++;
                start++;
            }
            return output;
        }
        public IList<int> PartitionLabelsAlternate(string s)
        {
            var output = new List<int>();
            for (int i = 0, j = s.Length - 1; i < s.Length;)
            {
                while (s[i] != s[j] && j > i)
                {
                    j--;
                }
                if (j != i && s[i] == s[j])
                {
                    output.Add((j - i) + 1);
                    i = j + 1;
                    j = s.Length - 1;
                }
                else if (i == j)
                {
                    output.Add(1);
                    i++;
                    j = s.Length - 1;
                }
            }
            return output;
        }
        public void Rotate(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    int temp = matrix[i, j];
                    matrix[i, j] = matrix[j, i];
                    matrix[j, i] = temp;
                }
            }
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols / 2; j++)
                {
                    int temp = matrix[i, j];
                    matrix[i, j] = matrix[i, cols - 1 - j];
                    matrix[i, cols - 1 - j] = temp;
                }
            }
        }
        public int Trap(int[,] height)
        {
            int final = 0;
            int[] ans = new int[height.GetLength(0)];
            for (int j = 0; j < height.GetLength(0); j++) {
                Stack<int> trap = new Stack<int>();
                int i = 1;
                trap.Push(0);
                while (i < height.GetLength(j))
                {
                    while (trap.Count != 0 && height[j,i] > height[j,trap.Peek()])
                    {
                        int top = trap.Pop();
                        if (trap.Count == 0)
                            break;
                        int distance = i - (trap.Peek() + 1);
                        int boundedHeight = Math.Min(height[j,i], height[j,trap.Peek()]) - height[j,top];
                        ans[j] += (distance * boundedHeight);
                    }
                    trap.Push(i++);
                }
            }
            foreach (int a in ans)
                final += a;
            return final;
        }
        public bool Exist(char[,] board, string word)
        {
            var rows = board.GetLength(0);
            var cols = board.GetLength(1);
            bool[,] visited = new bool[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (Exist(board, 0, i, j, rows, cols, visited, word))
                        return true;
                }
            }
            return false;
        }

        private bool Exist(char[,] board, int index, int r, int c, int rows, int cols, bool[,] visited, string word)
        {
            if (r < 0 || c < 0 || r >= rows || c >= cols || visited[r, c])
                return false;
            else
            {
                if (board[r, c] == word[index])
                {
                    if (index == word.Length - 1)
                        return true;
                    visited[r, c] = true;
                    return visited[r,c] = Exist(board, index + 1, r + 1, c, rows, cols, visited, word) || Exist(board, index + 1, r - 1, c, rows, cols, visited, word) || Exist(board, index + 1, r, c + 1, rows, cols, visited, word) || Exist(board, index + 1, r, c - 1, rows, cols, visited, word);
                }
            }
            return false;
        }
        public bool isSubtree(TreeNode s, TreeNode t)
        {
            string subTreeString = "";
            string treeString = "";
            TreeWalkHelper(ref subTreeString, t);
            TreeWalkHelper(ref treeString, s);
            return treeString.Contains(subTreeString);

        }
        private void TreeWalkHelper(ref string s, TreeNode curr)
        {
            if (curr == null)
                return;
            if (curr.left != null)
            {
                TreeWalkHelper(ref s, curr.left);
            }
            s += curr.val;
            if (curr.right != null)
            {
                TreeWalkHelper(ref s, curr.right);
            }
        }

        public bool IsMatch(string s, string p)
        {
            return IsMatch(s, p, 0, 0);
        }
        private bool IsMatch(string s, string p, int i, int j)
        {
            if (j == p.Length)
                return i == s.Length;
            if (p[j] != '*')
            {
                if (i < s.Length && p[j] == s[i] || p[j] == '?')
                {
                    return IsMatch(s, p, i + 1, j + 1);
                }
                return false;
            }
            else
            {
                i--;
                while (i < s.Length)
                {
                    if (IsMatch(s, p, i + 1, j + 1))
                    {
                        return true;
                    }
                    i++;
                }
            }
            return false;
        }
        public void ReverseWords(char[] str)
        {
            ReverseString(str, 0, str.Length - 1);
            int i = 0;
            int startIndex = 0, endIndex = 0;
            while (endIndex + 1 < str.Length)
            {
                if (str[endIndex + 1] != ' ' && endIndex + 2 != str.Length)
                    endIndex++;
                else
                {
                    endIndex = str[endIndex + 1] == ' ' ? endIndex : endIndex + 1;
                    ReverseString(str, startIndex, endIndex);
                    startIndex = endIndex + 2;
                    endIndex = startIndex;
                }
            }

        }
        private void ReverseString(char[] str, int startIndex, int endIndex)
        {
            int i = startIndex;
            int j = endIndex;
            while (j > i)
            {
                char temp = str[i];
                str[i] = str[j];
                str[j] = temp;
                j--;
                i++;
            }
        }
    }
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
}