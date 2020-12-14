using LeedCode.AFeature;
using System;
using System.Collections.Generic;

namespace LeedCode.DFS
{
	public class LeetCode131PalindromePartitioning : LeetCode
	{
		public int NumberLeetCode => 131;

		public string UrlLeetCode => "https://leetcode.com/problems/palindrome-partitioning/";

		
		public IList<IList<string>> Partition(string s)
		{
			if (string.IsNullOrEmpty(s))
			{
				return new List<IList<string>>();
			}

			var result = new List<IList<string>>();

			var currentList = new List<string>();

			Dictionary<string, bool> _cache = new Dictionary<string, bool>();
			GetPartitionHelper(s, result, currentList, 0, _cache);
			return result;
		}

		// FIRST ERROR: should remove the for for the index, but only for for the length of characters selected;
		private void GetPartitionHelper(string s, List<IList<string>> result, List<string> currentList, int beginIndex, Dictionary<string, bool> cache)
		{
			if (beginIndex == s.Length)
			{
				result.Add(new List<string>(currentList));
				return;
			}


			for (int j = 1; j <= s.Length - beginIndex; j++)
			{
				var currentString = s.Substring(beginIndex, j);
				if ((cache.ContainsKey(currentString) && cache[currentString]) || IsPalindrome(currentString))
				{
					if (!cache.ContainsKey(currentString))
						cache.Add(currentString, true);
					currentList.Add(currentString);
					GetPartitionHelper(s, result, currentList, beginIndex + j, cache);
					currentList.RemoveAt(currentList.Count - 1);
				}
				else
				{
					if (!cache.ContainsKey(currentString))
						cache.Add(currentString, false);
					// second error: should not break here
					//break;
				}
			}


		}

		private bool IsPalindrome(string currentString)
		{
			if (currentString.Length == 1)
				return true;

			int middleIndex = currentString.Length / 2;
			for (int i = 0; i < middleIndex; i++)
			{
				if (currentString[i] != currentString[currentString.Length - 1 - i])
					return false;
			}
			return true;
		}




		public IList<IList<string>> Partition2(string s)
		{
			var result = new List<IList<string>>();
			if (s == "" || s == null)
				return result;

			DFS(s, 0, result, new List<string>());

			return result;

		}

		private void DFS(string s, int indexBegin, List<IList<string>> result, List<string> tempResult)
		{
			if (indexBegin == s.Length)
			{
				result.Add(new List<string>(tempResult));
				return;
			}


			for (int i = 1; i <= (s.Length - indexBegin); i++)
			{
				string subString = s.Substring(indexBegin, i);
				if (isPalindrome(subString))
				{
					tempResult.Add(subString);
					DFS(s, indexBegin + i, result, tempResult);
					tempResult.RemoveAt(tempResult.Count - 1);
				}


			}
		}

		private bool isPalindrome(string subString)
		{
			int i = 0;
			int j = subString.Length - 1;
			while (i < j)
			{
				if (subString[i] != subString[j])
					return false;
				i++;
				j--;
			}
			return true;
		}
	}
}
