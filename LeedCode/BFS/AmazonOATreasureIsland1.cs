using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeedCode.BFS
{

//	Input
//[
//[‘O’, ‘O’, ‘O’, ‘O’],
//[‘D’, ‘O’, ‘D’, ‘O’],
//[‘O’, ‘O’, ‘O’, ‘O’],
//[‘X’, ‘D’, ‘D’, ‘O’],
//]

//Output from aonecode.com
//Route is (0, 0), (0, 1), (1, 1), (2, 1), (2, 0), (3, 0) The minimum route takes 5 steps.
	public class AmazonOATreasureIsland1
	{

		public int GetMinStep(Char[][] map)
		{
			if (map == null || map.Length == 0|| map[0].Length == 0)
				return -1;

			int step = 1;
			bool[][] visited = new bool[map.Length][];
			int width = map[0].Length;
			for (int i = 0; i < map.Length; i++)
			{
				visited[i] = new bool[width];
			}

			Queue<int[]> steps = new Queue<int[]>();

			int[][] directions = new int[][] { new int[] { 0, 1 }, new int[] { -1, 0 }, new int[] { 1, 0}, new int[] { 0, -1 } };
			steps.Enqueue(new int[] { 0, 0 });
			visited[0][0] = true;
			while (steps.Count> 0)
			{

				int count = steps.Count;
				for(int i = 0; i < count; i++)
				{
					var point = steps.Dequeue();

					for(int j = 0; j < 4; j++)
					{
						int newX = point[0] + directions[j][0];
						int newY = point[1] + directions[j][1];
						if(newX >=0 && newX < map.Length && newY >=0 && newY < width && !visited[newX][newY] )
						{
							if (map[newX][newY] == 'X')
								return step;
							if (map[newX][newY] == 'O')
							{
								steps.Enqueue(new int[] { newX, newY });
								visited[newX][newY] = true;
							}
						}
					}
				}

				step++;
			}

			return -1;
		}

	}
}
