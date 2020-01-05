using System.Collections.Generic;
using LeedCode.Feature;

namespace LeedCode

{
//	Given a string which consists of lowercase or uppercase letters, find the length of the longest palindromes that can be built with those letters.

//	This is case sensitive, for example "Aa" is not considered a palindrome here.
	public class Amazon627LongestPalindromeLintCode: LeetCode
	{

		public int GetLongestPalindrome(string letter)
		{
			int longestPalindromeLength = 0;
			if (letter == null)
				return longestPalindromeLength;

			HashSet<char> charHashSet = new HashSet<char>();
			foreach (var charLetter in letter.ToCharArray())
			{
				if (charHashSet.Contains(charLetter))
				{
					charHashSet.Remove(charLetter);
					longestPalindromeLength += 2;
				}
				else
				{
					charHashSet.Add(charLetter);
				}
			}

			if (charHashSet.Count > 0)
				longestPalindromeLength++;

			return longestPalindromeLength;
		}

		public int GetLongestPalindrome1(string letter)
		{
			if (letter == null)
				return 0;
			HashSet<char> differentLetters = new HashSet<char>();
			int maxPalindromeLength = 0;
			foreach (var charLetter in letter.ToCharArray())
			{
				if (differentLetters.Contains(charLetter))
				{
					maxPalindromeLength += 2;
					differentLetters.Remove(charLetter);
				}
				else
				{
					differentLetters.Add(charLetter);
				}
			}

			if (differentLetters.Count != 0)
				maxPalindromeLength++;
			return maxPalindromeLength;
		}

		public int NumberLeetCode => 409;
		public string UrlLeetCode => "https://leetcode.com/problems/longest-palindrome/";
	}
}
