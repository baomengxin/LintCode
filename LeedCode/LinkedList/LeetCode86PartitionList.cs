using LeedCode.AFeature;

namespace LeedCode.LinkedList
{
	/// <summary>
	///Given a linked list and a value x, partition it such that all nodes less than x come before nodes greater than or equal to x.

	///You should preserve the original relative order of the nodes in each of the two partitions.

	//Example:

	//Input: head = 1->4->3->2->5->2, x = 3
	//Output: 1->2->2->4->3->5
	/// </summary>
	public class LeetCode86PartitionList : LeetCode
	{
		public int NumberLeetCode => 86;
		public string UrlLeetCode => "https://leetcode.com/problems/partition-list/";

		/*
		* Definition for singly-linked list.
		*/
		public class ListNode
		{
			public int val { get; set; }
			public ListNode next { get; set; }

			public ListNode(int x)
			{
				val = x;
			}
		}

		/// <summary>
		/// Pointer problem: should initialize one pointer with initial value and use its next value to calculate;
		/// </summary>
		/// <param name="head"></param>
		/// <param name="x"></param>
		/// <returns></returns>
		public ListNode Partition(ListNode head, int x)
		{
			if (head == null)
				return null;
			ListNode headCopy = head;
			ListNode beforeXNode = new ListNode(0);
			var beforeXNodePointer = beforeXNode;
			ListNode afterXNodes = new ListNode(0);
			var afterXNodePointer = afterXNodes;
			while (headCopy != null)
			{
				if (headCopy.val < x)
				{
					beforeXNode.next = headCopy;
					beforeXNode = beforeXNode.next;
				}

				if (headCopy.val >= x)
				{
					afterXNodes.next = headCopy;
					afterXNodes = afterXNodes.next;
				}

				headCopy = headCopy.next;

			}
			// Last node of "after" list would also be ending node of the reformed list
			afterXNodes.next = null;

			beforeXNode.next = afterXNodePointer.next;
			return beforeXNodePointer.next;
		}
	}

}
