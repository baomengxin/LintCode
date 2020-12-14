using LeedCode.AFeature;
using System.Collections.Generic;

namespace LeedCode.Array
{
	//Given an array of integers nums and an integer k, return the total number of continuous subarrays whose sum equals to k.
	public class LeetCode560SubarraySumEqualsK : LeetCode
	{
		public int NumberLeetCode => 560;

		public string UrlLeetCode => "https://leetcode.com/problems/subarray-sum-equals-k/";

		//Brute Force: Time Limited Exceed
		public int SubarraySum(int[] nums, int k)
		{
			if (nums == null || nums.Length == 0)
				return 0;

			int result = 0;
			for (int i = 0; i < nums.Length; i++)
			{
				for (int j = i; j < nums.Length; j++)
				{
					var sum = GetSum(nums, i, j);
					if (sum == k)
						result++;

				}
			}

			return result;

		}

		private int GetSum(int[] nums, int i, int j)
		{
			int sumUp = 0;
			for (int k = i; k <= j; k++)
			{
				sumUp += nums[k];
			}

			return sumUp;
		}




		//使用一个list记录所有sum的值  从i 到j 的sum 就是 list[j] - list[i-1]
		//Time Limited Exceed

		public int SubarraySum2(int[] nums, int k)
		{
			if (nums == null || nums.Length == 0)
				return 0;

			int result = 0;

			int[] sums = new int[nums.Length];

			int tmpSum = 0;
			for (int i = 0; i < nums.Length; i++)
			{
				tmpSum += nums[i];
				sums[i] = tmpSum;
			}

			for (int i = 0; i < nums.Length; i++)
			{
				for (int j = i; j < nums.Length; j++)
				{
					var sum = GetSum2(nums, i, j, sums);
					if (sum == k)
						result++;

				}
			}

			return result;

		}

		private int GetSum2(int[] nums, int i, int j, int[] sums)
		{
			if (i == 0)
				return sums[j];
			return sums[j] - sums[i - 1];
		}


		// use HashSet to remember all the combination pairs 
		public int SubarraySum3(int[] nums, int k)
		{
			if (nums == null || nums.Length == 0)
				return 0;

			int result = 0;

			Dictionary<int, int> dic = new Dictionary<int, int>();

			int tmpSum = 0;
			for (int i = 0; i < nums.Length; i++)
			{
				tmpSum += nums[i];


				if (tmpSum == k)
					result++;
				if (dic.ContainsKey(k - tmpSum))
				{
					result += dic[k - tmpSum];
				}

				if (!dic.ContainsKey(tmpSum))
				{
					dic.Add(tmpSum, 0);
				}
				dic[tmpSum]++;
			}

			return result;
		}

	}
}
