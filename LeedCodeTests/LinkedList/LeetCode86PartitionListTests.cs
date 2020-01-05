using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeedCode.LinkedList.Tests
{
	[TestClass()]
	public class LeetCode86PartitionListTests
	{
		[TestMethod()]
		public void PartitionTest()
		{
			var partitionInstance = new LeetCode86PartitionList();
			var head = new LeetCode86PartitionList.ListNode(1);
			var head2 = new LeetCode86PartitionList.ListNode(4);
			var head3 = new LeetCode86PartitionList.ListNode(3);
			var head4 = new LeetCode86PartitionList.ListNode(2);
			var head5 = new LeetCode86PartitionList.ListNode(5);
			var head6 = new LeetCode86PartitionList.ListNode(2);
			head.next = head2;
			head2.next = head3;
			head3.next = head4;
			head4.next = head5;
			head5.next = head6;
			var restulListNodes = partitionInstance.Partition(head, 3);
			Assert.IsNotNull(restulListNodes);
			Assert.AreEqual(restulListNodes.val,1);
			Assert.AreEqual(restulListNodes.next.val,2);
			Assert.AreEqual(restulListNodes.next.next.val,2);
			Assert.AreEqual(restulListNodes.next.next.next.val, 4);
			Assert.AreEqual(restulListNodes.next.next.next.next.val, 3);
			Assert.AreEqual(restulListNodes.next.next.next.next.next.val, 5);
			Assert.AreEqual(restulListNodes.next.next.next.next.next.next, null);
		}
	}
}