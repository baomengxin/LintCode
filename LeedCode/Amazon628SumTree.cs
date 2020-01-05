using System;
using System.Collections.Generic;

namespace LeedCode
{

	//Given a binary tree, find the subtree with maximum sum.Return the root of the subtree.
	//思路：求二叉树的最大子树和，返回子树根节点，在后续遍历的过程中计树的所有结点值的和。

	public class Amazon628SumTree
	{
		public class TreeNode
		{
			public int Value { get; set; }
			public TreeNode LeftNode { get; set; }
			public TreeNode RightNode { get; set; }
			public TreeNode(int val)
			{
				this.Value = val;
			}
		}

		public TreeNode SelectedTreeNode { get; set; }

		public int MaxSum = Int32.MinValue;

		public TreeNode GetMaxSubTreeNode(TreeNode rootTreeNode)
		{
			if (rootTreeNode == null) return rootTreeNode;

			SumTreeNode(rootTreeNode);
			return SelectedTreeNode;

		}

		private int SumTreeNode(TreeNode node)
		{
			if (node == null)
				return 0;

			int leftTreeNodeSum = SumTreeNode(node.LeftNode);
			int rightTreeNodeSum = SumTreeNode(node.RightNode);
			if (MaxSum < leftTreeNodeSum + rightTreeNodeSum + node.Value)
			{
				MaxSum = leftTreeNodeSum + rightTreeNodeSum + node.Value;
				SelectedTreeNode = node;
			}

			return node.Value + leftTreeNodeSum + rightTreeNodeSum;
		}

		public TreeNode GetMaxSubTreeNode1(TreeNode rootTreeNode)
		{
			if (rootTreeNode == null)
				return rootTreeNode;
			int maxSum = Int32.MinValue;
			Stack<TreeNode> treeNodesStack = new Stack<TreeNode>();
			treeNodesStack.Push(rootTreeNode);
			TreeNode selectedTreeNode = rootTreeNode;
			while (treeNodesStack.Count != 0)
			{
				var calculateTreeNode = treeNodesStack.Pop();
				int sumTreeNode = calculateTreeNode.Value;
				if (calculateTreeNode.LeftNode != null)
				{
					treeNodesStack.Push(calculateTreeNode.LeftNode);
					sumTreeNode += calculateTreeNode.LeftNode.Value;
				}

				if (calculateTreeNode.RightNode != null)
				{
					treeNodesStack.Push(calculateTreeNode.RightNode);
					sumTreeNode += calculateTreeNode.RightNode.Value;
				}

				if (sumTreeNode > maxSum)
				{
					maxSum = sumTreeNode;
					selectedTreeNode = calculateTreeNode;
				}
			}

			return selectedTreeNode;
		}
	}
}
