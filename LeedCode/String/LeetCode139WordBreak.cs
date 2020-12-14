using LeedCode.AFeature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeedCode.String
{

	//Given a non-empty string s and a dictionary wordDict containing a list of non-empty words, 
	//determine if s can be segmented into a space-separated sequence of one or more dictionary words.

	//Note:
	
	//The same word in the dictionary may be reused multiple times in the segmentation.
	//You may assume the dictionary does not contain duplicate words.

	public class LeetCode139WordBreak : LeetCode
	{
		public int NumberLeetCode => 139;

		public string UrlLeetCode => "https://leetcode.com/problems/word-break/";


		public bool WordBreak(string s, IList<string> wordDict)
		{
			if (string.IsNullOrEmpty(s))
				return false;
			// optimization 1 
			if (!CheckWordChar(s, wordDict))
				return false;
			//return CanBreakWord(s, wordDict, 0);
			// DP: 

			bool[] dp = new bool[s.Length + 1];
			dp[0] = true;
			for(int i = 1; i <= s.Length; i++)
			{
				for(int j = 0; j < wordDict.Count; j++)
				{
					var selectedWord = wordDict[j];
					if (i - selectedWord.Length < 0)
						continue;

					if (dp[i - selectedWord.Length] && beginWith(s, selectedWord, i - selectedWord.Length))
					{
							dp[i+1] = true;
							break;
					}
				}
			}

			return dp[s.Length];
		}

		private bool CheckWordChar(string s, IList<string> wordDict)
		{
			bool[] chars = new bool[26];

			for(int i = 0; i < s.Length; i++)
			{
				chars[s[i] - 'a'] = true;
			}

			foreach (var item in wordDict)
			{
				for(int i = 0; i < item.Length; i++)
				{
					chars[item[i] - 'a'] = false;
				}
			}

			return ! chars.Any(a => a);
		}

		/// <summary>
		/// Brute Force first try
		/// Error1: return the result in the for loop, that ingored the condition afterwards. 
		/// Error2: Time Limit Exceeded -> optimization 1
		/// Error3: Time Limit Exceeded -> Try DP 
		/// </summary>
		/// <param name="s"></param>
		/// <param name="wordDict"></param>
		/// <param name="startIndex"></param>
		/// <returns></returns>
		private bool CanBreakWord(string s, IList<string> wordDict, int startIndex)
		{

			for (int i = 0; i < wordDict.Count; i++)
			{
				if (beginWith(s, wordDict[i], startIndex))
				{
					if (startIndex + wordDict[i].Length == s.Length)
						return true;
					//error 1
					var result = CanBreakWord(s, wordDict, startIndex + wordDict[i].Length);
					if (result)
						return true;
				}
			}

			return false;
		}

		private bool beginWith(string s, string wordDict, int startIndex)
		{
			if (startIndex + wordDict.Length > s.Length)
				return false;

			for (int i = 0; i < wordDict.Length; i++)
			{
				if (s[startIndex + i] != wordDict[i])
					return false;
			}

			return true;

		}


	}
}
