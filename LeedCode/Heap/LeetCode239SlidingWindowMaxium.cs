using LeedCode.AFeature;
using System.Collections.Generic;
using System.Linq;

namespace LeedCode.Heap
{

	//You are given an array of integers nums, there is a sliding window of size k which is moving from the very left of the array 
	//to the very right.You can only see the k numbers in the window. Each time the sliding window moves right by one position.

	//Return the max sliding window.
	public class LeetCode239SlidingWindowMaxium : LeetCode
	{
		public int NumberLeetCode => 239;

		public string UrlLeetCode => "https://leetcode.com/problems/sliding-window-maximum/";


		public class DecendComparer : IComparer<int>
		{
			public int Compare(int x, int y)
			{
				return y.CompareTo(x);
			}
		}

		public int[] MaxSlidingWindow(int[] nums, int k)
		{

			if (nums == null || nums.Length == 0 || k > nums.Length)
				return new int[0];

			int tmpMax = nums[0];

			SortedDictionary<int, HashSet<int>> heap = new SortedDictionary<int, HashSet<int>>(new DecendComparer());
			for (int i = 0; i < k; i++)
			{
				if (!heap.ContainsKey(nums[i]))
					heap.Add(nums[i], new HashSet<int>());
				heap[nums[i]].Add(i);
			}

			int[] result = new int[nums.Length - k + 1];

			result[0] = heap.FirstOrDefault().Key;
			for (int i = k; i < nums.Length; i++)
			{
				var valueToRemove = heap[nums[i - k]];
				valueToRemove.Remove(i - k);
				if (valueToRemove.Count == 0)
				{
					heap.Remove(nums[i - k]);
				}
				if (!heap.ContainsKey(nums[i]))
					heap.Add(nums[i], new HashSet<int>());
				heap[nums[i]].Add(i);
				result[i - k + 1] = heap.FirstOrDefault().Key;
			}

			return result;

		}

	}
}
