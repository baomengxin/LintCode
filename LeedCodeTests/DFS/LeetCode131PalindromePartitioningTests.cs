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
	public class LeetCode131PalindromePartitioningTests
	{
		[TestMethod()]
		public void PartitionTest()
		{
			var instance = new LeetCode131PalindromePartitioning();

			var result = instance.Partition("efe");

			Assert.AreEqual(result.Count, 2);
		}
	}
}