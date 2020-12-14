using LeedCode.AFeature;
using System;

namespace LeedCode.Array
{

	//Given n non-negative integers representing an elevation map where the width of each bar is 1, 
	//compute how much water it can trap after raining.
	public class LeetCode42TrappingRainWater : LeetCode, Hard
	{
		public int Time => throw new NotImplementedException();

		public int NumberLeetCode => 42;

		public string UrlLeetCode => "https://leetcode.com/problems/trapping-rain-water/";

		// First Try
		//Brute Force : for each cell, try to find the left height and right height, and then add them together. 
		public int Trap(int[] height)
		{
			int result = 0;
			if (height.Length == 0)
				return result;
			int[] leftMostHeight = new int[height.Length];
			int[] rightMostHeight = new int[height.Length];


			int leftTmp = height[0];
			for (int i = 1; i < height.Length; i++)
			{
				leftMostHeight[i] = leftTmp;
				leftTmp = Math.Max(leftTmp, height[i]);
			}

			int rightTmp = height[height.Length - 1];
			for (int i = height.Length - 2; i > 0; i--)
			{
				rightMostHeight[i] = rightTmp;
				rightTmp = Math.Max(rightTmp, height[i]);
			}

			for (int i = 1; i < height.Length - 1; i++)
			{
				int leftHeight = leftMostHeight[i];
				int rightHeiht = rightMostHeight[i];
				result += Math.Max((Math.Min(leftHeight, rightHeiht) - height[i]), 0);
			}

			return result;
		}


	}
}
