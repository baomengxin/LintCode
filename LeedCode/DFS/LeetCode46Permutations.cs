using LeedCode.AFeature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeedCode.DFS
{
	public class LeetCode46Permutations : LeetCode
	{
		public int NumberLeetCode => 46;

		public string UrlLeetCode => "https://leetcode.com/problems/permutations/";

		public IList<IList<int>> Permute(int[] nums)
		{
			if (nums == null || nums.Length == 0)
				return new List<IList<int>>();

			List<IList<int>> result = new List<IList<int>>();

			List<int> current = new List<int>();

			bool[] used = new bool[nums.Length];
			GetPermute(nums, current, used, result);

			return result;
		}

		private void GetPermute(int[] nums, List<int> current, bool[] used, List<IList<int>> result)
		{
			if (nums.Length == current.Count)
			{
				result.Add(new List<int>(current));
				return;
			}

			for (int i = 0; i < nums.Length; i++)
			{
				if (used[i])
					continue;
				current.Add(nums[i]);
				used[i] = true;
				GetPermute(nums, current, used, result);
				current.Remove(nums[i]);
				used[i] = false;
			}
		}


		// quicker
		public IList<IList<int>> Permute1(int[] nums)
		{
			List<IList<int>> subsets = new List<IList<int>>();
			if (nums.Length == 1)
			{
				subsets.Add(new List<int> { nums[0] });
				return subsets;
			}

			Subsets(0, new List<int>(), nums.ToList(), subsets);

			return subsets;
		}

		public void Subsets(int index, List<int> currentSet, List<int> nums, List<IList<int>> subsets)
		{
			if (nums.Count == 0)
			{
				subsets.Add(currentSet.ToList());
				return;
			}

			for (int i = 0; i < nums.Count; i++)
			{
				int num = nums[i];
				currentSet.Add(num);
				nums.RemoveAt(i);

				Subsets(i, currentSet, nums, subsets);

				currentSet.RemoveAt(currentSet.Count - 1);
				nums.Insert(i, num);
			}
		}
	}
}
