using System;
using System.Collections.Generic;
using System.Linq;

namespace LeedCode
{
	public struct Point
	{
		public int X { get; set; }
		public int Y { get; set; }

		public Point(int x, int y)
		{
			this.X = x;
			this.Y = y;
		}
	}
	public static class AmazonCalculateDistanceOfPoints
	{
		/// <summary>
		/// return the nearest K points of the given list from (0,0)
		/// </summary>
		/// <param name="points"></param>
		/// <param name="k"></param>
		/// <returns></returns>
		public static List<Point> CalculateNearestPoints(List<Point> points, int k)
		{
			if (k <= 0)
				return new List<Point>();
			if (k >= points.Count)
				return points;
			// TODO: remove duplicate
			Dictionary<Point, double> distanceToOriginalPointDictionary = new Dictionary<Point, double>();
			List<Point> selectedNearliestPoints = new List<Point>();

			foreach (var point in points)
			{
				double distanceToOriginalPoint = System.Math.Pow(point.X, 2) + System.Math.Pow(point.Y, 2);
				//TODO: method
				if (double.IsNegativeInfinity(distanceToOriginalPoint) ||
				    double.IsPositiveInfinity(distanceToOriginalPoint) || double.IsNaN(distanceToOriginalPoint))
					break;
				distanceToOriginalPointDictionary.Add(point,distanceToOriginalPoint);
			}

			// Order by values.
			// ... Use LINQ to specify sorting by value.
			var orderedDistanceToPointList = (from pair in distanceToOriginalPointDictionary
											 orderby pair.Value ascending
											 select pair).Take(k);

			int selectedItemNumber = 0;
			foreach (var keyValuePair in orderedDistanceToPointList)
			{
				if (selectedItemNumber >= k)
					break;
				selectedNearliestPoints.Add(keyValuePair.Key);
				selectedItemNumber++;
			}
			return selectedNearliestPoints;
		}

		public static List<List<int>> ClosestXdestinations(int numDestinations,
			int[,] allLocations,
			int numDeliveries)
		{
			List<List<int>> result = new List<List<int>>();
			List<Point> selectedNearliestPoints = new List<Point>();
			// WRITE YOUR CODE HERE
			if (numDestinations <= 0 || allLocations == null || allLocations.Length <= 0 || numDeliveries <= 0)
				return result;
			Dictionary<Point, double> distanceToOriginalPointDictionary = new Dictionary<Point, double>();
			for (int i = 0; i < allLocations.GetLength(0); i++)
			{

				double distanceToOriginalPoint =
					Math.Pow(allLocations[i, 0], 2) + Math.Pow(allLocations[i, 1], 2);
				if (double.IsNegativeInfinity(distanceToOriginalPoint) ||
				    double.IsPositiveInfinity(distanceToOriginalPoint) || double.IsNaN(distanceToOriginalPoint))
					break;
				distanceToOriginalPointDictionary.Add(new Point(allLocations[i, 0], allLocations[i, 1]), distanceToOriginalPoint);

			}

			var orderedDistanceToPointList = (from pair in distanceToOriginalPointDictionary
				orderby pair.Value ascending
				select pair).Take(numDeliveries);

			foreach (var keyValuePair in orderedDistanceToPointList)
			{
				result.Add(new List<int>(){keyValuePair.Key.X, keyValuePair.Key.Y
				});
			}
			return result;
		}

		public static  List<List<int>> optimalUtilization(int deviceCapacity,
			List<List<int>> foregroundAppList,
			List<List<int>> backgroundAppList)
		{
			List<List<int>> returnList = new List<List<int>>();
			if (deviceCapacity < 0 || foregroundAppList == null || !foregroundAppList.Any() || !backgroundAppList.Any())
				return returnList;
			Dictionary<List<int>, int> pointToDistanceDictionary = new Dictionary<List<int>, int>();
			int maxNumber = 0;
			foreach (var foregroundApp in foregroundAppList)
			{
				foreach (var backgroudApp in backgroundAppList)
				{
					if (foregroundApp.Count < 2 || backgroudApp.Count < 2)
						return returnList;
					int sumCapacity = foregroundApp[1] + backgroudApp[1];
					if (sumCapacity > deviceCapacity)
						continue;

					maxNumber = sumCapacity;
					pointToDistanceDictionary.Add(new List<int>()
					{
						foregroundApp[0],
						backgroudApp[0]
					}, sumCapacity);
				}
			}
			var orderedDistanceToPointList = (from pair in pointToDistanceDictionary
				orderby pair.Value descending
				select pair);
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
