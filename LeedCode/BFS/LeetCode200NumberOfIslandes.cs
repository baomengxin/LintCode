using LeedCode.AFeature;
using System.Collections.Generic;
using System.Linq;

namespace LeedCode.BFS
{
	public class LeetCode200NumberOfIslandes : LeetCode, AmazonOA2020
	{
		public int NumberLeetCode => 200;

		public string UrlLeetCode => "https://leetcode.com/problems/number-of-islands/";

		public int NumIslands(char[][] grid)
		{
			if (grid == null || grid.Length == 0 || grid[0].Length == 0)
				return 0;

			bool[][] visited = new bool[grid.Length][];

			for(int i = 0; i < grid.Length; i++)
			{
				visited[i] = new bool[grid[0].Length];
			}

			int result = 0;

			Queue<int[]> q = new Queue<int[]>();

			for(int i = 0; i < grid.Length; i++)
			{
				for(int j = 0; j < grid[0].Length; j++)
				{
					if(grid[i][j] == '1' && !visited[i][j])
					{
						visited[i][j] = true;
						q.Enqueue(new int[] { i, j });
						BFS(grid, visited, q);
						result++;
					}
				}
			}

			return result;
			
		}

		private void BFS(char[][] grid, bool[][] visited, Queue<int[]> q)
		{
			int[][] directions = new int[][] { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 } };

			while (q.Count > 0)
			{
				int count = q.Count();

				for(int i = 0; i < count; i++)
				{
					var current = q.Dequeue();
					
					for(int j = 0; j < directions.Length; j++)
					{
						int newX = current[0] + directions[j][0];
						int newY = current[1] + directions[j][1];

						if(newX >= 0 && newX < grid.Length && newY >=0 && newY < grid.Length && !visited[newX][newY] && grid[newX][newY] == '1')
						{
							visited[newX][newY] = true;
							q.Enqueue(new int[] { newX, newY });
						}
					}
				}
			}
		}




		public int NumIslandsDFS(char[][] grid)
		{
			bool[][] matrix = new bool[grid.Length][];

			for (int i = 0; i < grid.Length; i++)
			{
				matrix[i] = new bool[grid[0].Length];
			}

			int[][] directions = new int[][] { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 } };

			int numIslandes = 0;
			for (int i = 0; i < grid.Length; i++)
			{
				for (int j = 0; j < grid[0].Length; j++)
				{
					if (!matrix[i][j] && grid[i][j] == '1')
					{
						numIslandes++;
						Stack<int[]> stack = new Stack<int[]>();
						stack.Push(new int[] { i, j });
						while (stack.Count > 0)
						{
							var selectedPoint = stack.Pop();
							int x = selectedPoint[0];
							int y = selectedPoint[1];
							foreach (var direct in directions)
							{
								int newX = x + direct[0];
								int newY = y + direct[1];
								if (newX >= 0 && newX < grid.Length && newY >= 0 && newY < grid[0].Length && !matrix[newX][newY])
								{
									if (grid[newX][newY] == '1')
										stack.Push(new int[] { newX, newY });
									matrix[newX][newY] = true;
								}
							}
						}
					}
				}
			}

			return numIslandes;
		}
	}
}
