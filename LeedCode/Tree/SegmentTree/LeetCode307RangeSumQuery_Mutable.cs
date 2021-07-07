using LeedCode.AFeature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeedCode.Tree.SegmentTree
{
	public class LeetCode307RangeSumQuery_Mutable : LeetCode
	{
		public int NumberLeetCode => 307;

		public string UrlLeetCode => throw new NotImplementedException();


		// first version, time out 
		public class NumArray
		{

			//int[][] directions = new int[][] { new int[] { -1, 0 }, new int[] { 1, 0 }, new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 1 }, int[]{ 1, -1 }, new int[] { -1, 1 }, new int[] { -1, -1 } };

			private int[] _sumUP;

			private int[] _nums;

			public NumArray(int[] nums)
			{
				_nums = new int[nums.Length];

				_sumUP = new int[nums.Length];

				for (int i = 0; i < nums.Length; i++)
				{
					_nums[i] = nums[i];
					_sumUP[i] = i == 0 ? nums[i] : (_sumUP[i - 1] + nums[i]);
				}
			}

			public void Update(int index, int val)
			{
				var currentValue = _nums[index];

				var difference = currentValue - val;

				_nums[index] = val;

				for (int j = index; j < _nums.Length; j++)
				{
					_sumUP[j] -= difference;
				}
			}

			public int SumRange(int left, int right)
			{
				return _sumUP[right] - (left == 0 ? 0 : _sumUP[left - 1]);
			}
		}

		/**
		 * Your NumArray object will be instantiated and called as such:
		 * NumArray obj = new NumArray(nums);
		 * obj.Update(index,val);
		 * int param_2 = obj.SumRange(left,right);
		 */
	}





	// segment tree 
	public class NumArray2
	{

		public class SegmentTree
		{
			public SegmentTree _leftTree { set; get; }

			public SegmentTree _rightTree { set;  get; }

			public int leftRange { get;}

			public int rightRange { get; }

			public int sum { get; set; }

			public SegmentTree(int left, int right)
			{
				this.leftRange = left;
				this.rightRange = right;
				//InitTree(left, right, init, this);
			}


			public static  void InitTree(int left, int right, int[] init, SegmentTree root)
			{
				if(left == right)
				{
					root.sum = init[left];
				}

				int mid = left + (right - left) / 2;

				SegmentTree leftTree = new SegmentTree(left, mid);

				InitTree(left, mid, init, leftTree);

				SegmentTree rightTree = new SegmentTree(mid + 1, right);

				InitTree(mid + 1, right,  init , rightTree);


				root._leftTree = leftTree;

				root._rightTree = rightTree;
				root.sum = root._leftTree.sum + root._rightTree.sum;

			}

			public static  void UpdateTree(int index, int val, SegmentTree root)
			{
				if (index < root.leftRange || index > root.rightRange)
					return;

				if(index == root.leftRange && index == root.rightRange)
				{
					root.sum = val;
					return;
				}

				int mid = root.leftRange + (root.rightRange - root.leftRange) / 2;
				UpdateTree(index, val, root._leftTree);

				UpdateTree(index, val, root._rightTree);

				root.sum = root._leftTree.sum + root._rightTree.sum;
			}


			public int  GetRange(int left, int right)
			{
				if (left > rightRange || right < leftRange)
					return 0;
				if (left >= leftRange && right <= rightRange)
					return sum;

				int leftSum = _leftTree.GetRange(left, right);

				int rightSum = _rightTree.GetRange(left, right);

				return leftSum + rightSum;

				
			}


		}

		private SegmentTree root;
		public NumArray2(int[] nums)
		{
			root = new SegmentTree(0, nums.Length - 1);

			SegmentTree.InitTree(0, nums.Length - 1, nums, root);
		}

		public void Update(int index, int val)
		{
			SegmentTree.UpdateTree(index, val, root);
		}

		public int SumRange(int left, int right)
		{
			return root.GetRange(left, right);
		}
	}

	/**
	 * Your NumArray object will be instantiated and called as such:
	 * NumArray obj = new NumArray(nums);
	 * obj.Update(index,val);
	 * int param_2 = obj.SumRange(left,right);
	 */
}



