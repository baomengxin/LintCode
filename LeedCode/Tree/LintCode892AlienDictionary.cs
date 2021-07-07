using LeedCode.AFeature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeedCode.Tree
{


	//There is a new alien language which uses the latin alphabet.However, the order among letters are unknown to you.
	//You receive a list of non-empty words from the dictionary, where words are sorted lexicographically by the rules of this new language.
	//Derive the order of letters in this language.

	//You may assume all letters are in lowercase.
	//The dictionary is invalid, if a is prefix of b and b is appear before a.
	//If the order is invalid, return an empty string.
	//There may be multiple valid order of letters, return the smallest in normal lexicographical order

	public class LintCode892AlienDictionary : LintCode
	{
		public int NumberLintCode => 892;

		public string UrlLintCode => "https://www.lintcode.com/problem/alien-dictionary/description";

		public string alienOrder(string[] words)
		{
			if (words == null || words.Length == 0)
				return "";

			int[] degree = new int[26];
			Dictionary<char, HashSet<char>> dic = new Dictionary<char, HashSet<char>>();
			// Write your code here
			for(int i = 1; i < words.Length; i++)
			{
				var previousWord = words[i - 1];
				var currentWord = words[i];

				for(int j = 0; j < Math.Min(currentWord.Length, previousWord.Length); j++)
				{
					if(previousWord[j] != currentWord[j])
					{
						if (dic.ContainsKey(currentWord[j]) && dic[currentWord[j]].Contains(previousWord[j]))
							return "";
						if (!dic.ContainsKey(previousWord[j]))
						{
							dic.Add(previousWord[j], new HashSet<char>() { currentWord[j] });
							degree[currentWord[j] - 'a']++;
						}
						else
						{
							if (!dic[previousWord[j]].Contains(currentWord[j])){
								dic[previousWord[j]].Add(currentWord[j]);
								degree[currentWord[j] - 'a']++;
							}
							
						}
						break;
					}
				}
			}

			Queue<char> q = new Queue<char>();
			StringBuilder sb = new StringBuilder();
			foreach (var item in dic)
			{
				if(degree[item.Key - 'a'] == 0)
				{
					q.Enqueue(item.Key);
					sb.Append(item.Key);
				}
			}


			while(q.Count > 0)
			{
				var count = q.Count;

				for(int i = 0; i < q.Count; i++)
				{
					var element = q.Dequeue();
					if (!dic.ContainsKey(element))
						continue;
					foreach(var item in dic[element])
					{
						degree[item - 'a']--;
						if(degree[item - 'a'] == 0)
						{
							q.Enqueue(item);
							sb.Append(item);
						}
					}
				}
			}

			return sb.ToString();
		}

		public string DecodeAtIndex(string S, int K)
		{

			StringBuilder sb = new StringBuilder();

			int i = 0;
			while (sb.Length < K && i < S.Length)
			{
				char a = S[i];

				if (a <= 'z' && a >= 'a')
				{
					sb.Append(a);
					i++;
					continue;
				}

				for (int j = 1; j < (int)Char.GetNumericValue(a); j++)
				{
					sb.Append(sb.ToString());
				}
				i++;
			}

			return sb[K - 1].ToString();
		}
	}
}
