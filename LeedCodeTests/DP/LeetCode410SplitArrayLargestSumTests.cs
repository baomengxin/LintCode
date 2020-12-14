using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeedCode.DP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeedCode.DP.Tests
{
	[TestClass()]
	public class LeetCode410SplitArrayLargestSumTests
	{
		[TestMethod()]
		public void SplitArrayTest()
		{
			var instance = new LeetCode410SplitArrayLargestSum();


			var data = new int[] { 7, 2, 5, 10, 8 };

			var result = instance.SplitArray(data, 2);
			Assert.AreEqual(18, result);
		}
	}
}