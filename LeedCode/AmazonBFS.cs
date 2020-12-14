using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace LeedCode
{
	public class AmazonBFS
	{
		public class TreeNode
		{
			public int distance;
			public TreeNode parent;
			public TreeNode left;
			public TreeNode right;
			public bool IsVisited = false;
			public int X;
			public int Y;
			public TreeNode(int distance, int x, int y)
			{
				this.distance = distance;
				this.X = x;
				this.Y = y;
			}
		}
		public static int GetShortestDistance(int[,] matrix)
		{
			var matrixRowLength = matrix.GetLength(0);
			var matrixColLength = matrix.GetLength(1);

			//int[4,5]
			Debug.Assert(matrixRowLength == 4);
			Debug.Assert(matrixColLength == 5);
			
			var rootTreeNode = new TreeNode(0, 0, 0);
			rootTreeNode.parent = null;

			int shortestLength = BFS(rootTreeNode, matrix);

			return shortestLength;
		}


		private static int BFS(TreeNode rootNode, int[,] data)
		{
			Queue<TreeNode> q = new Queue<TreeNode>();
			q.Enqueue(rootNode);

			var matrixRowLength = data.GetLength(0);
			var matrixColLength = data.GetLength(1);

			Debug.Assert(matrixColLength == 5);
			Debug.Assert(matrixRowLength == 4);

			int[] delx = { 0, 0, -1, 1 };
			int[] dely = { 1, -1, 0, 0 };
			bool[,] isVisitedTreeNode = new bool[matrixRowLength, matrixColLength];
			while (q.Count > 0)
			{
				var selectedTreeNode = q.Dequeue();
				selectedTreeNode.IsVisited = true;
				isVisitedTreeNode[selectedTreeNode.X, selectedTreeNode.Y] = true;
				if (data[selectedTreeNode.X, selectedTreeNode.Y] == 9)
					return selectedTreeNode.distance;
				for (int i = 0; i < 4; i++)
				{
					int next_x = selectedTreeNode.X + delx[i];
					int next_y = selectedTreeNode.Y + dely[i];
					if(next_x<0 ||next_x> matrixColLength || next_y<0 ||next_y>matrixRowLength)
						continue;
					if (data[next_x, next_y] != 0 && !isVisitedTreeNode[next_x,next_y])
					{
						TreeNode newNode = new TreeNode(selectedTreeNode.distance +1, next_x, next_y);
						newNode.parent = selectedTreeNode;
						q.Enqueue(newNode);
					}
				}
			}

			return -1;
		}


		//METHOD SIGNATURE BEGINS, THIS METHOD IS REQUIRED
		public static int[] cellCompete(int[] states, int days)
		{
			if (states == null || days < 0)
				return null;
			if (days == 0)
				return states;
			int[] newStates = new int[states.Length];

			for (int i = 0; i < days; i++)
			{
				for (int j = 0; j < states.Length; j++)
				{
					int previous = 0;
					int next = 0;

					if (j != 0)
						previous = states[j - 1];
					if (j != states.Length - 1)
						next = states[j + 1];
					if (previous != next)
						newStates[j] = 1;
					else
						newStates[j] = 0;
				}

				states = (int[])newStates.Clone();
			}

			return newStates;
		}
		// METHOD SIGNATURE ENDS

		public static  int generalizedGCD(int num, int[] arr)
		{
			List<int> newArray = arr.ToList();
			List<int> newRemovedArray = new List<int>();
			do
			{
				newRemovedArray = new List<int>();
				int smallestValue = newArray.Min();

				for (int i = 0; i < newArray.Count; i++)
				{
					if (newArray[i] == smallestValue)
					{
						newRemovedArray.Add(smallestValue);
						continue;
					}
						
					int restValue = newArray[i] - smallestValue;
					if (restValue != 0 && restValue != smallestValue)
					{
						newRemovedArray.Add(restValue);
					}
				}

				newArray = new List<int>(newRemovedArray);

			} while (newRemovedArray.Count > 1);

			return newRemovedArray[0];
		}

		public static int generalizedGCDMax(int num, int[] arr)
		{
			// WRITE YOUR CODE HERE
			int maxNumber = 1;
			for (int i = 1; i <= arr.Min(); i++)
			{

				for (int j = 0; j < arr.Length; j++)
				{
					if (arr[j] % i != 0)
						break;
					if (j == arr.Length - 1)
						maxNumber = i;
				}
			}

			return maxNumber;
		}


	}
}
