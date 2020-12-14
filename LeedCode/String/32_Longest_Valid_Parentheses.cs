using LeedCode.AFeature;
using System;
using System.Collections.Generic;

namespace LeedCode.String
{
	public class _32_Longest_Valid_Parentheses : LeetCode, Hard
	{
		public int NumberLeetCode => 32;

		public string UrlLeetCode => "https://leetcode.com/problems/longest-valid-parentheses/";
		//重新做
		public int Time => 40;


		// Stack with index as value 
		//Blocked by stack a char
		public int LongestValidParentheses(string s)
		{
			int res = 0, start = 0, n = s.Length;
			Stack<int> st = new Stack<int>();
			for (int i = 0; i < n; ++i)
			{
				if (s[i] == '(') st.Push(i);
				else if (s[i] == ')')
				{
					if (st.Count == 0) start = i + 1;
					else
					{
						st.Pop();
						res = (st.Count == 0) ? Math.Max(res, i - start + 1) : Math.Max(res, i - st.Peek());
					}
				}
			}
			return res;
		}
	}
}
