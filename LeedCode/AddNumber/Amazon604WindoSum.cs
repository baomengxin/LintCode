using System;
using LeedCode.AFeature;

namespace LeedCode
{
//	Description
//	Given an array of n integers, and a moving window(size k), move the window at each iteration from the start of the array, find the sum of the element inside the window at each moving.

//	Have you met this question in a real interview?
//	Example
//	For array [1,2,7,8,5], moving window size k = 3.
//1 + 2 + 7 = 10
//2 + 7 + 8 = 17
//7 + 8 + 5 = 20
//return [10,17,20]
	public class Amazon604WindoSum : Amazon, LintCode, LeetCode
	{
		public int[] GetWindowSum(int[] listNumber, int lengthWindow)
		{
			if (listNumber.Length < lengthWindow)
				return new int[0];
			int numberOfSum = listNumber.Length - lengthWindow + 1;
			int[] sumNumberList = new int[numberOfSum];
			for (int i = 0; i < numberOfSum; i++)
			{
				int sum = 0;
				if (i == 0)
				{
					for (int j = 0; j < lengthWindow; j++)
					{
						sum += listNumber[j];
					}

					sumNumberList[i] = sum;
				}
				else
				{
					sumNumberList[i] = sumNumberList[i - 1] - listNumber[i - 1] + listNumber[i + lengthWindow - 1];
				}
			}
			return sumNumberList;
		}

		public int NumberLintCode => 604;
		public string UrlLintCode => "https://www.lintcode.com/problem/window-sum/description";
		public int NumberLeetCode => 239;
		public string UrlLeetCode=> "https://leetcode.com/problems/sliding-window-maximum/";

		public int[] MaxSlidingWindow(int[] nums, int k)
		{
			if (nums == null || k > nums.Length)
				return new int[] { };
			int maxSum = 0;
			int leftValue =0;
			int[] result = new int[nums.Length-k+1];
			for (int i = 0; i < nums.Length; i++)
			{
				
				if (i < k-1)
					maxSum += nums[i];
				else
				{
					maxSum = maxSum - leftValue + nums[i];
					result[i - k+1] = maxSum;
					leftValue = nums[i-k+1];
				}
			}

			return result;
		}
	}
}
