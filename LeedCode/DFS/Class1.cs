using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeedCode.DFS
{
	public class Class1
	{
		public class Solution
		{
			public static string FinalStat = "123450";
			public int SlidingPuzzle(int[][] board)
			{
				int result = 0;


				HashSet<string> previousStat = new HashSet<string>();

				int x = 0;
				int y = 0;
				for (int i = 0; i < board.Length; i++)
				{
					for (int j = 0; j < board[0].Length; j++)
					{
						if (board[i][j] == 0)
						{
							x = i;
							y = j;
							break;
						}
					}
				}
				var stat = GetStat(board);
				if (Equals(FinalStat, stat))
					return result;
				previousStat.Add(stat);
				Queue<Tuple<int[][], HashSet<string>>> q = new Queue<Tuple<int[][], HashSet<string>>>();
				q.Enqueue(new Tuple<int[][], HashSet<string>>(board, previousStat));
				result = BFS(q, 0);
				return result;


			}

			private string GetStat(int[][] board)
			{
				StringBuilder st = new StringBuilder();
				for (int i = 0; i < board.Length; i++)
				{
					for (int j = 0; j < board[0].Length; j++)
					{
						st.Append(board[i][j]);
					}
				}
				return st.ToString();
			}

			private int BFS(Queue<Tuple<int[][], HashSet<string>>> q, int result)
			{
				if (q.Count == 0)
					return -1;
				while (q.Count != 0)
				{
					int currentQueueNumber = q.Count();
					// Console.WriteLine("current tour" + currentQueueNumber);
					for (int j = 0; j < currentQueueNumber; j++)
					{
						var current = q.Dequeue();
						List<int[]> directions = new List<int[]> { new int[] { -1, 0 }, new int[] { 0, 1 }, new int[] { 1, 0 }, new int[] { 0, -1 } };
						var get0 = GetCurrent0(current.Item1);
						int x = get0[0];
						int y = get0[1];
						for (int i = 0; i < directions.Count; i++)
						{
							var newX = x + directions[i][0];
							var newY = y + directions[i][1];
							if (newX >= 0 && newX < 2)
							{
								if (newY >= 0 && newY < 3)
								{
									// change 0 with the current cell and check 
									var board = CopyBoard(current.Item1);

									board[x][y] = board[newX][newY];
									board[newX][newY] = 0;
									var stat = GetStat(board);
									//Console.WriteLine(stat + ";" + x + ";" + y + ";" + newX + ";" + newY);
									if (Equals(FinalStat, stat))
									{
										//  Console.WriteLine("stat");
										return ++result;
									}

									if (current.Item2.Contains(stat))
										continue;
									//var list = new HashSet<string>(current.Item2);
									current.Item2.Add(stat);
									q.Enqueue(new Tuple<int[][], HashSet<string>>(board, current.Item2));
								}
							}
						}
					}
					result++;
				}

				return -1;


			}

			private int[] GetCurrent0(int[][] board)
			{
				int x = 0;
				int y = 0;
				for (int i = 0; i < board.Length; i++)
				{
					for (int j = 0; j < board[0].Length; j++)
					{
						if (board[i][j] == 0)
						{
							x = i;
							y = j;
							break;
						}
					}
				}

				return new int[] { x, y };
			}

			private int[][] CopyBoard(int[][] item1)
			{
				var newtable = new int[item1.Length][];
				for (int i = 0; i < item1.Length; i++)
				{
					newtable[i] = new int[item1[0].Length];
					for (int j = 0; j < item1[0].Length; j++)
					{
						newtable[i][j] = item1[i][j];
					}
				}
				return newtable;
			}
		}
	}
}
