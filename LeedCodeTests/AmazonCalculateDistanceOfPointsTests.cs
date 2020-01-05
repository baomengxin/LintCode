using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeedCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeedCode.Tests
{
	[TestClass()]
	public class AmazonCalculateDistanceOfPointsTests
	{
		[TestMethod()]
		public void CalculateNearestPointsTest()
		{
			var points = new List<Point>();
			points.Add(new Point(1, 0));
			points.Add(new Point(2, 0));
			points.Add(new Point(3, 0));
			points.Add(new Point(4, 0));
			points.Add(new Point(5, 0));
			var result = AmazonCalculateDistanceOfPoints.CalculateNearestPoints(points, 2);
			Assert.AreEqual(result.Count, 2);
			Assert.IsTrue(result.Contains(new Point(1, 0)));
			Assert.IsTrue(result.Contains(new Point(2, 0)));
		}

		[TestMethod()]
		public void CalculateNearestPointsTest2()
		{
			var points = new List<Point>();
			points.Add(new Point(1, 0));
			points.Add(new Point(2, 0));
			points.Add(new Point(3, 0));
			points.Add(new Point(4, 0));
			points.Add(new Point(5, 0));
			var result = AmazonCalculateDistanceOfPoints.CalculateNearestPoints(points, 2);
			Assert.AreEqual(result.Count, 2);
			Assert.IsTrue(result.Contains(new Point(1, 0)));
			Assert.IsTrue(result.Contains(new Point(2, 0)));
		}

		[TestMethod()]
		public void ClosestXdestinationsTest()
		{
			int[,] cals = new int[,]{{1,-3},{1,2},{3,4}};
			var result = AmazonCalculateDistanceOfPoints.ClosestXdestinations(1,cals, 2);
			Assert.AreEqual(result.Count, 1);
		}
	}
}