using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeedCode.Array.Tests
{
	[TestClass()]
	public class LinkCode31PartitionArrayTests
	{
		[TestMethod()]
		public void partitionArrayTest1()
		{
			var partitionInstance = new LinkCode31PartitionArray();
			var testNumbers = new int[]{3, 2, 2, 1};
			var result = partitionInstance.partitionArray1(testNumbers, 2);
			Assert.IsNotNull(result);
			Assert.AreEqual(1,result);
		}

		[TestMethod()]
		public void partitionArrayTest2()
		{
			var partitionInstance = new LinkCode31PartitionArray();
			var testNumbers = new int[] { 3, 2, 2, 1 };
			var result = partitionInstance.partitionArray2(testNumbers, 2);
			Assert.IsNotNull(result);
			Assert.AreEqual(1, result);
		}


		//why should we add =
		[TestMethod()]
		public void partitionArrayTest3()
		{
			var partitionInstance = new LinkCode31PartitionArray();
			var testNumbers = new int[] { 7, 7, 9, 8, 6, 6, 8, 7, 9, 8, 6, 6 };
			var result = partitionInstance.partitionArray2(testNumbers, 10);
			Assert.IsNotNull(result);
			Assert.AreEqual(12, result);
		}
	}
}