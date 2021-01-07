using LeedCode.ABaseClass;
using LeedCode.AFeature;
using System;

namespace LeedCode.Tree
{

	//   Given a binary tree, you need to compute the length of the diameter of the tree.
	//The diameter of a binary tree is the length of the longest path between any two nodes in a tree.
	//This path may or may not pass through the root.
	public class LeetCode543DiameterOfBinaryTree : LeetCode, LintCode
	{
		public int NumberLeetCode => 543;

		public string UrlLeetCode => "https://leetcode.com/problems/diameter-of-binary-tree/";

		public int NumberLintCode => 1181;

		public string UrlLintCode => "https://www.lintcode.com/problem/diameter-of-binary-tree/description?_from=ladder&&fromId=137";

		int _diameter = 0;
		TreeNode _root;


		// second time error: misunderstand of the notion of diameter , counted the node not the path 
		public int DiameterOfBinaryTree(TreeNode root)
		{
			if (root == null)
				return 0;
			if (_root == null)
				_root = root;

			int leftLength = DiameterOfBinaryTree(root.left);

			int rightLength = DiameterOfBinaryTree(root.right);

			_diameter = Math.Max(_diameter, (leftLength + rightLength));
			return root == _root? _diameter : Math.Max(leftLength, rightLength) + 1;
		}



/**********************************************************************************************/
		public int DiameterOfBinaryTree_2(TreeNode root)
		{
			int max = 0;
			GetDiameter(root, ref max);
			return max;
		}

		private int GetDiameter(TreeNode root, ref int max)
		{
			if (root == null)
			{
				return 0;
			}
			else
			{
				int leftHeight = GetDiameter(root.left, ref max);
				int rightHeight = GetDiameter(root.right, ref max);

				int currentNodeDiameter = leftHeight + rightHeight;
				max = Math.Max(max, currentNodeDiameter);

				return Math.Max(leftHeight, rightHeight) + 1;
			}
		}
	}
}
