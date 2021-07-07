using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeedCode.OA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeedCode.OA.Tests
{
	[TestClass()]
	public class AmazonOAPrimeAirRouteTests
	{
		[TestMethod()]
		public void getIdPairsForOptimalTest()
		{
			var arr1 = new List<List<int>> { new List<int> { 1, 2000 }, new List<int> { 2, 3000 }, new List<int> { 3, 4000 } };
			var arr2 = new List<List<int>> { new List<int> { 1, 5000 }, new List<int> { 2, 3000 } };
			var instance = new AmazonOAPrimeAirRoute();

			var result = instance.getIdPairsForOptimal(arr1, arr2, 5000);
			Assert.AreEqual(result.Count, 1);

			Assert.AreEqual(result[0][0], 2);
			Assert.AreEqual(result[0][1], 3);
		}
	}
}