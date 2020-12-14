using LeedCode.ABaseClass;
using LeedCode.AFeature;
using System;

namespace LeedCode.String
{
	public class _563_Binary_Tree_Tilt : LeetCode
	{
		public int NumberLeetCode => 563;

		public string UrlLeetCode => "https://leetcode.com/problems/binary-tree-tilt/";


		public int FindTilt(TreeNode root)
		{
			if (root == null)
				return 0;

			int result = 0;
			int valueSum = CalculateTilt(root, ref result);

			return result;
		}

		//Recursive with return value
		private int CalculateTilt(TreeNode root, ref int sumResult)
		{
			if (root == null)
			{
				return 0;
			}

			int leftSum = CalculateTilt(root.left, ref sumResult);
			int rightSum = CalculateTilt(root.right, ref sumResult);
			//Console.WriteLine("root:" + root.val + " leftSum:" + leftSum + " rightSum" + rightSum);
			int currentResult = Math.Abs(leftSum - rightSum);
			sumResult = sumResult + currentResult;
			//Console.WriteLine("root:" + root.val + " leftSum:" + leftSum + " rightSum" + rightSum + "currentResult : " + currentResult + "sumResult " + sumResult);

			return leftSum + rightSum + root.val;

		}
	}
}
