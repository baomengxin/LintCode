using LeedCode.AFeature;

namespace LeedCode
{
	public class Amazon105CopyListWithRandomPointer : Amazon, LintCode
	{
		//Description
		//	A linked list is given such that each node contains an additional random pointer which could point to any node in the list or null.

		//Return a deep copy of the list.


		//	Challenge
		//	Could you solve it with O(1) space?


		//Definition for singly-linked list with a random pointer.
		public class RandomListNode
		{
			public int label;
			public RandomListNode next, random;

			public RandomListNode(int x)
			{
				this.label = x;
			}
		}

		/**
  * @param head: The head of linked list with a random pointer.
  * @return: A new head of a deep copy of the list.
  */
		public RandomListNode copyRandomList(RandomListNode head)
		{
			RandomListNode result = new RandomListNode(head.label);
			RandomListNode resultPointer = result;
			RandomListNode copyListNode = head;
			//copy the node firstly
			while (copyListNode.next != null)
			{
				RandomListNode newListNode = new RandomListNode(copyListNode.label);
				newListNode.next = copyListNode.next;
				copyListNode.next = newListNode;
				copyListNode = newListNode.next;
			}

			var copyRadomPointer = head;
			//copy the randompointer secondly;
			while (copyRadomPointer.next != null)
			{
				var pointNext = copyRadomPointer.next;
				pointNext.random = copyRadomPointer.random;
				copyRadomPointer = copyRadomPointer.next.next;
			}

			bool shouldAddToResult = false;
			RandomListNode newlyAddedNode;
			//remove repeatPointer
			while (head != null)
			{

				if (shouldAddToResult)
				{
					newlyAddedNode = head;
					resultPointer.next = newlyAddedNode;
					resultPointer = newlyAddedNode;

				}
				head = head.next;
				shouldAddToResult = !shouldAddToResult;

			}

			return result.next;

		}

		public int NumberLintCode => 105;
		public string UrlLintCode => "https://www.lintcode.com/problem/copy-list-with-random-pointer/description";
	}
}
