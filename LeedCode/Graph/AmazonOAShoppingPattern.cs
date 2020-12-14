using LeedCode.AFeature;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeedCode.Graph
{
	public class AmazonOAShoppingPattern : AmazonOA2020
	{
		public int getMinScore(int products_nodes, int products_edges, int[] products_from, int[] products_to)
		{
			int result = Int32.MaxValue;
			Dictionary<int, HashSet<int>> graph = new Dictionary<int, HashSet<int>>();
			for(int i = 0; i < products_edges; i++)
			{
				if (!graph.ContainsKey(products_from[i]))
					graph.Add(products_from[i], new HashSet<int>());
				if (!graph.ContainsKey(products_to[i]))
					graph.Add(products_to[i], new HashSet<int>());

				graph[products_from[i]].Add(products_to[i]);
				graph[products_to[i]].Add(products_from[i]);
			}
			List<int[]> trios = new List<int[]>();
			;
			var query = graph.Where(a => a.Value.Count <= 1).Select(a=> a.Key).ToList();

			foreach (var item in query)
			{
				graph.Remove(item);
			}

			HashSet<int> parsedNodes = new HashSet<int>();
			bool exists = false;
			foreach (var node in graph)
			{
				var edges = node.Value;
				int level = 0;
				Queue<Tuple<int, HashSet<int>>> q = new Queue<Tuple<int, HashSet<int>>>();

				foreach (var item in edges)
				{
					q.Enqueue( new Tuple<int, HashSet<int>>(item, new HashSet<int>() { item }));
				}

				while(q.Count > 0 && level < 2)
				{
					int qCount = q.Count();
					
					for (int i = 0; i <qCount; i++)
					{
						var node1 = q.Dequeue();

						if (graph.ContainsKey(node1.Item1))
						{
							foreach (var node2 in graph[node1.Item1])
							{
								if (node1.Item2.Contains(node2) || !graph.ContainsKey(node2) || parsedNodes.Contains(node2))
									continue;
								if(level < 1)
								{
									var newHashList = new HashSet<int>(node1.Item2);
									newHashList.Add(node2);
									q.Enqueue(new Tuple<int, HashSet<int>>(node2, newHashList));
								}
								else
								{
									if(node2 == node.Key)
									{
										var newHashList = new HashSet<int>(node1.Item2);
										newHashList.Add(node2);
										q.Enqueue(new Tuple<int, HashSet<int>>(node2, newHashList));
									}
								}
							}
						}
					}
					level++;
				}

				if(level== 2 && q.Count > 0)
				{
					exists = true;
					while (q.Count > 0)
					{
						var element = q.Dequeue();
						result = Math.Min(result, CalculateScore(element.Item2, graph));
					}
				}

				parsedNodes.Add(node.Key);
			}
			if(!exists){
				result = -1;
			}


			return result;
		}

		private int CalculateScore(HashSet<int> item2, Dictionary<int, HashSet<int>> graph)
		{
			int result = 0;
			for(int i = 0; i < item2.Count; i++)
			{
				result += graph[item2.ElementAt(i)].Count;
			}

			return (result - 6);
		}
	}
}
