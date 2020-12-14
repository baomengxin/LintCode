using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeedCode.Graph.Tests
{
	[TestClass()]
	public class AmazonOAShoppingPatternTests
	{
		[TestMethod()]
		public void getMinScoreTest()
		{
			var instance = new AmazonOAShoppingPattern();
			var products_from = new int[] { 1, 2, 2, 3, 4, 5 };
			var products_to = new int[] { 2, 4, 5, 5, 5, 6 };
			var result = instance.getMinScore(6, 6, products_from, products_to);

			Assert.AreEqual(3, result);

			products_from[0] = 1;
			products_from[1] = 1;
			products_from[2] = 2;
			products_from[3] = 2;
			products_from[4] = 3;
			products_from[5] = 4;
			products_to[0] = 2;
			products_to[1] = 3;
			products_to[2] = 3;
			products_to[3] = 4;
			products_to[4] = 4;
			products_to[5] = 5;

			result = instance.getMinScore(6, 6, products_from, products_to);

			Assert.AreEqual(2, result);

		}
	}
}