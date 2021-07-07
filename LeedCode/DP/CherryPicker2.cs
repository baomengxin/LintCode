using LeedCode.AFeature;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeedCode.DP
{
	/// <summary>
	/// 这道题可以用DP 但我实现的两种方法都是BFS 第二种进行了优化 用一个dic代表当前行所有的y1 y2 组合 只要已经存在了组合 更新sum 取最大值就可以了
	/// 
	/// </summary>
	public class CherryPicker2 : LeetCode
	{
		public int NumberLeetCode => 1463;

		public string UrlLeetCode => "https://leetcode.com/problems/cherry-pickup-ii/";

		public class RobotPosition
		{
			public int[] p1 { get; set; }

			public int[] p2 { get; set; }

			public int sum;

			public RobotPosition()
			{
				p1 = new int[2];
				p2 = new int[2];
			}
		}

		public class RobotPosition2
		{
			public int x { get; set; }

			public int[] y { get; set; }

			public int sum;

			public RobotPosition2()
			{
				y = new int[2];
			}
		}


		//public int cherryPickup(int[][] grid)
		//{
		//	int[][] directions = new int[][] { new int[] { 1, 1 }, new int[] { 1, 0 }, new int[] { 1, -1 } };


		//	int[][] dp = new int[grid.Length + 1][];

		//	for(int i = 0; i <= grid.Length; i++)
		//	{
		//		dp[i] = new int[grid[0].Length+1];

		//		for(int j = 0; j < grid[0].Length; j++)
		//		{
		//			dp[i][j] = Int32.MinValue;
		//		}
		//	}

		//	dp[0][0] = grid[0][0];

		//	dp



		//	int[] begin1 = new int[] { 0, 0 };

		//	int[] begin2 = new int[] { 0, grid[0].Length - 1 };



		//	for(int i = 0; i < grid.Length; i++)
		//	{
		//		for(int j = 0; j < grid[0].Length; j++)
		//		{
		//			if(CanReachCell(dp, i, j))
		//			{
		//				dp[i][j]
		//			}
		//		}
		//	}
		//}


		public int cherryPickup(int[][] grid)
		{
			int[][] directions = new int[][] { new int[] { 1, 1 }, new int[] { 1, 0 }, new int[] { 1, -1 } };

			Queue<RobotPosition2> q = new Queue<RobotPosition2>();

			var p1 = new RobotPosition2();

			p1.x = 0;
			p1.y = new int[] { 0, grid[0].Length - 1 };

			int length = grid.Length;
			int width = grid[0].Length;
			p1.sum = grid[0][0] + grid[0][width - 1];

			grid[0][0] = 0;
			grid[0][width - 1] = 0;
			q.Enqueue(p1);

			return BFS2(q, grid);
		}

		private int BFS2(Queue<RobotPosition2> q, int[][] grid)
		{
			int[][] directions = new int[][] { new int[] { 1, 1 }, new int[] { 1, 0 }, new int[] { 1, -1 } };

			int result = 0;
			while (q.Count > 0)
			{

				var count = q.Count;
				int level = 0;

				for (int i = 0; i < count; i++)
				{
					Dictionary<Tuple<int, int>, RobotPosition2> dic = new Dictionary<Tuple<int, int>, RobotPosition2>();

					var element = q.Dequeue();
					result = Math.Max(result, element.sum);

					for (int j = 0; j < directions.Length; j++)
					{
						for (int k = 0; k < directions.Length; k++)
						{
							int x1 = level + 1;
							int x2 = level + 1;
							int y1 = element.y[1] + directions[j][1];
							int y2 = element.y[1] + directions[k][1];


							if (Valid(x1, y1, grid) && Valid(x2, y2, grid))
							{
								var newNode = new RobotPosition2();
								newNode.x = x1;
								newNode.y = new int[] { y1, y2 };
								int newSum = element.sum;
								if (y1 != y2)
								{
									newSum += grid[x1][y1];
									newSum += grid[x2][y2];
								}
								else
								{
									newSum += grid[x1][y1];
								}
								newNode.sum = newSum;
								if(!dic.ContainsKey(Tuple.Create(y1, y2)))
								{
									q.Enqueue(newNode);
									dic.Add(Tuple.Create(y1, y2), newNode);
								}
								else
								{
									var ele = dic[Tuple.Create(y1, y2)];
									ele.sum = Math.Max(newSum, ele.sum);
								}
								
							}
						}
					}
				}

				level++;

				if (level == grid.Length) ;
				break;
			}

			return result;
		}

		public int cherryPickup1(int[][] grid)
		{
			int[][] directions = new int[][] { new int[] { 1, 1 }, new int[] { 1, 0 }, new int[] { 1, -1 } };

			Queue<RobotPosition> q = new Queue<RobotPosition>();

			var p1 = new RobotPosition();

			p1.p1 = new int[] { 0, 0 };
			p1.p2 = new int[] { 0, grid[0].Length - 1 };

			int length = grid.Length;
			int width = grid[0].Length;
			p1.sum = grid[0][0] + grid[0][width - 1];

			grid[0][0] = 0;
			grid[0][width - 1] = 0;
			q.Enqueue(p1);

			return BFS(q, grid);
		}

		private int BFS(Queue<RobotPosition> q, int[][] grid)
		{
			int[][] directions = new int[][] { new int[] { 1, 1 }, new int[] { 1, 0 }, new int[] { 1, -1 } };
			int result = 0;
			while (q.Count > 0)
			{
				var count = q.Count;
				//int level = 0; 

				for (int i = 0; i < count; i++)
				{
					var element = q.Dequeue();
					result = Math.Max(result, element.sum);

					for (int j = 0; j < directions.Length; j++)
					{
						for (int k = 0; k < directions.Length; k++)
						{
							int x1 = element.p1[0] + directions[j][0];
							int x2 = element.p2[0] + directions[k][0];
							int y1 = element.p1[1] + directions[j][1];
							int y2 = element.p2[1] + directions[k][1];


							if (Valid(x1, y1, grid) && Valid(x2, y2, grid))
							{
								var newNode = new RobotPosition();
								newNode.p1 = new int[] { x1, y1 };
								newNode.p2 = new int[] { x2, y2 };
								int newSum = element.sum;
								if (y1 != y2)
								{
									newSum += grid[x1][y1];
									newSum += grid[x2][y2];
								}
								else
								{
									newSum += grid[x1][y1];
								}

								q.Enqueue(newNode);
							}
						}
					}
				}

				//level++;

				//if (level == grid.Length - 1)
				//	break;
			}


			//while(q.Count> 0)
			//{
			//	var element = q.Dequeue();

			//}

			return result;
		}

		private bool Valid(int x1, int y1, int[][] grid)
		{
			int length = grid.Length;
			int width = grid[0].Length;
			if (x1 >= 0 && x1 < length && y1 >= 0 && y1 < width)
				return true;
			return false;
		}








		public class DescendComparer : IComparer<int>
		{
			public int Compare(int x, int y)
			{
				return y.CompareTo(x);
			}
		}

		public int NextGreaterElement(int n)
		{
			SortedDictionary<int, int> dic = new SortedDictionary<int, int>(new DescendComparer());
			string nStr = n.ToString();

			dic.Add((int)Char.GetNumericValue(nStr[nStr.Length - 1]), 1);

			long result = -1;
			for (int i = nStr.Length - 2; i >= 0; i--)
			{
				int selectedNumber = (int)Char.GetNumericValue(nStr[i]);

				if (!dic.ContainsKey(selectedNumber))
				{
					dic.Add(selectedNumber, 0);
				}
				dic[selectedNumber]++;

				var topElement = dic.FirstOrDefault().Key;

				if (topElement > selectedNumber)
				{
					return ConstructResult(n, i, dic);
				}

			}

			return -1;

		}

		private int ConstructResult(int n, int i, SortedDictionary<int, int> dic)
		{
			string newInt = n.ToString().Substring(0, i);

			long result = (long)Int32.Parse(newInt);

			var firstElement = dic.FirstOrDefault().Key;

			result = result * 10 + firstElement;

			if (dic[firstElement] == 1)
				dic.Remove(firstElement);
			else
				dic[firstElement]--;
			while (dic.Count > 0)
			{

				var elment = dic.LastOrDefault();

				for (int j = 0; j < elment.Value; j++)
				{
					result = result * 10 + elment.Key;
				}

				dic.Remove(elment.Key);
			}

			if (result > Int32.MaxValue)
				return -1;
			return (int)result;

		}
	}
}
