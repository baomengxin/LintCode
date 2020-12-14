using System.Collections.Generic;
using System.Text;
using LeedCode.AFeature;

namespace LeedCode.String
{
	//53. Reverse Words in a String
	//Given an input string, reverse the string word by word.

	//Example
	//Given s = "the sky is blue",

	//return "blue is sky the".

	//Clarification
	//What constitutes a word?
	//A sequence of non-space characters constitutes a word.
	//Could the input string contain leading or trailing spaces?
	//Yes.However, your reversed string should not contain leading or trailing spaces.
	//How about multiple spaces between two words?
	//Reduce them to a single space in the reversed string.
	public class ReverseStringWordByWord : LintCode
	{

		public int NumberLintCode => 53;

		public string UrlLintCode => "https://www.lintcode.com/en/problem/reverse-words-in-a-string/";
		/*
	* @param s: A string
	* @return: A string
		*/
		public System.String reverseWords1(System.String s)
		{
			var stringCharList = s.ToCharArray();
			StringBuilder revertStringWord = new StringBuilder();
			var words = new List<string>();
			var word = new List<char>();
			for (int i = 0; i < stringCharList.Length; i++)
			{
				if (stringCharList[i] == ' ')
				{
					if (word.Count != 0)
					{
						words.Add(new System.String(word.ToArray()));
						word = new List<char>();
					}
				}
				else
				{
					word.Add(stringCharList[i]);
				}
			}
			if (word.Count != 0)
				words.Add(new System.String(word.ToArray()));

			for (int i = words.Count - 1; i >= 0; i--)
			{
				revertStringWord.Append(words[i]);
				if (i != 0)
					revertStringWord.Append(' ');

			}
			// write your code here
			return revertStringWord.ToString();
		}


		public System.String reverseWords2(System.String s)
		{
			var stringWordList = s.Split(' ');
			StringBuilder revertStringWord = new StringBuilder();
			var words = new List<string>();
			foreach (var word in stringWordList)
			{
				if (word == " " || word.Length == 0)
				{
					continue;
				}
				words.Add(word);
			}


			for (int i = words.Count - 1; i >= 0; i--)
			{
				revertStringWord.Append(words[i]);
				if (i != 0)
					revertStringWord.Append(' ');
			}
			// write your code here
			return revertStringWord.ToString();
		}

		public System.String reverseWords3(System.String s)
		{
			var stringWordList = s.Split(' ');
			StringBuilder revertStringWord = new StringBuilder();

			for (int i = stringWordList.Length - 1; i >= 0; i--)
			{
				if (!string.IsNullOrWhiteSpace(stringWordList[i]))
				{
					if (revertStringWord.Length > 0)
						revertStringWord.Append(" ");
					revertStringWord.Append(stringWordList[i]);
				}
			}
			// write your code here
			return revertStringWord.ToString();
		}


	}
}
