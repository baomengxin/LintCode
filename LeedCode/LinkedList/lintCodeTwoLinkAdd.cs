using LeedCode.Feature;

namespace LeedCode.LinkedList
{
	public	class LeetCode2AddTwoNumbers : Amazon, LeetCode
	{
		public int NumberLeetCode => 2;
		public string UrlLeetCode => "https://leetcode.com/problems/add-two-numbers/";


		public LeetCode86PartitionList.ListNode AddTwoNumbers(LeetCode86PartitionList.ListNode l1, LeetCode86PartitionList.ListNode l2)
		{
			if (l1 == null && l2 == null)
				return null;
			LeetCode86PartitionList.ListNode listNodeToReturn = new LeetCode86PartitionList.ListNode(0);
			LeetCode86PartitionList.ListNode listToAdd = listNodeToReturn;
			LeetCode86PartitionList.ListNode l1Copy = l1;
			LeetCode86PartitionList.ListNode l2Copy = l2;
			bool needNextNumberPlus1 = false;
        
			while (l1Copy != null || l2Copy != null){
				int number1 = l1Copy?.val ?? 0;
				int number2 = l2Copy?.val ?? 0;
				int sumNumber = number1 + number2;
				if (needNextNumberPlus1)
				{
					needNextNumberPlus1 = false;
					sumNumber++;
				}
					
				if (sumNumber >= 10)
				{
					needNextNumberPlus1 = true;
					sumNumber = sumNumber % 10;
				}

				listToAdd.next = new LeetCode86PartitionList.ListNode(sumNumber);
				listToAdd = listToAdd.next;
				l1Copy = l1Copy?.next ?? null;
				l2Copy = l2Copy?.next ?? null;
			}
			
			if(needNextNumberPlus1){
				listToAdd.next = new LeetCode86PartitionList.ListNode(1);
			}
			return listNodeToReturn.next;
		}

	}
}
