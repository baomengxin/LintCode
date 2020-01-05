using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeedCode.LinkedList.Tests
{
	[TestClass()]
	public class LeetCode2AddTwoNumbersTests
	{
		[TestMethod()]
		public void AddTwoNumbersTest()
		{
			var addTwoNumbersList = new LeetCode2AddTwoNumbers();
			var testList1 = new LeetCode86PartitionList.ListNode(2);
			testList1.next = new LeetCode86PartitionList.ListNode(4);
			testList1.next.next = new LeetCode86PartitionList.ListNode(3);
			var testList2 = new LeetCode86PartitionList.ListNode(5);
			testList2.next = new LeetCode86PartitionList.ListNode(6);
			testList2.next.next = new LeetCode86PartitionList.ListNode(4);

			var resultList = addTwoNumbersList.AddTwoNumbers(testList1, testList2);
			Assert.IsNotNull(resultList);
			Assert.AreEqual(7,resultList.val);
			Assert.AreEqual(0,resultList.next.val);
			Assert.AreEqual(8,resultList.next.next.val);
		}
	}
}