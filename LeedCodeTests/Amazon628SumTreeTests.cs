using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeedCode.Tests
{
	[TestClass()]
	public class Amazon628SumTreeTests
	{

		//Given a binary tree:

		// 	 1
		// /   \
		//-5     2
		// \   /  \
	    //0   3 -4  -5
		//return the node with value 3.
		[TestMethod()]
		public void GetMaxSubTreeNode1Test()
		{
			var sumbTreeNode = new Amazon628SumTree();
			Amazon628SumTree.TreeNode rootTreeNode  = new Amazon628SumTree.TreeNode(1);
			Amazon628SumTree.TreeNode treeNode1 = new Amazon628SumTree.TreeNode(-5);
			Amazon628SumTree.TreeNode treeNode2 = new Amazon628SumTree.TreeNode(0);
			Amazon628SumTree.TreeNode treeNode3 = new Amazon628SumTree.TreeNode(3);
			Amazon628SumTree.TreeNode treeNode4 = new Amazon628SumTree.TreeNode(2);
			Amazon628SumTree.TreeNode treeNode5 = new Amazon628SumTree.TreeNode(-4);
			Amazon628SumTree.TreeNode treeNode6 = new Amazon628SumTree.TreeNode(-5);

			rootTreeNode.LeftNode = treeNode1;
			rootTreeNode.RightNode= treeNode4;
			treeNode1.RightNode= treeNode3;
			treeNode1.LeftNode= treeNode2;
			treeNode4.LeftNode= treeNode5;
			treeNode4.RightNode= treeNode6;

			var selectedTreeNode = sumbTreeNode.GetMaxSubTreeNode1(rootTreeNode);
			Assert.IsNotNull(selectedTreeNode);
			Assert.AreEqual(selectedTreeNode, treeNode3);
		}

		[TestMethod()]
		public void GetMaxSubTreeNodeTest()
		{
			var sumbTreeNode = new Amazon628SumTree();
			Amazon628SumTree.TreeNode rootTreeNode = new Amazon628SumTree.TreeNode(1);
			Amazon628SumTree.TreeNode treeNode1 = new Amazon628SumTree.TreeNode(-5);
			Amazon628SumTree.TreeNode treeNode2 = new Amazon628SumTree.TreeNode(0);
			Amazon628SumTree.TreeNode treeNode3 = new Amazon628SumTree.TreeNode(3);
			Amazon628SumTree.TreeNode treeNode4 = new Amazon628SumTree.TreeNode(2);
			Amazon628SumTree.TreeNode treeNode5 = new Amazon628SumTree.TreeNode(-4);
			Amazon628SumTree.TreeNode treeNode6 = new Amazon628SumTree.TreeNode(-5);

			rootTreeNode.LeftNode = treeNode1;
			rootTreeNode.RightNode = treeNode4;
			treeNode1.RightNode = treeNode3;
			treeNode1.LeftNode = treeNode2;
			treeNode4.LeftNode = treeNode5;
			treeNode4.RightNode = treeNode6;

			var selectedTreeNode = sumbTreeNode.GetMaxSubTreeNode(rootTreeNode);
			Assert.IsNotNull(selectedTreeNode);
			Assert.AreEqual(selectedTreeNode, treeNode3);
		}
	}
}