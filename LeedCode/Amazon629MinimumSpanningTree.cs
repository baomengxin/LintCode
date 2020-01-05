using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeedCode
{
	//	Minimum Spanning Tree
	//	Given a list of Connections, which is the Connection class (the city name at both ends of the edge and a cost between them), find some edges,
	//connect all the cities and spend the least amount.
	//Return the connects if can connect all the cities, otherwise return empty list.
	//Example
	//Gievn the connections = [“Acity”,“Bcity”, 1], [“Acity”,“Ccity”,2], [“Bcity”,“Ccity”,3]

	//Return [“Acity”,“Bcity”,1], [“Acity”,“Ccity”,2]

	//Notice
	//Return the connections sorted by the cost, or sorted city1 name if their cost is same, or sorted city2 if their city1 name is also same.

	public class Amazon629MinimumSpanningTree
	{
		//	*
		//* Definition for a Connection.
		public class Connection
		{
			public System.String city1, city2;
			public int cost { get; set; }
			public Connection(System.String city1, System.String city2, int cost)
			{
				this.city1 = city1;
				this.city2 = city2;
				this.cost = cost;
			}
		}

		public List<Connection> lowestCost(List<Connection> connections)
		{
			var result = new List<Connection>();

			Dictionary<System.String, int> connectedCityTreeNameTreeNumberDictionary = new Dictionary<string, int>();

			var orderedConnections = connections.OrderByDescending(a => a.cost).ToList();
			Stack<Connection> cityQueue = new Stack<Connection>(orderedConnections);

			int cityTreeNumber = 0;
			while (cityQueue.Count != 0)
			{
				var cityConnectionSelected = cityQueue.Pop();

				if (connectedCityTreeNameTreeNumberDictionary.ContainsKey(cityConnectionSelected.city1) &&
				    connectedCityTreeNameTreeNumberDictionary.ContainsKey(cityConnectionSelected.city2))
				{
					// 如果两个city 在同一个颗树上 就没必要再合并树并且这条边也不同加入最后的集合中
					if (connectedCityTreeNameTreeNumberDictionary[cityConnectionSelected.city1] == connectedCityTreeNameTreeNumberDictionary[cityConnectionSelected.city2])
						continue;
					// 如果两个city 不在同一颗树上，那么合并这两棵树
					else
					{
						int treeIndexSelected = connectedCityTreeNameTreeNumberDictionary[cityConnectionSelected.city2];
						int treeIndexJoined = connectedCityTreeNameTreeNumberDictionary[cityConnectionSelected.city1];

						foreach (var keyConnection in connectedCityTreeNameTreeNumberDictionary.Keys.ToList())
						{
							if (connectedCityTreeNameTreeNumberDictionary[keyConnection] == treeIndexJoined)
							{
								connectedCityTreeNameTreeNumberDictionary[keyConnection] = treeIndexSelected;
							}
						}
						result.Add(cityConnectionSelected);
					}
				}
				//如果两个city只有一个在包含的树的集合里， 把另一个city加入到该树当中
				else if (connectedCityTreeNameTreeNumberDictionary.ContainsKey(cityConnectionSelected.city1))
				{
					connectedCityTreeNameTreeNumberDictionary.Add(cityConnectionSelected.city2, connectedCityTreeNameTreeNumberDictionary[cityConnectionSelected.city1]);
					result.Add(cityConnectionSelected);
				}
				else if (connectedCityTreeNameTreeNumberDictionary.ContainsKey(cityConnectionSelected.city2))
				{
					connectedCityTreeNameTreeNumberDictionary.Add(cityConnectionSelected.city1, connectedCityTreeNameTreeNumberDictionary[cityConnectionSelected.city2]);
					result.Add(cityConnectionSelected);
				}
				//两个city都不在树里面 则新建立一颗子树放到dictionary 里面
				else
				{
					connectedCityTreeNameTreeNumberDictionary.Add(cityConnectionSelected.city1, cityTreeNumber);
					connectedCityTreeNameTreeNumberDictionary.Add(cityConnectionSelected.city2, cityTreeNumber);
					result.Add(cityConnectionSelected);
					cityTreeNumber++;
				}
			}
			var numberTreeCount = connectedCityTreeNameTreeNumberDictionary.Values.Distinct().Count();
			if(numberTreeCount != 1)
				return new List<Connection>();
			return result.OrderBy(cost=>cost.cost).ThenBy(city1=>city1.city1).ThenBy(city2=>city2.city2).ToList();

		}

	}
}
