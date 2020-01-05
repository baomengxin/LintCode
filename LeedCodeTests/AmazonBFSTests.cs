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
	public class AmazonBFSTests
	{
		[TestMethod()]
		public void GetShortestDistanceTest()
		{
			int[,] matrix = new int[4,5]{{1,1,0,0,0},{0,1,1,0,0},{0,0,1,9,0},{0,0,0,0,0}};
			var shortestPath = AmazonBFS.GetShortestDistance(matrix);
			Assert.AreEqual(shortestPath, 5);
		}

		[TestMethod()]
		public void GetShortestDistanceTest2()
		{
			int[,] matrix = new int[4, 3] { { 1, 1, 0  }, { 1, 1, 0  }, { 1, 1, 0 }, { 1, 1, 9 }};
			var shortestPath = AmazonBFS.GetShortestDistance(matrix);
			Assert.AreEqual(shortestPath, 5);
		}


		[TestMethod()]
		public void GetShortestDistanceTest3()
		{
			//int[] matrix = new int[] { 1,0,0,0,0,1,0,0 };
			//int[] matrixReturn = new int[] { 0,1,0,0,1,0,1,0 };
			//var shortestPath = AmazonBFS.cellCompete(matrix, 1);
			//Assert.AreEqual(shortestPath.Length, matrixReturn.Length);

			int[] matrix = new int[] {1,1,1,0,1,1,1,1};
			int[] matrixReturn = new int[] { 0, 0, 0, 0, 1, 1, 0 };
			var shortestPath = AmazonBFS.cellCompete(matrix, 2);
			Assert.AreEqual(shortestPath.Length, matrixReturn.Length);
		}

		[TestMethod()]
		public void GetShortestDistanceTest4()
		{
			

			int[] matrix = new int[] { 2,4,6,8,9};
			var shortestPath = AmazonBFS.generalizedGCD(5,matrix);
			Assert.AreEqual(shortestPath,1);

			int[] matrix1 = new int[] { 2,9,1 };
			var shortestPath1 = AmazonBFS.generalizedGCD(5, matrix1);
			Assert.AreEqual(shortestPath1, 1);
		}

		[TestMethod()]
		public void GetShortestDistanceTest5()
		{


			int[] matrix = new int[] { 2, 4, 6, 8, 10 };
			var shortestPath = AmazonBFS.generalizedGCDMax(5, matrix);
			Assert.AreEqual(shortestPath, 2);
		
		}


	}
}