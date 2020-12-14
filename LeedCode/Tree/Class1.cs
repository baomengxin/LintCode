using LeedCode.ABaseClass;
using System;

namespace LeedCode.Tree
{
	class Class1
	{

		public int Rob(TreeNode root)
		{
			if (root == null)
				return 0;
			return TraverseTree(root).Item1;

		}

		private Tuple<int, int> TraverseTree(TreeNode root)
		{
			if (root == null)
				return new Tuple<int, int>(0, 0);

			Tuple<int, int> leftResult = TraverseTree(root.left);
			Tuple<int, int> rightResult = TraverseTree(root.right);

			int childResult = Math.Max(leftResult.Item1, leftResult.Item2) + Math.Max(rightResult.Item1, rightResult.Item2);
			
			int rootResult = leftResult.Item2 + rightResult.Item2 + root.val;
		
			return new Tuple<int, int>(rootResult, childResult);
		}
	}
}
