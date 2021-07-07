using LeedCode.AFeature;
using System;
using System.Collections.Generic;

namespace LeedCode.DP
{
	public class LeetCode1345JumpingGame4 : LeetCode, Hard
	{
		public int Time => throw new NotImplementedException();

		public int NumberLeetCode => 1345;

		public string UrlLeetCode => "https://leetcode.com/problems/jump-game-iv/";




		public int MinJumps(int[] arr)
		{

			if (arr.Length == 1)
				return 0;

			Dictionary<int, List<int>> dic = new Dictionary<int, List<int>>();

			bool[] visited = new bool[arr.Length];



			for (int i = 0; i < arr.Length; i++)
			{
				if (!dic.ContainsKey(arr[i]))
					dic.Add(arr[i], new List<int>());

				dic[arr[i]].Add(i);
			}

			Queue<int> q = new Queue<int>();

			int steps = 1;
			visited[0] = true;

			q.Enqueue(0);

			while (q.Count > 0)
			{
				int count = q.Count;

				for (int i = 0; i < count; i++)
				{
					var index = q.Dequeue();

					// visited[index] = true;
					if (index + 1 < arr.Length && !visited[index + 1])
					{
						q.Enqueue(index + 1);
						visited[index + 1] = true;
					}

					if (index - 1 >= 0 && !visited[index - 1])
					{
						q.Enqueue(index - 1);

						visited[index - 1] = true;
					}

					foreach (var step in dic[arr[index]])
					{
						if (!visited[step])
						{
							q.Enqueue(step);
							visited[step] = true;
						}
					}

					 dic[arr[index]] = new List<int>();
				}

				if (visited[arr.Length - 1])
					return steps;
				steps++;
			}

			return -1;
		}


		public int MinJumps_DP(int[] arr)
		{

			if (arr.Length == 1)
				return 0;

			Dictionary<int, int> dic = new Dictionary<int, int>();

			int[] dp = new int[arr.Length + 1];

			dp[0] = 0;

			for (int i = 1; i < arr.Length; i++)
			{
				dp[i] = i;
			}

			dic.Add(arr[0], 0);

			for (int i = 1; i < arr.Length; i++)
			{
				int stepNext = dp[i - 1] + 1;

				if (i < arr.Length - 1)
					stepNext = Math.Min(dp[i + 1] + 1, stepNext);
				if (dic.ContainsKey(arr[i]))
				{
					var oldStep = dp[dic[arr[i]]];

					if(oldStep + 1 < stepNext)
					{
						stepNext = oldStep + 1;
						if(dp[i] > stepNext)
						{
							dp[i] = stepNext;
							for (int j = i; j > dic[arr[i]]; j--)
							{
								if (dp[j] + 1 < dp[j - 1])
									dp[j - 1] = dp[j] + 1;
								else
									break;
							}

						}
					}
					
				}
				dp[i] = Math.Min(stepNext, dp[i]);
				//Console.WriteLine(i + ";" + stepNext);
				if (!dic.ContainsKey(arr[i]))
				{
					dic.Add(arr[i], i);
				}
				else
				{
					if (dp[dic[arr[i]]] > dp[i])
					{
						dic[arr[i]] = i;
					}
				}
			}

			return dp[arr.Length - 1];
		}
	}
}
