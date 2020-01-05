using System;
using System.Collections.Generic;
using LeedCode.Feature;

namespace LeedCode
{
	/// <summary>
	/// Given a string, find the length of the longest substring without repeating characters.
	/// </summary>
	public class LeetCode3LongestSubstring : LeetCode
	{
		public int LengthOfLongestSubstring(string s)
		{
			Dictionary<char, int> charIndexDictionary = new Dictionary<char, int>();
			int lengthMax = 0;
			var charString = s.ToCharArray();
			for (int index = 0, indexLastNotRepeated = 0;  index < charString.Length; index++)
			{
				var character = charString[index];
				if (!charIndexDictionary.ContainsKey(character))
				{
					charIndexDictionary.Add(character, index);
					if (lengthMax < index - indexLastNotRepeated + 1)
						lengthMax = index - indexLastNotRepeated + 1;
				}
				else
				{
					var maxLength = Math.Max(charIndexDictionary[character], indexLastNotRepeated);
					var charLength = index - maxLength;
					if (lengthMax < charLength)
						lengthMax = charLength;
					indexLastNotRepeated = Math.Max(charIndexDictionary[character] + 1, indexLastNotRepeated); 
					if (lengthMax < index - indexLastNotRepeated +1)
						lengthMax = index - indexLastNotRepeated +1;
					charIndexDictionary[character] = index;

				}
			}

			return lengthMax;
		}

		public int NumberLeetCode => 3;
		public string UrlLeetCode => "https://leetcode.com/problems/longest-substring-without-repeating-characters/";
	}
}
