using LeedCode.AFeature;
using System.Collections.Generic;

namespace LeedCode.Graph
{
	public class LeetCode547FriendCircle : LeetCode, AmazonOA2020
	{
		public int NumberLeetCode => 547;

		public string UrlLeetCode => "https://leetcode.com/problems/friend-circles/";


		// DFS
		public int FindCircleNum(int[][] M)
		{
			if (M == null || M.Length == 0)
				return 0;

			Dictionary<int, HashSet<int>> friends = new Dictionary<int, HashSet<int>>();

			for(int i = 0; i < M.Length; i++)
			{
				friends.Add(i, new HashSet<int>());
			}

			for(int j = 0; j < M.Length; j++)
			{
				for(int k = 0; k <j; k++)
				{
					if(M[j][k] == 1)
					{
						friends[j].Add(k);
						friends[k].Add(j);
					}
				}
			}

			bool[] visited = new bool[M.Length];
			int circle = 0;

			for(int l = 0; l < M.Length; l++)
			{
				if (visited[l])
					continue;
				
				circle++;
				DFS2(visited, l, friends);
	
			}

			return circle;

		}

		// FIRST VERSION OF DFS, the problem is that the visited[l] will never turn to true, and create a indefinit loop
		private void DFS(bool[] visited, int l, Dictionary<int, HashSet<int>> friends)
		{
			if (visited[l])
				return;
			var friendCircle = friends[l];

			foreach (var item in friendCircle)
			{
				visited[l] = true;
				DFS(visited, item, friends);
			}
			
		}

		private void DFS2(bool[] visited, int l, Dictionary<int, HashSet<int>> friends)
		{
			
			var friendCircle = friends[l];

			foreach (var item in friendCircle)
			{
				if (visited[item])
					continue;
				visited[item] = true;
				DFS2(visited, item, friends);
			}

		}

	}
}
