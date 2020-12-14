using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeedCode.DFS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeedCode.DFS.Tests
{
	[TestClass()]
	public class LeetCode39CombinationSumTests
	{
		[TestMethod()]
		public void CombinationSumTest()
		{
			var instance = new LeetCode39CombinationSum();

			int[] data = new int[] { 2, 3, 6, 7 };

			var result = instance.CombinationSum(data, 7);
			Assert.AreEqual( result.Count, 2);
		}
	}
}