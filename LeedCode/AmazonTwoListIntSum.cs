using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeedCode
{
	/// <summary>
	/// 2. 给定两个list，list1和list2，和一个整数K作为limit。list里面的元素包含Id和Usage。要在list1和list2里各取一个element，使得两个element的usage之和是所有组合里小于等于limit的最大值。找出所有这样的组合。
	/// </summary>
	public static class AmazonTwoListIntSum
	{
		public static List<Point> GetTwoSumValuePairs(List<int> list1, List<int> list2, int k)
		{
			var pairValueToReturn = new List<Point>();
			for (int i = 0; i < list1.Count; i++)
			{

				for (int j = 0; j < list2.Count; j++)
				{
					if (list1[i] + list2[j] <= k)
						pairValueToReturn.Add(new Point(list1[i], list2[j]));
					j++;
				}

				i++;
			}

			return pairValueToReturn;
		}

		// METHOD SIGNATURE BEGINS, THIS METHOD IS REQUIRED
		public static List<List<int>> optimalUtilization(int deviceCapacity,
			List<List<int>> foregroundAppList,
			List<List<int>> backgroundAppList)
		{
			// WRITE YOUR CODE HERE
			List<List<int>> returnList = new List<List<int>>();
			if (deviceCapacity < 0 || foregroundAppList == null || !foregroundAppList.Any() || !backgroundAppList.Any())
				return returnList;
			Dictionary<List<int>, int> pointToDistanceDictionary = new Dictionary<List<int>, int>();
			foreach (var foregroundApp in foregroundAppList)
			{
				foreach (var backgroudApp in backgroundAppList)
				{
					if (foregroundApp.Count < 2 || backgroudApp.Count < 2)
						return returnList;
					int sumCapacity = foregroundApp[1] + backgroudApp[1];
					if (sumCapacity > deviceCapacity)
						continue;
					pointToDistanceDictionary.Add(new List<int>()
					{
						foregroundApp[0],
						backgroudApp[0]
					}, sumCapacity);
				}
			}
			var orderedDistanceToPointList = (from pair in pointToDistanceDictionary
											  orderby pair.Value descending select pair);
			int valueMax = 0;
			foreach (var distancePair in orderedDistanceToPointList)
			{
				if (valueMax > distancePair.Value)
					break;
				valueMax = distancePair.Value;
				returnList.Add(new List<int>(distancePair.Key));
			}

			return returnList;

		}
	}


}
