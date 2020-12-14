using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeedCode.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeedCode.Graph.Tests
{
	[TestClass()]
	public class LeetCode547FriendCircleTests
	{
		[TestMethod()]
		public void FindCircleNumTest()
		{
			var instance = new LeetCode547FriendCircle();

			var parameters = new int[][]
			{
				new int[]{1, 1, 0 },
				new int[]{1, 1, 0},
				new int[]{0, 0, 1}
			};
			Assert.AreEqual(2, instance.FindCircleNum(parameters));

			parameters = new int[][]
			{
				new int[]{1,0,0,1 },
				new int[]{0,1,1,0},
				new int[]{ 0, 1, 1, 1 },
				new int[]{ 1, 0, 1, 1 }
			};
			Assert.AreEqual(1, instance.FindCircleNum(parameters));
		}
	}
}