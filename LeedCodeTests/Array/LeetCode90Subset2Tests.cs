using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeedCode.Array.Tests
{
	[TestClass()]
	public class LeetCode90Subset2Tests
	{
		[TestMethod()]
		public void SubsetsWithDupTest()
		{
			var data = new int[] { 1, 2, 2 };

			var instance = new LeetCode90Subset2();

			var result = instance.SubsetsWithDup(data);

			Assert.IsNotNull(result);
			Assert.AreEqual(6, result.Count);
		}
	}
}