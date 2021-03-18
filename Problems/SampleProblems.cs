using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Problems
{
    public class SampleProblems
    {
        private const int Empty = int.MaxValue;
        private const int Gate = 0;
        private const int One = 1;
        private const int Zero = 0;
        private readonly List<int[]> _neighbours = new List<int[]>{
        new int[] {1, 0},
        new int[] {-1, 0},
        new int[] {0, 1},
        new int[] {0, -1}
        };

        private readonly bool _flag = false;
        public SampleProblems()
        {
        }

        public IList<IList<int>> ThreeSum(int[] nums)
        {
            Array.Sort(nums);
            var solutionSet = new HashSet<IList<int>>();
            for (var i = 0; i < nums.Length - 2; i++)
            {
                var j = i + 1;
                var k = nums.Length - 1;
                if (nums[i] <= 0 && i == 0 || i > 0 && nums[i] != nums[i - 1])
                {
                    while (j < k)
                    {
                        if (j > i + 1 && nums[j] == nums[j - 1])
                        {
                            j++;
                            continue;
                        }

                        if (k < nums.Length - 1 && nums[k] == nums[k + 1])
                        {
                            k--;
                            continue;
                        }
                        var target = nums[i] + nums[j] + nums[k];
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
            var res = 0;
            for (var i = 0; i < 31 && !(x == 0 && y == 0); i++)
            {
                var xx = x % 2;
                var yy = y % 2;
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
            var replacement = new StringBuilder(str);
            for (var i = 0; i < str.Length; i++)
            {
                replacement[i] = str[i];
                if (str[i] >= 65 && str[i] <= 90)
                    replacement[i] = (char)(str[i] + 32);
            }
            return replacement.ToString();
        }

        public int PeakIndexInMountainArray(int[] a)
        {
            var peak = int.MinValue;
            for (var i = 0; i < a.Length - 1 && peak != i;)
            {
                if (a[i + 1] > a[i])
                    i++;
                else
                    peak = i;
            }
            return peak;
        }

        public int[][] Transpose(int[][] a)
        {
            var rows = a[0].Length;
            var columns = a.Length;
            var transpose = new int[rows][];
            for (var i = 0; i < rows; i++)
            {
                transpose[i] = new int[columns];
            }
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    transpose[i][j] = a[j][i];
                }
            }
            return transpose;
        }

        public IList<string> SubdomainVisits(string[] cpdomains)
        {
            var outputList = new List<string>();
            var visitCountMap = new Dictionary<string, int>();
            foreach (var cpdomain in cpdomains)
            {
                var subParts = cpdomain.Split('.');
                var domainSplit = cpdomain.Split(' ');
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
            foreach (var key in visitCountMap.Keys)
            {
                outputList.Add(visitCountMap[key] + " " + key);
            }
            return outputList;
        }

        public Tuple<int, int> GetBestBuySell(int[] a)
        {
            var minPrice = int.MaxValue;
            var maxProfit = 0;
            for (var i = 0; i < a.Length; i++)
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
            for (var i = 0; i < intervals.Count; i++)
            {
                if (merged.Count == 0 || (i > 0 && intervals[i].Item1 >= merged.Last().Item2))
                {
                    merged.Add(new Tuple<int, int>(intervals[i].Item1, intervals[i].Item2));

                }
                else if (intervals[i].Item2 > merged.Last().Item1)
                {
                    var currentMin = Math.Min(merged.Last().Item1, intervals[i].Item1);
                    var currentMax = Math.Max(merged.Last().Item2, intervals[i].Item2);
                    merged.RemoveAt(merged.Count - 1);
                    merged.Add(new Tuple<int, int>(currentMin, currentMax));
                }

            }
            return merged;
        }

        public bool IsValidTwoSum(int[] a, int v)
        {
            var dict = new Dictionary<int, int>();
            foreach (var num in a)
            {
                if (dict.ContainsKey(num))
                    dict[num]++;
                else
                {
                    dict.Add(num, 1);
                }
            }
            foreach (var num in a)
            {
                var searchKey = v - num;
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
            var lo = 0;
            var hi = a.Length - 1;
            var mid = (lo + hi) / 2;
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
            var lo = 0;
            var hi = a.Length - 1;
            var mid = (lo + hi) / 2;
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
            var phonePad = new Dictionary<char, char[]>
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
            var sourceString = "";
            for (var i = 0; i < digits.Length; i++)
            {
                while (result.Count != i + 1)
                {
                    if (result.Count > 0)
                    {
                        sourceString = result[0];
                        result[0] = "";
                    }

                    foreach (var letter in phonePad[digits[i]])
                    {
                        result.Add(sourceString + letter);
                    }
                }

            }
            var resultCount = result.Count;
            return result;
        }

        public string CountAndSay(int n)
        {
            var outputArray = new string[n + 1];
            outputArray[0] = "1";
            for (var i = 1; i <= n; i++)
                outputArray[i] = GetStringRep(outputArray[i - 1]);
            return outputArray[n - 1];
        }
        private string GetStringRep(string inputString)
        {
            var countChar = 1;
            var finalString = "";
            if (inputString.Length == 1)
            {
                return "1" + inputString;
            }
            var i = 0;
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
            for (var i = 0; i < haystack.Length; i++)
            {
                if (needle[0] == haystack[i])
                {
                    var count = 0;
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
            var i = 0;
            double columnNumber = 0;

            for (var j = s.Length - 1; j >= 0; j--)
            {
                columnNumber += ((s[j] - 'A') + 1) * Math.Pow(26, i++);
            }
            return Convert.ToInt32(columnNumber);
        }
        public int CountSubstrings(string s)
        {
            var strings = new List<string>();
            var length = s.Length;
            var numCombinations = new string[Convert.ToInt32(Math.Pow(2, length))];
            for (var i = 0; i < numCombinations.Length; i++)
            {
                numCombinations[i] = Convert.ToString(i, 2).PadLeft(length, '0');
            }
            foreach (var str in numCombinations)
            {
                var sb = new StringBuilder();
                for (var j = 0; j < str.Length; j++)
                {
                    if (str[j] == '0')
                        sb.Append('\0');
                    if (str[j] == '1')
                        sb.Append(s[j]);
                }
                var stringToBeAdded = sb.ToString().Trim('\0');
                if (stringToBeAdded != "" && !stringToBeAdded.Contains("\0"))
                    strings.Add(stringToBeAdded);
            }
            var palindromicStrings = GetCountOfPalindromicStrings(strings);
            return palindromicStrings;
        }

        private int GetCountOfPalindromicStrings(List<string> strings)
        {
            var count = 0;
            foreach (var str in strings)
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
            var sb = new StringBuilder();
            foreach (var c in s)
            {
                if (char.IsLetterOrDigit(c))
                    sb.Append(c);
            }
            s = sb.ToString().ToLower();
            var isPalindrome = true;
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
            var q = new System.Collections.Generic.Queue<TreeNode>();
            q.Enqueue(root);
            IList<IList<int>> output = new List<IList<int>>();
            while (q.Count != 0)
            {
                var size = q.Count;
                IList<int> intermediate = new List<int>();
                for (var i = 0; i < size; i++)
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
            var zeroCount = 0;
            for (var i = 0; i < a.Length; i++)
            {
                if (a[i] == 0)
                {
                    zeroCount++;
                }
            }
            var temp = zeroCount;
            for (int i = a.Length - 1, j = a.Length - 1; i >= 0; i--)
            {
                if (a[i] != 0)
                {
                    a[j] = a[i];
                    j--;
                }

            }
            for (var i = 0; i < temp; i++)
                a[i] = 0;
            return a;
        }
        public void QuickSort(int[] arr)
        {
            var lo = 0;
            var hi = arr.Length - 1;
            QuickSortHelper(arr, lo, hi);
        }

        public void QuickSortIterative(int[] arr)
        {
            var lo = 0;
            var hi = arr.Length - 1;
            var stack = new Stack<Tuple<int, int>>();
            stack.Push(new Tuple<int, int>(lo, hi));
            while (stack.Count != 0)
            {
                lo = stack.Peek().Item1;
                hi = stack.Peek().Item2;
                stack.Pop();
                var pivotIndex = Partition(arr, lo, hi);
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
                var pivotIndex = Partition(a, lo, hi);
                QuickSortHelper(a, lo, pivotIndex - 1);
                QuickSortHelper(a, pivotIndex + 1, hi);
            }
            return;
        }
        private int Partition(int[] a, int lo, int hi)
        {
            var pivot = a[hi];
            var i = lo;
            for (var j = lo; j < hi; j++)
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
            var temp = arr[j];
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
            for (var i = 0; i < nums.Length - 2; i++)
            {
                var j = i + 1;
                var k = nums.Length - 1;

                if (i == 0 || i > 0 && nums[i] != nums[i - 1])
                {
                    var target = -1;
                    while (j < k && target <= 0)
                    {
                        if (j > i + 1 && nums[j] == nums[j - 1])
                        {
                            j++;
                            continue;
                        }

                        if (k < nums.Length - 1 && nums[k] == nums[k + 1])
                        {
                            k--;
                            continue;
                        }
                        var a2 = nums[i] * nums[i];
                        var b2 = nums[j] * nums[j];
                        var c2 = nums[k] * nums[k];
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
            var sign = 1;
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
            if (divisor == 0)
                return -1 * sign;
            if (dividend == divisor)
                return 1 * sign;
            if (dividend == 0)
                return 0;
            if (dividend < divisor)
                return 0;
            var quotient = 1;
            var temp = divisor;
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

        public int Divide(int dividend, int divisor)
        {
            long div = dividend;
            return DivideHelper(div, divisor);
        }

        private int DivideHelper(long dividend, int divisor)
        {
            var isNegative = false;
            if (divisor < 0)
            {
                isNegative = !isNegative;
                divisor = -divisor;
            }
            if (dividend == int.MinValue && divisor == 1)
            {
                return isNegative ? int.MaxValue : (int)dividend;
            }
            if (dividend < 0)
            {
                isNegative = !isNegative;
                dividend = -dividend;
            }
            if (divisor == 1)
                return isNegative ? -(int)dividend : (int)dividend;
            if (divisor > dividend || dividend == 0)
                return 0;
            long temp = divisor;
            long quotient = 1;
            while (dividend > temp)
            {
                temp <<= 1;
                quotient <<= 1;
                if (dividend < temp)
                {
                    temp >>= 1;
                    quotient >>= 1;
                    quotient = quotient + DivideHelper(dividend - temp, divisor);
                    break;
                }
            }
            return isNegative ? -(int)quotient : (int)quotient;
        }
        public int IntegerDivisionIterative(int dividend, int divisor)
        {
            if (divisor == 1)
                return dividend;
            if (divisor == 0)
                return -1;
            if (dividend == divisor)
                return 1;
            if (dividend == 0)
                return 0;
            if (dividend < divisor)
                return 0;
            var temp = divisor;
            var quotient = 1;
            var retVal = 0;
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
        public int[] ProductOfAllButSelf(int[] a)
        {
            var temp = 1;
            var b = new int[a.Length];
            b[0] = 1;
            for (var i = 1; i < a.Length; i++)
            {
                temp *= a[i - 1];
                b[i] = temp;
            }
            temp = 1;
            for (var i = a.Length - 2; i >= 0; i--)
            {
                temp *= a[i + 1];
                b[i] *= temp;
            }
            return b;
        }
        public int[] CellCompete(int[] states, int days)
        {
            var prevState = -1;
            var nextState = 0;
            var nextStates = new int[states.Length];
            while (days > 0)
            {
                for (var i = 0; i < states.Length; i++)
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
            for (var i = 0; i < states.Length; i++)
            {
                states[i] = nextStates[i];
            }
            return states;
        }
        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            var visited = new bool[wordList.Count];
            var transformationCount = 0;
            if (!wordList.Contains(endWord))
                return 0;
            if (beginWord.Length == 1 && endWord.Length == 1)
                return 2;
            if (CheckIfOneCharAway(beginWord, endWord))
                return 2;
            var q = new Queue<string>();
            q.Enqueue(beginWord);
            while (q.Count > 0)
            {
                var size = q.Count;
                transformationCount++;
                for (var j = 0; j < size; j++)
                {
                    var currWord = q.Dequeue();
                    for (var i = 0; i < wordList.Count; i++)
                    {
                        if (!visited[i])
                        {
                            var nextWord = wordList[i];
                            if (CheckIfOneCharAway(currWord, nextWord))
                            {
                                if (nextWord == endWord)
                                    return transformationCount + 1;
                                q.Enqueue(nextWord);
                                visited[i] = true;
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
            var matrix = new int[length, 10];
            for (var dig = 0; dig <= 9; dig++)
            {
                matrix[0, dig] = 1;
            }
            for (var len = 1; len < length; len++)
            {
                for (var dig = 0; dig <= 9; dig++)
                {
                    var sum = 0;
                    foreach (var i in b[dig])
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
            return CountRecursiveHelper(dict, numberList, (char)(digit + '0'), length);
        }

        private int CountRecursiveHelper(Dictionary<char, List<char>> dict, List<string> numberList, char digit, int length, string sourceString = "6")
        {
            if (length == 1)
            {
                numberList.Add(sourceString);
            }
            else
            {
                foreach (var c in dict[digit])
                {
                    CountRecursiveHelper(dict, numberList, c, length - 1, sourceString + c);
                }
            }
            return numberList.Count;
        }

        private bool CheckIfOneCharAway(string word1, string word2)
        {
            var mismatch = 0;
            for (var i = 0; i < word1.Length && mismatch < 2; i++)
            {
                if (word1[i] != word2[i])
                    mismatch++;
            }
            return mismatch == 1;
        }

        public IList<int> PartitionLabels(string s)
        {
            var output = new List<int>();
            var start = 1;
            var noCharOnRight = true;
            var i = 0;
            var s1 = s[i].ToString();
            while (i < s.Length)
            {
                for (var j = 0; j < s1.Length && noCharOnRight; j++)
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

        public IList<int> PartitionLabels2(string s)
        {
            if (s.Length == 0)
                return new List<int>();
            var output = new List<int>();
            var lastIndex = new int[26];
            for (var i = 0; i < s.Length; i++)
            {
                lastIndex[s[i] - 'a'] = i;
            }
            var anchor = 0;
            for (int j = 0, i = 0; j < s.Length; j++)
            {
                i = Math.Max(i, lastIndex[s[j] - 'a']);
                if (i == j)
                {
                    output.Add(j + 1 - anchor);
                    anchor = j + 1;
                }
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
            var rows = matrix.GetLength(0);
            var cols = matrix.GetLength(1);
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < cols; j++)
                {
                    var temp = matrix[i, j];
                    matrix[i, j] = matrix[j, i];
                    matrix[j, i] = temp;
                }
            }
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < cols / 2; j++)
                {
                    var temp = matrix[i, j];
                    matrix[i, j] = matrix[i, cols - 1 - j];
                    matrix[i, cols - 1 - j] = temp;
                }
            }
        }
        public int Trap(int[,] height)
        {
            var final = 0;
            var ans = new int[height.GetLength(0)];
            for (var j = 0; j < height.GetLength(0); j++)
            {
                var trap = new Stack<int>();
                var i = 1;
                trap.Push(0);
                while (i < height.GetLength(j))
                {
                    while (trap.Count != 0 && height[j, i] > height[j, trap.Peek()])
                    {
                        var top = trap.Pop();
                        if (trap.Count == 0)
                            break;
                        var distance = i - (trap.Peek() + 1);
                        var boundedHeight = Math.Min(height[j, i], height[j, trap.Peek()]) - height[j, top];
                        ans[j] += (distance * boundedHeight);
                    }
                    trap.Push(i++);
                }
            }
            foreach (var a in ans)
                final += a;
            return final;
        }
        public bool Exist(char[,] board, string word)
        {
            var rows = board.GetLength(0);
            var cols = board.GetLength(1);
            var visited = new bool[rows, cols];
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < cols; j++)
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
            if (board[r, c] == word[index])
            {
                if (index == word.Length - 1)
                    return true;
                visited[r, c] = true;
                return visited[r, c] = Exist(board, index + 1, r + 1, c, rows, cols, visited, word) || Exist(board, index + 1, r - 1, c, rows, cols, visited, word) || Exist(board, index + 1, r, c + 1, rows, cols, visited, word) || Exist(board, index + 1, r, c - 1, rows, cols, visited, word);
            }
            return false;
        }
        public bool IsSubtree(TreeNode s, TreeNode t)
        {
            var subTreeString = "";
            var treeString = "";
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

            i--;
            while (i < s.Length)
            {
                if (IsMatch(s, p, i + 1, j + 1))
                {
                    return true;
                }
                i++;
            }
            return false;
        }
        public void ReverseWords(char[] str)
        {
            ReverseString(str, 0, str.Length - 1);
            var i = 0;
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
            var i = startIndex;
            var j = endIndex;
            while (j > i)
            {
                var temp = str[i];
                str[i] = str[j];
                str[j] = temp;
                j--;
                i++;
            }
        }

        public string Multiply(string num1, string num2)
        {
            var num1Length = num1.Length - 1;
            var num2Length = num2.Length - 1;
            var result = new int[num1.Length + num2.Length];
            var kStart = result.Length - 1;
            var carry = 0;
            var i = num1.Length - 1;
            var j = num2.Length - 1;
            if ((num1.Length == 0 || num1 == "0") || (num2.Length == 0 || num2 == "0"))
                return "0";
            if (num1 == "1")
                return num2;
            if (num2 == "1")
                return num1;
            if (num1.Length == 1 && num2.Length == 1)
            {
                return ((num1[0] - '0') * (num2[0] - '0')).ToString();
            }
            while (j >= 0)
            {
                var k = kStart;
                while (i >= 0)
                {
                    var op1 = num1[i] - '0';
                    var op2 = num2[j] - '0';
                    var prod = op1 * op2 + carry;
                    var sum = result[k] + prod;
                    result[k] = (sum) % 10;
                    carry = sum / 10;
                    i--;
                    k--;
                }
                if (carry > 0)
                {
                    result[k] += carry;
                    carry = 0;
                }
                kStart--;
                j--;
                i = num1Length;
            }
            var sb = new StringBuilder();
            foreach (var num in result)
            {
                if (num != 0 || sb.Length > 0)
                {
                    sb.Append(num);
                }
            }
            return sb.ToString();
        }

        public bool AreAnagrams(int[] dict, string s1, string s2)
        {
            for (var i = 0; i < 26; i++)
                dict[i] = 0;
            foreach (var c in s1)
            {
                dict[c - 'a']++;
            }
            foreach (var c in s2)
            {
                dict[c - 'a']--;
            }
            var isAnagram = true;
            for (var i = 0; i < 26 && isAnagram; i++)
            {
                isAnagram = dict[i] == 0;
            }
            return isAnagram;
        }

        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var dict = new Dictionary<string, IList<string>>();
            foreach (var s in strs)
            {
                var ca = s.ToCharArray();
                Array.Sort(ca);
                var key = new string(ca);
                if (dict.ContainsKey(key))
                    dict[key].Add(s);
                else
                {
                    var list = new List<string>
                    {
                        s
                    };
                    dict.Add(key, list);
                }
            }
            var output = new List<IList<string>>();
            foreach (var val in dict.Values)
                output.Add(val);
            return output;
        }
        public IList<IList<int>> Subsets(int[] nums)
        {
            var output = new List<IList<int>>();
            var bitmask = 1;
            var count = 0;
            var total = (int)Math.Pow(2, nums.Length);
            for (var i = 0; i < total; i++)
            {
                var inner = new List<int>();
                var k = i;
                if (k > 0)
                {
                    while (k > 0)
                    {
                        if ((k & bitmask) == 1)
                        {
                            inner.Add(nums[count]);
                        }
                        count++;
                        k = k >> 1;
                    }
                }
                count = 0;
                output.Add(inner);
            }
            return output;
        }
        public int SearchHelper(int[] nums, int target, int lo, int hi)
        {
            var mid = lo + (hi - lo) / 2;
            if (hi >= lo)
            {
                if (nums[mid] == target)
                    return mid;
                if (nums[mid] > nums[lo])
                {
                    if (target >= nums[lo] && target < nums[mid])
                    {
                        return SearchHelper(nums, target, lo, mid - 1);
                    }

                    return SearchHelper(nums, target, mid + 1, hi);
                }

                if (nums[mid] < nums[lo])
                {
                    if (target <= nums[hi] && target > nums[mid])
                    {
                        return SearchHelper(nums, target, mid + 1, hi);
                    }

                    return SearchHelper(nums, target, lo, mid - 1);
                }
                return SearchHelper(nums, lo + 1, hi, target);
            }
            return -1;
        }
        public bool WordBreak(string s, IList<string> wordDict)
        {
            var wordDictSet = new HashSet<string>(wordDict);
            var memo = new bool[s.Length + 1];
            memo[0] = true;
            for (var end = 1; end <= s.Length; end++)
            {
                for (var j = 0; j < end; j++)
                {
                    if (memo[j] && wordDictSet.Contains(s.Substring(j, end - j)))
                    {
                        memo[end] = true;
                    }
                }
            }
            return memo[s.Length];
        }
        public IList<int[]> PacificAtlantic(int[,] matrix)
        {
            var rows = matrix.GetLength(0);
            var cols = matrix.GetLength(1);
            var visited = new bool[rows, cols];
            var ans = new List<int[]>();
            for (var r = 0; r < rows; r++)
            {
                for (var c = 0; c < cols; c++)
                {
                    if (Dfs(matrix, visited, r, c))
                        ans.Add(new int[2] { r, c });
                }
            }
            return ans;
        }

        private bool Dfs(int[,] matrix, bool[,] visited, int r, int c)
        {
            var rows = matrix.GetLength(0);
            var cols = matrix.GetLength(1);
            if (r < 0 || r >= rows || c < 0 || c >= cols || visited[r, c])
                return false;
            //visited[r, c] = true;
            if (r == 0 && c == cols - 1 || r == rows - 1 && c == 0 ||
               ((r + 1 < rows && matrix[r, c] > matrix[r + 1, c]) || (c + 1 < cols && matrix[r, c] > matrix[r, c + 1])) &&
               ((r > 0 && matrix[r, c] > matrix[r - 1, c]) || (c > 0 && matrix[r, c] > matrix[r, c - 1])))
                return true;
            visited[r, c] = true;
            return visited[r, c] = Dfs(matrix, visited, r + 1, c) || Dfs(matrix, visited, r, c + 1) || Dfs(matrix, visited, r - 1, c) || Dfs(matrix, visited, r, c - 1);
        }

        public int MinPathSum(int[,] grid)
        {
            var rows = grid.GetLength(0);
            var cols = grid.GetLength(0);
            var memo = new int[rows, cols];
            memo[0, 0] = grid[0, 0];
            for (var i = 1; i < rows; i++)
            {
                memo[i, 0] += grid[i - 1, 0];
            }
            for (var j = 1; j < cols; j++)
            {
                memo[0, j] += grid[0, j - 1];
            }
            for (var i = 1; i < rows; i++)
            {
                for (var j = 1; j < cols; j++)
                {
                    memo[i, j] = int.MaxValue;
                }
            }
            return MinPathSumHelper(grid, memo, rows - 1, cols - 1);
        }

        private int MinPathSumHelper(int[,] grid, int[,] memo, int r, int c)
        {
            if (r == 0 || c == 0)
            {
                return memo[r, c];
            }
            if (memo[r, c] != int.MaxValue)
                return memo[r, c];
            memo[r - 1, c] = grid[r - 1, c] + MinPathSumHelper(grid, memo, r - 1, c);
            memo[r, c - 1] = grid[r, c - 1] + MinPathSumHelper(grid, memo, r, c - 1);
            memo[r, c] = grid[r, c] + Math.Min(memo[r - 1, c], memo[r, c - 1]);
            return memo[r, c];
        }

        public int MinimumTotalBottomUp(IList<IList<int>> triangle)
        {
            var T = new List<IList<int>>();
            var i = 0;
            while (i < triangle.Count)
            {
                T.Add(new List<int>(triangle[i]));
                i++;
            }
            for (i = 0; i < T.Count - 1; i++)
            {
                for (var j = 0; j < T[i].Count; j++)
                {
                    T[i][j] = int.MaxValue;
                }
            }
            for (i = T.Count - 2; i >= 0; i--)
            {
                for (var j = 0; j < T[i].Count; j++)
                {
                    T[i][j] = triangle[i][j] + Math.Min(T[i + 1][j], T[i + 1][j + 1]);
                }
            }
            return T[0][0];
        }
        public int MinimumTotal(IList<IList<int>> triangle)
        {
            var memo = new List<IList<int>>();
            var i = 0;
            while (i < triangle.Count)
            {
                memo.Add(new List<int>(triangle[i]));
                i++;
            }
            for (i = 0; i < memo.Count - 1; i++)
            {
                for (var j = 0; j < memo[i].Count; j++)
                {
                    memo[i][j] = int.MaxValue;
                }
            }
            return MinimumTotalHelper(triangle, memo, 0, 0);
        }
        private int MinimumTotalHelper(IList<IList<int>> triangle, IList<IList<int>> memo, int outerIndex, int innerIndex)
        {
            if (outerIndex >= memo.Count || innerIndex >= memo[outerIndex].Count)
                return int.MaxValue;
            if (memo[outerIndex][innerIndex] != int.MaxValue)
            {
                return memo[outerIndex][innerIndex];
            }
            return memo[outerIndex][innerIndex] = triangle[outerIndex][innerIndex] + Math.Min(MinimumTotalHelper(triangle, memo, outerIndex + 1, innerIndex), MinimumTotalHelper(triangle, memo, outerIndex + 1, innerIndex + 1));
        }

        public IList<IList<int>> Permute(int[] nums)
        {
            var result = new List<IList<int>>();
            var isVisited = new bool[nums.Length];
            return Dfs(nums, isVisited, new List<int>(), result);
        }

        private IList<IList<int>> Dfs(int[] nums, bool[] isVisited, IList<int> oneResult, IList<IList<int>> result)
        {
            if (oneResult.Count == nums.Length)
                result.Add(new List<int>(oneResult));
            else
            {
                for (var i = 0; i < nums.Length; i++)
                {
                    if (!isVisited[i])
                    {
                        isVisited[i] = true;
                        oneResult.Add(nums[i]);
                        Dfs(nums, isVisited, oneResult, result);
                        oneResult.RemoveAt(oneResult.Count - 1);
                        isVisited[i] = false;
                    }
                }
            }
            return result;
        }

        public int CoinChangeRecursiveTopDown(int[] coins, int amount)
        {
            Array.Sort(coins);
            if (amount < 1 || coins[0] > amount)
            {
                if (amount < 1)
                    return 0;
                return -1;
            }
            var memo = new int[amount + 1];
            for (var i = 0; i <= amount; i++)
            {
                {
                    memo[i] = int.MaxValue;
                }
            }
            return CoinChangeRecursiveTopDownHelper(coins, memo, amount);
        }

        public int CoinChangeRecursiveTopDownHelper(int[] coins, int[] memo, int amount)
        {
            if (amount == -1)
                return -1;
            if (amount == 0)
                return 0;
            if (memo[amount] != int.MaxValue)
                return memo[amount];
            foreach (var coin in coins)
            {
                var ans = CoinChangeRecursiveTopDownHelper(coins, memo, amount - coin);
                memo[amount] = ans > -1 ? 1 + ans : -1;
            }
            return memo[amount] == int.MaxValue ? -1 : memo[amount];
        }

        public IList<IList<int>> GetFactors(int n)
        {
            var output = new List<IList<int>>();
            var inner = new List<int>();
            return GetFactorsHelper(output, inner, n, 2, n / 2, 1);
        }

        private IList<IList<int>> GetFactorsHelper(IList<IList<int>> output, List<int> inner, int n, int start, int end, int productSoFar)
        {
            for (var i = start; i <= end; i++)
            {
                if (n % i == 0 && n / i >= i)
                {
                    inner.Add(i);
                    inner.Add(n / i);
                    output.Add(new List<int>(inner));
                    inner.RemoveAt(inner.Count - 1);
                    GetFactorsHelper(output, inner, n / i, i, n / i * 2, productSoFar);
                    inner.RemoveAt(inner.Count - 1);
                }
            }
            return output;
        }

        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            Array.Sort(candidates);
            var output = CombinationSumHelper(new List<IList<int>>(), new List<int>(), candidates, target, 0, 0);
            var targetList = new List<IList<int>>();
            foreach (var list in output)
            {
                targetList.Add(new List<int>(list));
            }
            return targetList;
        }

        private IEnumerable<HashSet<int>> CombinationSumHelper(IList<IList<int>> output, List<int> inner, int[] candidates, int target, int start, int soFar)
        {
            if (soFar == target)
            {
                output.Add(new List<int>(inner));
            }
            else
            {
                for (var i = start; i < candidates.Length; i++)
                {
                    if (candidates[i] + soFar <= target)
                    {
                        inner.Add(candidates[i]);
                        CombinationSumHelper(output, inner, candidates, target, i, soFar + candidates[i]);
                        inner.RemoveAt(inner.Count - 1);
                    }
                    CombinationSumHelper(output, inner, candidates, target, i + 1, soFar);
                }
            }
            return output.Select(x => new HashSet<int>(x)).Distinct(HashSet<int>.CreateSetComparer());
        }

        private void Print(int n, int productSoFar, string v)
        {
            using (var sw = new StreamWriter(@"C:\Users\Saikrishnan_Srivatsa\Desktop\Sample_Output.txt", true))
            {
                sw.Write(v);
                sw.WriteLine("{" + n + ", " + productSoFar + "}");
                sw.Flush();
                sw.Close();
            }
        }

        public IList<string> RestoreIpAddresses(string s)
        {
            var output = new List<string>();
            if (s.Length > 12)
                return output;
            return IpAddressHelper(output, new List<string>(), 0, s);
        }

        private IList<string> IpAddressHelper(IList<string> output, IList<string> soFar, int start, string ip)
        {
            if (soFar.Count == 4 && start == ip.Length)
            {
                output.Add(string.Join(".", soFar));
            }
            else
            {
                for (var i = start; i <= start + 3; i++)
                {
                    if (i < ip.Length)
                    {
                        var s = ip.Substring(start, i - start + 1);
                        if ((!s.StartsWith("0") || s.StartsWith("0") && s.Length < 2) && int.Parse(s) < 256)
                        {
                            soFar.Add(s);
                            IpAddressHelper(output, soFar, i + 1, ip);
                            soFar.RemoveAt(soFar.Count - 1);
                        }
                    }
                }
            }
            return output;
        }

        private bool IsValidIp(string ipAddress)
        {
            Console.WriteLine(ipAddress);
            foreach (var ip in ipAddress.Split('.'))
            {
                Console.WriteLine(ip);
                if (int.Parse(ip) > 255 || int.Parse(ip) < 0)
                    return false;
            }
            return true;
        }

        public IList<string> RemoveInvalidParentheses(string s)
        {
            IList<string> result = new List<string>();
            Remove(s, result, 0, 0, new char[] { '(', ')' });
            return result;
        }

        public IList<string> RemoveInvalidParenthesesIi(string s)
        {
            var result = new HashSet<string>();
            var visited = new HashSet<string>();
            var thisStringVisited = false;
            var q = new Queue<string>();
            q.Enqueue(s);
            visited.Add(s);
            while (q.Count != 0)
            {
                var top = q.Dequeue();
                if (IsValid(top))
                {
                    thisStringVisited = true;
                    if (!result.Contains(top))
                    {
                        result.Add(top);
                    }
                }
                if (!thisStringVisited)
                {
                    for (var i = 0; i < top.Length; i++)
                    {
                        if (top[i] == ')' || top[i] == '(')
                        {
                            var t = Substr(top, 0, i) + Substr(top, i + 1, top.Length);
                            if (!visited.Contains(t))
                            {
                                q.Enqueue(t);
                                visited.Add(t);
                            }
                        }
                    }
                }
            }
            return new List<string>(result);
        }
        private bool IsValid(string s)
        {
            var tracker = 0;
            for (var i = 0; i < s.Length && tracker > -1; i++)
            {
                if (s[i] == '(')
                    tracker++;
                else if (s[i] == ')')
                    tracker--;
            }
            return tracker == 0;
        }

        private void Remove(string s, IList<string> result, int lastI, int lastJ, char[] par)
        {
            for (int stack = 0, i = lastI; i < s.Length; ++i)
            {
                if (s[i] == par[0]) stack++;
                if (s[i] == par[1]) stack--;
                if (stack < 0)
                {
                    for (var j = lastJ; j <= i; ++j)
                    {
                        if (s[j] == par[1] && (j == lastJ || s[j - 1] != par[1]))
                        {
                            Remove(Substr(s, 0, j) + Substr(s, j + 1, s.Length), result, i, j, par);
                        }
                    }
                    return;
                }
            }
            var charArray = s.ToCharArray();
            Array.Reverse(charArray);
            var reversed = new string(charArray);
            if (par[0] == '(') // finished left to right
                Remove(reversed, result, 0, 0, new char[] { ')', '(' });
            else // finished right to left
                result.Add(reversed);
        }

        private string Substr(string s, int begin, int end)
        {
            return s.Substring(begin, end - begin);
        }

        public IList<string> GetAllValidExpressions(string num)
        {
            var finalResult = new List<string>();
            return GetAllValidExpressionsHelper(finalResult, "", num, 0);
        }

        private IList<string> GetAllValidExpressionsHelper(List<string> finalResult, string temp, string num, int startIndex)
        {
            if (startIndex == num.Length)
                finalResult.Add(temp);
            else
            {
                GetAllValidExpressionsHelper(finalResult, temp + num[startIndex], num, startIndex + 1);
                if (startIndex + 1 < num.Length)
                    GetAllValidExpressionsHelper(finalResult, temp + num[startIndex] + '+', num, startIndex + 1);
            }
            return finalResult;
        }

        public IList<int> GrayCode(int n)
        {
            var result = new List<IList<int>>();
            var temp = new List<int>();
            var visited = new bool[1 << n];
            temp.Add(0);
            if (n == 1)
            {
                temp.Add(1);
                return new List<int>(temp);
            }
            visited[0] = true;
            return GrayCodeHelper(result, temp, visited, n, 0)[0];
        }

        private IList<IList<int>> GrayCodeHelper(IList<IList<int>> result, List<int> temp, bool[] visited, int n, int lastVisited)
        {
            if (result.Count == 1)
                return result;
            if (temp.Count == 1 << n)
            {
                result.Add(new List<int>(temp));
            }
            else
            {
                for (var i = 0; i < n; i++)
                {
                    var next = lastVisited ^ (1 << i);
                    if (!visited[next])
                    {
                        temp.Add(next);
                        visited[next] = true;
                        GrayCodeHelper(result, temp, visited, n, next);
                        visited[next] = false;
                        temp.RemoveAt(temp.Count - 1);
                    }
                }
            }
            return result;
        }

        public bool DifferAtOneBitPos(int a, int b)
        {
            return IsPowerOfTwo(a ^ b);
        }

        private bool IsPowerOfTwo(int x)
        {
            // First x in the below expression is 
            // for the case when x is 0 
            return x != 0 && (x & (x - 1)) == 0;
        }
        public IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            Array.Sort(nums);
            var temp = new List<int>();
            var list = new List<int>(nums);
            var result = new List<IList<int>>();
            Backtrack(result, temp, list);
            return result;
        }

        private void Backtrack(IList<IList<int>> result, IList<int> temp, IList<int> list)
        {
            if (list.Count == 0)
                result.Add(new List<int>(temp));
            else
            {
                var num = list[0];
                list.RemoveAt(0);
                temp.Add(num);
                Backtrack(result, temp, list);
                temp.RemoveAt(temp.Count - 1);
                while (list.Count > 0 && list[0] == list[1])
                {
                    list.RemoveAt(0);
                }
                Backtrack(result, temp, list);
                list.Insert(0, num);
            }
        }

        public string GetPermutation(int n, int k)
        {
            var sb = new StringBuilder();
            var numbers = new List<int>();
            for (var i = 1; i <= n; i++)
            {
                numbers.Add(i);
            }
            var fact = 1;
            var facts = new List<int>
            {
                1
            };
            for (var i = 1; i <= n; i++)
            {
                fact *= i;
                facts.Add(fact);
            }
            k--;
            for (var i = 1; i <= n; i++)
            {
                var index = k / facts[n - i];
                sb.Append(numbers[index]);
                numbers.RemoveAt(index);
                k = k - (index * facts[n - i]);
            }
            return sb.ToString();
        }

        public void NextPermutation(int[] nums)
        {
            var lastIndex = nums.Length - 1;
            for (int j = lastIndex - 1, i = lastIndex; j >= 0; i--, j--)
            {
                if (nums[j] < nums[i])
                {
                    var numToBeSwapped = nums[j];
                    var k = i;
                    for (; k <= lastIndex && nums[k] > numToBeSwapped; k++)
                    {
                        numToBeSwapped = Math.Min(numToBeSwapped, nums[k]);
                    }
                    Swap(nums, j, k - 1);
                    Reverse(nums, j + 1, lastIndex);
                    break;
                }
            }
        }

        private void Reverse(int[] nums, int i, int j)
        {
            while (i < j)
            {
                Swap(nums, i, j);
                i++;
                j--;
            }
        }

        public IList<int> TopKFrequent(int[] nums, int k)
        {
            var dict = new Dictionary<int, int>();
            var heap = new SortedList<int, int>(Comparer<int>.Create((v1, v2) => { var comp = dict[v1].CompareTo(dict[v2]); if (comp == 0) return v1.CompareTo(v2);
                return comp;
            }));
            var output = new List<int>();
            foreach (var num in nums)
            {
                if (!dict.ContainsKey(num))
                {
                    dict.Add(num, 0);
                }
                dict[num]++;
            }

            foreach (var key in dict.Keys)
            {
                heap.Add(key, dict[key]);
            }

            while (k > 0)
            {
                var val = heap.Keys[heap.Count - 1];
                k--;
                heap.RemoveAt(heap.Count - 1);
                output.Add(val);
            }
            return output;
        }

        public IList<int> FindClosestElements(int[] array, int k, int x)
        {
            var arr = new List<int>(array);
            arr.Sort(new CustomIntComparer(x));
            arr = arr.GetRange(array.Length - k, k);
            arr.Sort();
            return arr;
        }
        public int Solution(string s)
        {
            char[] delimiterChars = { '.', '?', '!' };
            var sentenceBits = s.Split(delimiterChars);
            var maxLength = int.MinValue;
            foreach (var bits in sentenceBits)
            {
                Console.WriteLine(bits);
                if (bits.Trim().Length != 0)
                {
                    var inner = bits.Trim().Split(' ');
                    maxLength = Math.Max(maxLength, inner.Length);
                }
            }
            return maxLength;
        }

        public string LongestPalindrome(string s)
        {
            if (s.Length == 0 || s.Length == 1)
                return s;
            var start = 0;
            var end = 0;
            var longestPalindrome = "";
            while (s.Length - end > longestPalindrome.Length)
            {
                var current = s.Substring(start, end - start + 1);
                if (current.Length >= longestPalindrome.Length)
                {
                    if (IsPalindrome(current, 0, current.Length - 1))
                    {
                        longestPalindrome = current.Length > longestPalindrome.Length ? current : longestPalindrome;
                        if (start > 0)
                            start--;
                        end++;
                    }
                    else
                    {
                        start++;
                    }
                }
            }
            return longestPalindrome;
        }
        private bool IsPalindrome(string s, int start, int end)
        {
            while (start < end)
            {
                if (s[start] != s[end])
                    return false;
                start++;
                end--;
            }
            return true;
        }

        public IList<IList<string>> SolveNQueens(int n)
        {
            var outer = new List<IList<string>>();
            var inner = new List<string>();
            for (var k = 0; k < n; k++)
            {
                for (var i = 0; i < n; i++)
                {
                    inner.Add(".");
                }
                outer.Add(new List<string>(inner));
            }
            QueensHelper(outer, 0, n - 1);
            return outer;
        }

        private void QueensHelper(IList<IList<string>> outer, int columnNumber, int rows)
        {
            if (columnNumber == rows)
                return;
            for (var i = 0; i < rows; i++)
            {
                if (IsSafe(outer, rows, columnNumber))
                {
                    outer[i][columnNumber] = "Q";
                    QueensHelper(outer, columnNumber + 1, rows);
                    outer[i][columnNumber] = ".";
                }
            }
        }

        private bool IsSafe(IList<IList<string>> outer, int r, int c)
        {
            outer[r][c] = "Q";
            var unSafe = false;
            for (var i = 0; i < outer.Count && !unSafe; i++)
            {
                var counter = 0;
                for (var j = 0; j < outer[i].Count && !unSafe; j++)
                {
                    if (outer[i][j] == "Q")
                        counter++;
                    if (counter > 1)
                        unSafe = true;
                }
            }

            for (var i = 0; i < outer.Count && !unSafe; i++)
            {
                var counter = 0;
                for (var j = 0; j < outer[i].Count && !unSafe; j++)
                {
                    if (outer[j][i] == "Q")
                        counter++;
                    if (counter > 1)
                        unSafe = true;
                }
            }

            for (int i = 0, j = 0, counter = 0; i < outer.Count && !unSafe; i++, j++)
            {
                if (outer[i][j] == "Q")
                    counter++;
                if (counter > 1)
                    unSafe = true;
            }

            for (int i = 0, j = outer.Count - 1, counter = 0; i < outer.Count && !unSafe; i++, j--)
            {
                if (outer[i][j] == "Q")
                    counter++;
                if (counter > 1)
                    unSafe = true;
            }
            outer[r][c] = ".";
            return unSafe;
        }

        public void WallsAndGates(int[,] rooms)
        {
            var q = new Queue<Coordinates>();
            for (var r = 0; r < rooms.GetLength(0); r++)
            {
                for (var c = 0; c < rooms.GetLength(1); c++)
                {
                    if (rooms[r, c] == Gate)
                    {
                        q.Enqueue(new Coordinates(r, c));
                    }
                }
            }

            while (q.Count != 0)
            {
                var current = q.Dequeue();
                foreach (var neighbour in _neighbours)
                {
                    var r = current.x + neighbour[0];
                    var c = current.y + neighbour[1];
                    if (r < 0 || c < 0 || r >= rooms.GetLength(0) || c >= rooms.GetLength(1) || rooms[r, c] != Empty)
                        continue;
                    rooms[r, c] = rooms[current.x, current.y] + 1;
                    q.Enqueue(new Coordinates(r, c));
                }
            }
        }

        public int[,] UpdateMatrix(int[,] matrix)
        {
            var q = new Queue<Coordinates>();
            var dist = new int[matrix.GetLength(0), matrix.GetLength(1)];
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == Zero)
                    {
                        dist[i, j] = 0;
                        q.Enqueue(new Coordinates(i, j));
                    }
                    else
                    {
                        dist[i, j] = int.MaxValue;
                    }
                }
            }
            while (q.Count != 0)
            {
                var current = q.Dequeue();
                foreach (var neighbor in _neighbours)
                {
                    var r = current.x + neighbor[0];
                    var c = current.y + neighbor[1];
                    if (r < 0 || c < 0 || r >= matrix.GetLength(0) || c >= matrix.GetLength(1) || dist[r, c] == Zero)
                        continue;
                    if (dist[r, c] > dist[current.x, current.y] + 1)
                    {
                        dist[r, c] = dist[current.x, current.y] + 1;
                        q.Enqueue(new Coordinates(r, c));
                    }
                }
            }
            return dist;
        }
        public IList<IList<string>> Partition(string s)
        {
            var output = new List<IList<string>>();
            PartitionHelper(output, new List<string>(), s, 0, s.Length);
            return output;
        }

        private void PartitionHelper(List<IList<string>> output, IList<string> temp, string s, int start, int end)
        {
            if (start == end)
            {
                output.Add(new List<string>(temp));
            }
            else
            {
                for (var i = start; i < end; i++)
                {
                    if (IsPalindrome(s, start, i, 0))
                    {
                        if (start == i)
                            temp.Add(s[i].ToString());
                        else
                            temp.Add(s.Substring(start, i + 1 - start));
                        PartitionHelper(output, temp, s, start + 1, end);
                        temp.RemoveAt(temp.Count - 1);
                    }
                }
            }
        }

        private bool IsPalindrome(string s, int start, int end, int zebu = 0)
        {
            while (end > start)
            {
                if (s[start] != s[end])
                    return false;
                end--;
                start++;
            }
            return true;
        }

        public IList<string> FindItinerary(string[,] tickets)
        {
            var dict = new Dictionary<string, SortedSet<string>>();
            var result = new List<string>();
    
            for (var i = 0; i < tickets.GetLength(0); i++)
            {
                if (!dict.ContainsKey(tickets[i, 0]))
                {
                    dict.Add(tickets[i, 0], new SortedSet<string>());
                }
                dict[tickets[i, 0]].Add(tickets[i, 1]);
            }

            Reconstruct("JFK", dict, result);
            result.Reverse();
            return result;
        }

        private void Reconstruct(string origin, Dictionary<string, SortedSet<string>> dict, List<string> result)
        {
            if (dict.ContainsKey(origin))
            {
                result.Add(origin);
                var arrivals = dict[origin];
                while (arrivals != null && arrivals.Count > 0)
                {
                    var next = arrivals.Min;
                    arrivals.Remove(arrivals.Min);
                    Reconstruct(next, dict, result);
                }
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

    public class CustomIntComparer : IComparer<int>
    {
        private readonly int _x;
        public CustomIntComparer(int target)
        {
            _x = target;
        }
        public int Compare(int num1, int num2)
        {
            return num1 == num2 ? num1 - num2 : Math.Abs(num1 - _x) - Math.Abs(num2 - _x);
        }
    }

    public class Coordinates
    {
        public int x;
        public int y;

        public Coordinates(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}