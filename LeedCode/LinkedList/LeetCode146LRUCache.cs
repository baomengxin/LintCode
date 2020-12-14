using LeedCode.AFeature;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeedCode.LinkedList
{
	public class LRUCache : LeetCode
	{
		public int NumberLeetCode => 146;

		public string UrlLeetCode => "https://leetcode.com/problems/lru-cache/";

		private int _capacity = 0;

		private Dictionary<int, LinkedListNode<Tuple<int,int>>> dict = new Dictionary<int, LinkedListNode<Tuple<int, int>>>();

		private LinkedList<Tuple<int, int>> list = new LinkedList<Tuple<int, int>>();

		public LRUCache(int capacity)
		{

			this._capacity = capacity;

		}

		public int Get(int key)
		{
			if (dict.ContainsKey(key))
			{
				var selectedNode = dict[key];
				list.Remove(selectedNode);
				list.AddFirst(selectedNode);
				return selectedNode.Value.Item2;
			}

			return -1;

		}

		public void Put(int key, int value)
		{

			if (_capacity == 0)
				return;
			if (dict.Count == _capacity && !dict.ContainsKey(key))
			{
				var selectedValue = list.Last();

				dict.Remove(selectedValue.Item1);

				list.RemoveLast();
			}

			if (dict.ContainsKey(key))
			{
				var selectedNode = dict[key];
				dict.Remove(key);
				list.Remove(selectedNode);
			}
			var newNode = new Tuple<int, int>(key, value);
			
			
			var firstNode = list.AddFirst(newNode);
			dict.Add(key, firstNode);

		}
	}
}
