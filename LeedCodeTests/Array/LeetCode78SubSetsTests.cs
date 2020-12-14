using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeedCode.Array;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeedCodeTests;

namespace LeedCode.Array.Tests
{
	[TestClass()]
	public class LeetCode78SubSetsTests
	{
		[TestMethod()]
		public void SubsetsTest()
		{
			var instance = new LeetCode78SubSets();
			var data = new int[] { 1, 2, 3 };
			var result = instance.Subsets(data);
			Assert.AreEqual(8, result.Count);
			var expectedData = TestHelper.GetListList("[[],[1],[2],[1,2],[3],[1,3],[2,3],[1,2,3]]");
			TestHelper.CompareResult(expectedData, result);
		}

		[TestMethod()]
		public void Subsets1Test()
		{
			var instance = new LeetCode78SubSets();
			var data = new int[] { 1, 2, 3 };
			var result = instance.Subsets1(data);
			Assert.AreEqual(8, result.Count);
			var expectedData = TestHelper.GetListList("[[],[1],[2],[1,2],[3],[1,3],[2,3],[1,2,3]]");
			TestHelper.CompareResult(expectedData, result);
		}
	}
}