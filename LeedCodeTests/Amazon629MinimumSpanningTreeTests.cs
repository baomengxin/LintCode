using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using LeedCode;

namespace LeedCode.Tests
{
	[TestClass()]
	public class Amazon629MinimumSpanningTreeTests
	{
		[TestMethod()]
		public void lowestCostTest()
		{
			
				Amazon629MinimumSpanningTree.Connection c1 = new Amazon629MinimumSpanningTree.Connection("A", "D", 1);
				Amazon629MinimumSpanningTree.Connection c2 = new Amazon629MinimumSpanningTree.Connection("A", "B", 3);
				Amazon629MinimumSpanningTree.Connection c3 = new Amazon629MinimumSpanningTree.Connection("D", "B", 3);
				Amazon629MinimumSpanningTree.Connection c4 = new Amazon629MinimumSpanningTree.Connection("B", "C", 1);
				Amazon629MinimumSpanningTree.Connection c5 = new Amazon629MinimumSpanningTree.Connection("C", "D", 1);
				Amazon629MinimumSpanningTree.Connection c6 = new Amazon629MinimumSpanningTree.Connection("E", "D", 6);
				Amazon629MinimumSpanningTree.Connection c7 = new Amazon629MinimumSpanningTree.Connection("C", "E", 5);
				Amazon629MinimumSpanningTree.Connection c8 = new Amazon629MinimumSpanningTree.Connection("C", "F", 4);
				Amazon629MinimumSpanningTree.Connection c9 = new Amazon629MinimumSpanningTree.Connection("E", "F", 2);
				List<Amazon629MinimumSpanningTree.Connection> list = new List<Amazon629MinimumSpanningTree.Connection>(){c1, c2, c3, c4, c5, c6, c7, c8, c9};
				var lowestCostInstance = new Amazon629MinimumSpanningTree();

				List<Amazon629MinimumSpanningTree.Connection> result = lowestCostInstance.lowestCost(list);
				Assert.IsNotNull(result);
				Assert.AreEqual(result.Count, 5);
		}

	}
}