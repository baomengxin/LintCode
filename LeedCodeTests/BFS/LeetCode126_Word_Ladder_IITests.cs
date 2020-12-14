using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LeedCode.BFS.Tests
{
	[TestClass()]
	public class LeetCode126_Word_Ladder_IITests
	{
		[TestMethod()]
		public void FindLaddersTest()
		{

			string beginWord = "hit", endWord = "cog";
			List<string> wordList = new List<string>() { "hot", "dot", "dog", "lot", "log", "cog" };


			var instance = new LeetCode126_Word_Ladder_II();
			var result = instance.FindLadders(beginWord, endWord, wordList);

			Assert.AreEqual(2, result.Count);
			var resultExpected = new List<IList<string>>()
			{
				new List<string>() {"hit","hot","dot","dog","cog" },
				new List<string>() {"hit","hot","lot","log","cog" },
			};


			for (int i = 0; i < resultExpected.Count; i++)
			{
				for (int j = 0; j < resultExpected[i].Count; j++)
				{
					Assert.AreEqual(resultExpected[i][j], result[i][j]);
				}
			}

		}

		[TestMethod()]
		public void FindLaddersTest_2()
		{
			string beginWord = "hot", endWord = "dog";
			List<string> wordList = new List<string>() { "hot", "cog", "dog", "tot", "hog", "hop", "pot", "dot" };

			var instance = new LeetCode126_Word_Ladder_II();
			var result = instance.FindLadders(beginWord, endWord, wordList);

			Assert.AreEqual(2, result.Count);
			var resultExpected = new List<IList<string>>()
			{
				
				new List<string>() {"hot","hog","dog"},
				new List<string>() {"hot", "dot", "dog"},
			};


			for (int i = 0; i < resultExpected.Count; i++)
			{
				for (int j = 0; j < resultExpected[i].Count; j++)
				{
					Assert.AreEqual(resultExpected[i][j], result[i][j]);
				}
			}

		}


	}
}