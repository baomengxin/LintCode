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
	public class LeetCode472_Concatenated_Words : LeetCode, Hard
	{
		public int NumberLeetCode => 472;

		public string UrlLeetCode => "https://leetcode.com/problems/concatenated-words/";

		public int Time => throw new NotImplementedException();

		public class DictionaryTree
		{
			public char Char { get; set; }

			public bool Finish { get; set; }

			public List<DictionaryTree> Tree { get; set; }

			public DictionaryTree(char c, bool f)
			{
				Tree = new List<DictionaryTree>();

				this.Char = c;

				this.Finish = f;
			}
		}

		public IList<string> FindAllConcatenatedWordsInADict(string[] words)
		{
			List<string> result = new List<string>();
			HashSet<string> wordsH = words.ToHashSet();


			for(int i = 0; i < words.Length; i++)
			{
				if(TryConcatenateWord(wordsH, words[i], 0, 0))
				{
					result.Add(words[i]);
				}
			}

			return result;
		}

		private bool TryConcatenateWord(HashSet<string> wordsH, string word, int beginIndex, int number)
		{
			if (beginIndex >= word.Length)
			{
				if (number >= 2)
					return true;
				return false;
			}

			for (int i = 1; i + beginIndex <= word.Length; i++)
			{
				var selectedString = word.Substring(beginIndex, i);

				if (wordsH.Contains(selectedString))
				{
					if (TryConcatenateWord(wordsH, word, beginIndex + i, number + 1))
					{
						return true;
					}
				}
			}

			return false;
		}

		public IList<string> FindAllConcatenatedWordsInADict_StillTimeOut(string[] words)
		{
			List<string> result = new List<string>();

			Dictionary<string, bool> dic = new Dictionary<string, bool>();
			Dictionary<string, bool> intermediadic = new Dictionary<string, bool>();

			int minLong = Int32.MaxValue;

			words = words.Where(a => a.Length != 0).ToArray();

			minLong = words.Min(s => s.Length);

			words.Where(a => a.Length == minLong).ToList().ForEach(a =>
				dic.Add(a, false));
			List<DictionaryTree> _trie = new List<DictionaryTree>();
			for (int i = 0; i < words.Length; i++)
			{
				AddInTrie(_trie, words[i]);
			}


			for (int i = 0; i < words.Length; i++)
			{
				if (dic.ContainsKey(words[i]) && !dic[words[i]])
					continue;
				//dic.Add(words[i], false);

				var selectedWord = words[i];

				if (CanConcatenateWord(words, selectedWord, dic, intermediadic, i, _trie))
				{
					dic.Add(selectedWord, true);
				}
				else
				{
					dic.Add(selectedWord, false);
				}

			}

			return dic.Where(a => a.Value == true).Select(a => a.Key).ToList();
		}

		private void AddInTrie(List<DictionaryTree> trie, string word)
		{
			char first = word[0];
			var selectedTrie = trie.FirstOrDefault(a => a.Char == first);

			if (selectedTrie == null)
			{
				selectedTrie = new DictionaryTree(first, word.Length == 0);
				trie.Add(selectedTrie);
			}
			if (word.Length == 0)
				return;
			AddInTrie(selectedTrie.Tree, word.Substring(1));
		}

		private bool CanConcatenateWord(string[] words, string selectedWord, Dictionary<string, bool> dic, Dictionary<string, bool> intermediadic, int currentIndex, List<DictionaryTree> _trie)
		{
			if (dic.ContainsKey(selectedWord))
				return true;

			if (intermediadic.ContainsKey(selectedWord))
				return intermediadic[selectedWord];

			for (int i = 0; i < words.Length; i++)
			{
				if (i == currentIndex)
					continue;
				if (words[i].Length > selectedWord.Length)
					continue;
				if (selectedWord.StartsWith(words[i]))
				{
					if (selectedWord.Length == words[i].Length)
					{
						//intermediadic.Add(selectedWord, true);
						return true;
					}

					var result = CanConcatenateWord(words, selectedWord.Substring(words[i].Length), dic, intermediadic, currentIndex, _trie);
					if (result == false)
					{
						if (!intermediadic.ContainsKey(selectedWord))
						{
							intermediadic.Add(selectedWord, false);
						}
					}
					else
					{
						if (!dic.ContainsKey(selectedWord) && !intermediadic.ContainsKey(selectedWord))
						{
							intermediadic.Add(selectedWord, true);
						}
						return result;
					}
				}
			}

			if (!intermediadic.ContainsKey(selectedWord))
			{
				intermediadic.Add(selectedWord, false);
			}

			return false;
		}

		public IList<string> FindAllConcatenatedWordsInADict_TimeOut(string[] words)
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
