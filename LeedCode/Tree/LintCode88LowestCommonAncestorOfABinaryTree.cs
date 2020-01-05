//using System.Collections.Generic;
//using LeedCode.ABaseClass;
//using LeedCode.Feature;

//namespace LeedCode.Tree
//{

//	//Given the root and two nodes in a Binary Tree.Find the lowest common ancestor(LCA) of the two nodes.

//	//The lowest common ancestor is the node with largest depth which is the ancestor of both nodes.

//	//Example
//	//For the following binary tree:

//	//	4
//	// / \
//	//3   7
//	//   / \
//	//  5   6
//	//LCA(3, 5) = 4

//	//LCA(5, 6) = 7

//	//LCA(6, 7) = 7

//	//Notice
//	//Assume two nodes are exist in tree.
//	public class LintCode88LowestCommonAncestorOfABinaryTree : LintCode, Amazon
//	{
//		public int NumberLintCode => 88;
//		public string UrlLintCode => "https://www.lintcode.com/problem/lowest-common-ancestor-of-a-binary-tree/description";
//		/*
//	* @param root: The root of the binary search tree.
//	* @param A: A TreeNode in a Binary.
//	* @param B: A TreeNode in a Binary.
//	* @return: Return the least common ancestor(LCA) of the two nodes.
//	*/
//		public TreeNode lowestCommonAncestor(TreeNode root, TreeNode A, TreeNode B)
//		{
//			Dictionary<TreeNode, int> TreeNodeWithItsDepthDictionary = new Dictionary<TreeNode, int>();
//			TreeNode rootCopy = root;

//			Stack<TreeNode> treeNodeStack = new Stack<TreeNode>();
//			treeNodeStack.Push(root);
//			int depth = 0;
//			bool findOneNode = false;
			
//			//遍历左子树
//			while (treeNodeStack.Count != 0)
//			{
//				var nodeSelected = treeNodeStack.Pop();
//				if (!TreeNodeWithItsDepthDictionary.ContainsKey(nodeSelected))
//				{
//					TreeNodeWithItsDepthDictionary.Add(nodeSelected, depth);
//				}

//				if (nodeSelected == A || nodeSelected == B)
//				{
//					findOneNode = true;
//				}
//			}
//		}

//		public TreeNode lowestCommonAncestor1(TreeNode root, TreeNode p, TreeNode q)
//		{
//			if (root == null) return null;
//			if (root == p) return p;
//			if (root == q) return q;

//			TreeNode left = lowestCommonAncestor(root.left, p, q);
//			TreeNode right = lowestCommonAncestor(root.right, p, q);

//			if (left != null && right != null) return root;
//			return left != null ? left : right;
//		}

//		// 在root为根的二叉树中找A,B的LCA:
//		// 如果找到了就返回这个LCA
//		// 如果只碰到A，就返回A
//		// 如果只碰到B，就返回B
//		// 如果都没有，就返回null
//		public TreeNode lowestCommonAncestor3(TreeNode root, TreeNode node1, TreeNode node2)
//		{
//			if (root == null || root == node1 || root == node2)
//			{
//				return root;
//			}

//			// Divide
//			TreeNode left = lowestCommonAncestor(root.left, node1, node2);
//			TreeNode right = lowestCommonAncestor(root.right, node1, node2);

//			// Conquer
//			if (left != null && right != null)
//			{
//				return root;
//			}
//			if (left != null)
//			{
//				return left;
//			}
//			if (right != null)
//			{
//				return right;
//			}
//			return null;
//		}
//	}
//}
