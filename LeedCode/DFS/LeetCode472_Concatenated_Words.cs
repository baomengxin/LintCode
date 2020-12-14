using LeedCode.AFeature;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeedCode.DFS
{
	//Given a list of words(without duplicates), please write a program that returns all concatenated words in the given list of words.
	//A concatenated word is defined as a string that is comprised entirely of at least two shorter words in the given array.
	
	//Example:
	//Input: ["cat","cats","catsdogcats","dog","dogcatsdog","hippopotamuses","rat","ratcatdogcat"]
	
	//Output: ["catsdogcats","dogcatsdog","ratcatdogcat"]
	
	//Explanation: "catsdogcats" can be concatenated by "cats", "dog" and "cats"; 
	// "dogcatsdog" can be concatenated by "dog", "cats" and "dog"; 
	//"ratcatdogcat" can be concatenated by "rat", "cat", "dog" and "cat".
	//Note:
	//The number of elements of the given array will not exceed 10,000
	//The length sum of elements in the given array will not exceed 600,000.
	//All the input string will only include lower case letters.
	//The returned elements order does not matter.
	public class LeetCode472_Concatenated_Words : LeetCode
	{
		public int NumberLeetCode => 472;

		public string UrlLeetCode => "https://leetcode.com/problems/concatenated-words/";

		public IList<string> FindAllConcatenatedWordsInADict(string[] words)
		{
			List<string> result = new List<string>();

			Dictionary<string, bool> dic = new Dictionary<string, bool>();
			Dictionary<string, bool> intermediadic = new Dictionary<string, bool>();
			int minLong = Int32.MaxValue;

			words = words.Where(a => a.Length != 0).ToArray();
			minLong = words.Min(s => s.Length);

			words.Where(a => a.Length == minLong).ToList().ForEach(a =>
				dic.Add(a, false));


			for (int i = 0; i < words.Length; i++)
			{
				if (dic.ContainsKey(words[i]) && !dic[words[i]])
					continue;
				dic.Add(words[i], false);
				for (int j = 0; j < words.Length; j++)
				{
					if (i == j)
						continue;
					//Console.WriteLine(i  + ";" + j);

					if (words[i].Length <= words[j].Length)
						continue;
					var wordsSplit = words[i].Split(new string[] { words[j] }, StringSplitOptions.RemoveEmptyEntries);
					if (wordsSplit.Length == 1 && wordsSplit[0] == words[i]) // words[i] doens't contain words[j], no need to continue search
						continue;
					//words[i] is composed of more than one words[j] split success 
					if (wordsSplit.Length == 0)
					{
						dic[words[i]] = true;
						result.Add(words[i]);
						break;
					}
					bool isValidCurrentWord = true;

					for (int k = 0; k < wordsSplit.Length; k++)
					{
						var current = wordsSplit[k];
						if (dic.ContainsKey(current) || (intermediadic.ContainsKey(current) && intermediadic[current]))
						{
							// Console.WriteLine(wordsSplit[k]);
							continue;
						}

						if (current.Length < minLong)
						{
							intermediadic.Add(current, false);
							isValidCurrentWord = false;
							break;
						}


						var listSearch = words.Where(a => (a.Length <= current.Length)).ToList();
						if (listSearch.Count == 0)
						{
							isValidCurrentWord = false;
							break;
						}
						var resultDfs = DFS(current, listSearch, dic, intermediadic);

						if (resultDfs == false)
						{
							isValidCurrentWord = false;
							break;
						}
					}

					if (isValidCurrentWord)
					{
						dic[words[i]] = true;
						// Console.WriteLine("true" + words[i]);
						result.Add(words[i]);
						break;
					}

				}
			}
			return result;
		}

		private bool DFS(string current, List<string> listSearch, Dictionary<string, bool> dic, Dictionary<string, bool> intermediadic)
		{
			bool result = false;
			//Console.WriteLine(current);

			if (dic.ContainsKey(current) || (intermediadic.ContainsKey(current) && intermediadic[current]))
			{
				return true;
			}
			if (intermediadic.ContainsKey(current) && (!intermediadic[current]))
			{
				return false;
			}

			for (int i = 0; i < listSearch.Count(); i++)
			{
				var splitList = current.Split(new string[] { listSearch[i] }, StringSplitOptions.RemoveEmptyEntries);
				if (splitList.Count() == 0)
				{
					intermediadic.Add(current, true);
					return true;
				}
				if (splitList.Count() == 1 && splitList[0] == current)
					continue;
				bool isValid = true;
				for (int j = 0; j < splitList.Length; j++)
				{
					var newListSearch = listSearch.Where(a => (a.Length <= splitList[j].Length)).ToList();
					if (newListSearch.Count == 0)
					{
						break;
					}

					result = DFS(splitList[j], newListSearch, dic, intermediadic);
					if (result == false)
					{
						isValid = false;
						break;
					}
				}

				if (isValid)
				{
					intermediadic.Add(current, true);
					return result;
				}

			}

			Console.WriteLine(current + " : " + result);
			intermediadic.Add(current, false);
			return result;
		}



	}
}
