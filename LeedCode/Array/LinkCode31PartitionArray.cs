using System.Collections.Generic;
using LeedCode.AFeature;

namespace LeedCode.Array
{
	//	Given an array nums of integers and an int k, partition the array(i.e move the elements in "nums") such that:

	//	All elements<k are moved to the left
	//	All elements >= k are moved to the right
	//	Return the partitioning index, i.e the first index i nums[i] >= k.

	//Example
	//If nums = [3, 2, 2, 1] and k = 2, a valid answer is 1.

	//Challenge
	//Can you partition the array in-place and in O(n)?

	//Notice
	//You should do really partition in array nums instead of just counting the numbers of integers smaller than k.

	//If all elements in nums are smaller than k, then return nums.length
	public class LinkCode31PartitionArray : LintCode
	{
		/**
	* @param nums: The integer array you should partition
	* @param k: An integer
	* @return: The index after partition
	*/
		public int partitionArray1(int[] nums, int k)
		{
			// write your code here
			int index = 0;

			if (nums == null || k <= 0 || nums.Length < 1)
				return index;

			List<int> numsList = new List<int>(nums);
			List<int> beforeKList = new List<int>();
			List<int> afterKList = new List<int>();

			for (int i = 0; i < nums.Length; i++)
			{
				if(numsList[i] <k)
					beforeKList.Add(numsList[i]);
				if (numsList[i] >=k)
					afterKList.Add(numsList[i]);
			}
			index = beforeKList.Count;
			beforeKList.AddRange(afterKList);
			nums = beforeKList.ToArray();
			return index;
		}

		public int partitionArray2(int[] nums, int k)
		{
			// write your code here
			int index = 0;

			if (nums == null || k <= 0 || nums.Length < 1)
				return index;

			int leftPointer = 0;
			int rightPointer = nums.Length-1;
			while (leftPointer <= rightPointer)
			{
				while (leftPointer <= rightPointer && nums[leftPointer] < k)
				{
					leftPointer++;
				}
				while (leftPointer <= rightPointer && nums[rightPointer] >=k)
				{
					rightPointer--;
				}
				if (leftPointer <= rightPointer )
				{
					int tempValue = nums[leftPointer];
					nums[leftPointer] = nums[rightPointer];
					nums[rightPointer] = tempValue;
					leftPointer++;
					rightPointer--;
				}
			}

			return leftPointer;

		}

		public int NumberLintCode => 31;
		public string UrlLintCode => "https://www.lintcode.com/problem/partition-array/";
	}
}
