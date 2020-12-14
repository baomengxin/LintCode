using System.Collections.Generic;
using System.Linq;

namespace LeedCode.Graph
{
	public class SkylineProblem
	{

		public class Edge
		{
			public int x;
			public int height;
			public bool isStart;

			public Edge(int x, int height, bool isStart)
			{
				this.x = x;
				this.height = height;
				this.isStart = isStart;
			}
		}



		public class CustomComparer : IComparer<Edge>
		{
			public int Compare(Edge x, Edge y)
			{
				if (x.x != y.x)
				{
					return x.x.CompareTo(y.x);
				}
				if (x.isStart && y.isStart)
				{
					return y.height.CompareTo(x.height);
				}
				if (!x.isStart && !y.isStart)
				{
					return x.height.CompareTo(y.height);
				}

				return x.isStart ? -1 : 1;
			}
		}

		public IList<IList<int>> GetSkyline(int[][] buildings)
		{

			List<IList<int>> result = new List<IList<int>>();

			if (buildings == null || buildings.Length == 0
					|| buildings[0].Length == 0)
			{
				return result;
			}

			List<Edge> edges = new List<Edge>();

			// add all left/right edges
			for (int i = 0; i < buildings.Length; i++)
			{
				var building = buildings[i];
				Edge startEdge = new Edge(building[0], building[2], true);
				edges.Add(startEdge);
				Edge endEdge = new Edge(building[1], building[2], false);
				edges.Add(endEdge);
			}

			// sort edges 
			edges.Sort(new CustomComparer());

			// process edges
			SortedDictionary<int, int> heightHeap = new SortedDictionary<int, int>();

			for (int i = 0; i < edges.Count; i++)
			{
				var edge = edges[i];
				if (edge.isStart)
				{
					if (heightHeap.Count == 0 || edge.height > heightHeap.Last().Key)
					{
						result.Add(new List<int>() { edge.x, edge.height });
					}
					if(!heightHeap.ContainsKey(edge.height))
						heightHeap.Add(edge.height, 0);
					heightHeap[edge.height]++;
				}
				else
				{
					heightHeap.Remove(edge.height);

					if (heightHeap.Count == 0)
					{
						result.Add(new int[] { edge.x, 0 });
					}
					else if (edge.height > heightHeap.Last().Key)
					{
						result.Add(new int[] { edge.x, heightHeap.Last().Key });
					}
				}

			}

			return result;
		}
	}
}



