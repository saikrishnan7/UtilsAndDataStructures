using System;
using System.Collections.Generic;
using System.Text;

namespace WordDictionary
{
    public class LetterCombinationsOfAPhoneNumber
    {
        private Dictionary<char, string> keyPad;

        public LetterCombinationsOfAPhoneNumber()
        {
            keyPad = new Dictionary<char, string>
            {
                { '2', "abc" },
                { '3', "def" },
                { '4', "ghi" },
                { '5', "jkl" },
                { '6', "mno" },
                { '7', "pqrs" },
                { '8', "tuv" },
                { '9', "wxyz" }
            };
        }

        public IList<string> GetLetterCombinations(string digits)
        {
            var list = new List<string>();
            if (digits.Length == 0)
                return list;
            LetterCombinationHelper(digits, list);
            return list;
        }

        public void LetterCombinationHelper(string digits, IList<string> result, int currentIndex = 0, string currentString = "")
        {
            if (currentIndex == digits.Length)
            {
                result.Add(currentString);
            }
            else
            {
                foreach (var c in keyPad[digits[currentIndex]])
                {
                     LetterCombinationHelper(digits, result, currentIndex + 1, currentString + c); //explore
                }
            }
        }
    }
}
