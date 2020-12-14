using LeedCode.AFeature;
using System;
using System.Collections.Generic;

namespace LeedCode.BFS
{

	//第一遍刷题 1 错误错在使用过的词应该在最后放入usedWords 的列表当中 而不是随时添加
	//			2 错误在添加最终答案的时候没有加condition 最后一个词应该是endwords 所以在找到最终词之前的不是最优解的答案被加到list里面
	public class LeetCode126_Word_Ladder_II : LeetCode
	{
		public int NumberLeetCode => 126;

		public string UrlLeetCode => "https://leetcode.com/problems/word-ladder-ii/";

		public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList)
		{
			bool[] usedWords = new bool[wordList.Count];

			List<IList<string>> words = new List<IList<string>>();

			// error2 
			if (wordList.Contains(beginWord))
				wordList.Remove(beginWord);

			Queue<Tuple<string, HashSet<string>>> q = new Queue<Tuple<string, HashSet<string>>>();
			var newList = new HashSet<string>() { beginWord };

			q.Enqueue(Tuple.Create(beginWord, newList));

			FindNextWord(q, endWord, wordList, usedWords, words);

			return words;

		}


		private void FindNextWord(Queue<Tuple<string, HashSet<string>>> q, string endWord, IList<string> wordList, bool[] usedWords, List<IList<string>> words)
		{

			bool shouldContinue = true;
			while (q.Count > 0)
			{
				int count = q.Count;
				// error 1
				HashSet<int> currentUsedWords = new HashSet<int>();
				for (int i = 0; i < count; i++)
				{
					var currentString = q.Dequeue();
					HashSet<string> potentialNext = FindNextPossible(currentString.Item1, wordList, usedWords, currentUsedWords);

					if (potentialNext.Contains(endWord))
					{
						var list = currentString.Item2;
						list.Add(endWord);
						q.Enqueue(Tuple.Create(endWord, list));
						shouldContinue = false;
					}
					else if (shouldContinue)
					{
						foreach (var current in potentialNext)
						{
							var newList = new HashSet<string>(currentString.Item2);
							newList.Add(current);
							q.Enqueue(Tuple.Create(current, newList));

						}
					}
				}

				if (!shouldContinue)
					break;

				foreach (var index in currentUsedWords)
				{
					usedWords[index] = true;
				}

			}

			if (q.Count > 0 && !shouldContinue)
			{
				int count = q.Count;

				for (int i = 0; i < count; i++)
				{
					// error 2
					var element = q.Dequeue();
					if (element.Item1 == endWord)
						//end error2 
						words.Add(new List<string>(element.Item2));
				}
			}
		}

		private HashSet<string> FindNextPossible(string currentWord, IList<string> wordList, bool[] usedWords, HashSet<int> currentUsedWords)
		{

			HashSet<string> result = new HashSet<string>();
			HashSet<int> currentUsedWord = new HashSet<int>();
			for (int i = 0; i < wordList.Count; i++)
			{
				if (usedWords[i])
					continue;
				bool hasDifference = false;
				bool isMatch = true;
				var selected = wordList[i];
				for (int j = 0; j < currentWord.Length; j++)
				{
					if (currentWord[j] == selected[j])
						continue;
					if (hasDifference)
					{
						isMatch = false;
						break;
					}
					hasDifference = true;

				}

				if (isMatch && hasDifference)
				{
					result.Add(selected);
					currentUsedWord.Add(i);
				}
			}

			// error 1 
			foreach (var usedWord in currentUsedWord)
			{
				currentUsedWords.Add(usedWord);
			}

			return result;
		}

	}
}
