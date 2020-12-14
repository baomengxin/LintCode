using LeedCode.AFeature;
using System;

namespace LeedCode.DP
{

	//	Given an array nums which consists of non-negative integers and an integer m, you can split the array into m non-empty 
	//		continuous subarrays.

	//Write an algorithm to minimize the largest sum among these m subarrays.
	public class LeetCode410SplitArrayLargestSum : LeetCode
	{
		public int NumberLeetCode => 410;

		public string UrlLeetCode => "https://leetcode.com/problems/split-array-largest-sum/";


		public int SplitArray(int[] nums, int m)
		{

			if (nums == null || nums.Length < m)
			{
				return 0;
			}

			if (m > nums.Length)
				return -1;

			int[][] dp = new int[nums.Length + 1][];

			for (int i = 0; i <= nums.Length; i++)
			{
				dp[i] = new int[m + 1];

				for (int j = 0; j <= m; j++)
				{
					dp[i][j] = Int32.MaxValue / 2;
				}
			}

			dp[0][0] = 0;

			for (int i = 0; i <= nums.Length; i++)
			{
				for (int j = 1; j <= m && j <= i + 1; j++)
				{
					int maxNumber = 0;

					for (int k = i - 1; k >= j - 1; k--)
					{
						maxNumber += nums[k];
						dp[i][j] = Math.Min(dp[i][j], Math.Max(dp[k][j - 1], maxNumber));

					}

					//Console.WriteLine(i + "; " +  j + " ; " + dp[i][j]);
				}
			}

			return dp[nums.Length][m];
		}
	}
}
