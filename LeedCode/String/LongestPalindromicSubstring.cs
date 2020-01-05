using LeedCode.Feature;

namespace LeedCode.String
{
	//Given a string s, find the longest palindromic substring in s.You may assume that the maximum length of s is 1000.

	//Example 1:

	//Input: "babad"
	//Output: "bab"
	//Note: "aba" is also a valid answer.
	//Example 2:

	//Input: "cbbd"
	//Output: "bb"
	public class LongestPalindromicSubstring : LeetCode, Amazon
	{
		/// <summary>
		/// Simplest way O(n3)
		/// </summary>
		/// <param name="s"></param>
		/// <returns></returns>
		public string LongestPalindrome1(string s)
		{
			if (string.IsNullOrEmpty(s))
				return s;
			int longestPalindromeLength = 0;
			int beginChar = 0;
			for (int i = 0; i < s.Length; i++)
			{
				for (int j = i; j < s.Length; j++)
				{
					if (IsPalindromeString(s, i, j))
					{
						if (longestPalindromeLength < j - i + 1)
						{
							longestPalindromeLength = j - i + 1;
							beginChar = i;
						}

					}
				}
			}

			return s.Substring(beginChar, longestPalindromeLength);
		}

		private bool IsPalindromeString(string s, int beginIndex, int endIndex)
		{
			while (endIndex > beginIndex)
			{
				if (s[beginIndex] != s[endIndex])
					return false;
				beginIndex++;
				endIndex--;
			}

			return true;
		}


		/// <summary>
		/// Simplest way O(n3)
		/// </summary>
		/// <param name="s"></param>
		/// <returns></returns>
		public string LongestPalindrome2(string s)
		{
			if (string.IsNullOrEmpty(s))
				return s;
			int longestPalindromeLength = 0;
			int beginChar = 0;
			for (int i = 0; i < s.Length; i++)
			{
				for (int j = i; j < s.Length; j++)
				{
					if (longestPalindromeLength < j - i + 1)
					{
						if (IsPalindromeString(s, i, j))
						{
							longestPalindromeLength = j - i + 1;
							beginChar = i;
						}
					}
				}
			}

			return s.Substring(beginChar, longestPalindromeLength);
		}


		/// <summary>
		/// Simplest way O(n3) 优化 动态规划 用字典节省算法时间
		/// </summary>
		/// <param name="s"></param>
		/// <returns></returns>
		public string LongestPalindrome5(string s)
		{
			if (string.IsNullOrEmpty(s))
				return s;
			int longestPalindromeLength = 0;
			int beginChar = 0;
			int lengthString = s.Length;
			bool[,] isPalindromeMatrix = new bool[lengthString, lengthString];
			for (int i = 0; i < lengthString; i++)
			{
				isPalindromeMatrix[i, i] = true;
			}
			for (int i = 0; i < s.Length; i++)
			{
				for (int j = 1; j + i < s.Length && j<=i; j++)
				{


					if (IsPalindromeStringByMatrix(s, i, j, isPalindromeMatrix))
					{
						if (longestPalindromeLength < 2*j +1)
						{
							longestPalindromeLength = 2 * j + 1;
							beginChar = i -j;
						}
					}
				}
			}

			return s.Substring(beginChar, longestPalindromeLength);
		}

		private bool IsPalindromeStringByMatrix(string s, int middleIndex, int lengthSubstring, bool[,] isPalindromeMatrix)
		{
			if (isPalindromeMatrix[middleIndex - lengthSubstring + 1, middleIndex + lengthSubstring - 1] &&
			    s[middleIndex - lengthSubstring] == s[middleIndex + lengthSubstring])
				isPalindromeMatrix[middleIndex - lengthSubstring, middleIndex + lengthSubstring] = true;
			else
			{
				isPalindromeMatrix[middleIndex - lengthSubstring, middleIndex + lengthSubstring] = false;
			}

			return isPalindromeMatrix[middleIndex - lengthSubstring, middleIndex + lengthSubstring];
		}


		/// <summary>
		/// 递归思想 从中间扩充到两边
		/// </summary>
		/// <param name="s"></param>
		/// <returns></returns>
		public string LongestPalindrome3(string s)
		{
			if (string.IsNullOrEmpty(s))
				return s;
			int longestPalindromeLength = 1;
			int beginChar = 0;
			for (int i = 0; i < s.Length; i++)
			{
				int j = 0;
				while (j <= i && j + i < s.Length)
				{
					if (s[i + j] != s[i - j])
					{
						break;
					}
					if (2 * j + 1 > longestPalindromeLength)
					{
						longestPalindromeLength = 2 * j + 1;
						beginChar = i - j;
					}

					j++;
				}

				int k = 0;
				while (k <= i && k + i - 1 < s.Length && k + i - 1 >= 0)
				{
					if (s[i + k - 1] != s[i - k])
					{
						break;
					}
					if (2 * k > longestPalindromeLength)
					{
						longestPalindromeLength = 2 * k;
						beginChar = i - k;
					}
					k++;
				}

			}

			return s.Substring(beginChar, longestPalindromeLength);
		}

		/// <summary>
		/// 递归思想 从中间扩充到两边  优化代码
		/// </summary>
		/// <param name="s"></param>
		/// <returns></returns>
		public string LongestPalindrome4(string s)
		{
			if (string.IsNullOrEmpty(s))
				return s;
			int longestPalindromeLength = 1;
			int beginChar = 0;
			for (int i = 0; i < s.Length; i++)
			{

				GetPalindromeLength(i, i, ref longestPalindromeLength, ref beginChar, s);

				GetPalindromeLength(i, i + 1, ref longestPalindromeLength, ref beginChar, s);
			}

			return s.Substring(beginChar, longestPalindromeLength);
		}

		private void GetPalindromeLength(int left, int right, ref int longestPalindromeLength, ref int starChar, string s)
		{
			while (left >= 0 && right < s.Length)
			{
				if (s[left] != s[right])
				{
					break;
				}
				if (right - left + 1 > longestPalindromeLength)
				{
					longestPalindromeLength = right - left + 1;
					starChar = left;
				}

				left--;
				right++;
			}
		}

		public int NumberLeetCode => 5;
		public string UrlLeetCode => "https://leetcode.com/problems/longest-palindromic-substring/";
	}
}
