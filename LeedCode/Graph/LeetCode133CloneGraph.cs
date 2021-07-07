using LeedCode.ABaseClass;
using LeedCode.AFeature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeedCode.Graph
{
	public class LeetCode133CloneGraph : LeetCode, Medium
	{
		public int Time => throw new NotImplementedException();

		public int NumberLeetCode => 133;

		public string UrlLeetCode => "https://leetcode.com/problems/clone-graph/";



		public Node CloneGraph(Node node)
		{
			// Find all the nodes 
			HashSet<Node> nodes = new HashSet<Node>();
			FindNodes(node,ref  nodes);

			// Clone Nodes 
			Dictionary<Node, Node> dic = new Dictionary<Node, Node>();
			CloneNodes(nodes, dic);

			CloneEdges(nodes, dic);

			return dic[node];
		}

		private void CloneEdges(HashSet<Node> nodes, Dictionary<Node, Node> dic)
		{
			foreach (var node in nodes)
			{
				var newNode = dic[node];
				foreach (var neighbour in node.neighbors)
				{
					newNode.neighbors.Add(dic[neighbour]);
				}
			}
		}

		private void CloneNodes(HashSet<Node> nodes, Dictionary<Node, Node> dic)
		{
			foreach (var node in nodes)
			{
				var newNode = new Node();
				newNode.val = node.val;
				dic.Add(node, newNode);
			}
		}

		private void FindNodes(Node node, ref HashSet<Node> nodes)
		{
			if (nodes.Contains(node))
				return;
			nodes.Add(node);

			foreach (var child in node.neighbors)
			{
				FindNodes(child, ref nodes);
			}
		}

		public Node CloneGraph1(Node node)
		{
			if (node == null)
				return null;
			if (node.neighbors.Count == 0)
				return new Node(node.val);
			Node root = new Node();

			Dictionary<Node, Tuple<Node, bool>> nodes = new Dictionary<Node, Tuple<Node, bool>>();
			Stack<Node> nodesToCopy = new Stack<Node>();
			nodesToCopy.Push(node);
			while (nodesToCopy.Count > 0)
			{
				var nodeToCopy = nodesToCopy.Pop();
				if (!nodes.ContainsKey(nodeToCopy))
				{
					var newNode = new Node(nodeToCopy.val);
					nodes.Add(nodeToCopy, new Tuple<Node, bool>(newNode, false));
					if (nodeToCopy.neighbors.Count > 0)
					{
						foreach (var neighbor in nodeToCopy.neighbors)
						{
							nodesToCopy.Push(neighbor);
						}
					}
				}
			}
			nodesToCopy.Push(node);
			root = nodes[node].Item1;
			while (nodesToCopy.Count > 0)
			{
				var nodeToCopy = nodesToCopy.Pop();

				if (!nodes[nodeToCopy].Item2)
				{
					var newNode = nodes[nodeToCopy];
					if (nodeToCopy.neighbors.Count > 0)
					{
						foreach (var neighbor in nodeToCopy.neighbors)
						{
							nodesToCopy.Push(neighbor);
							newNode.Item1.neighbors.Add(nodes[neighbor].Item1);
						}
					}
					nodes[nodeToCopy] = new Tuple<Node, bool>(newNode.Item1, true);
				}
			}
			return root;
		}

	}
}
