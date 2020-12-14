using LeedCode.AFeature;
using System.Collections.Generic;
using System.Linq;

namespace LeedCode.DFS
{
	public class LeetCode47Permutation2 : LeetCode
	{
		public int NumberLeetCode => 47;

		public string UrlLeetCode => "https://leetcode.com/problems/permutations-ii/";
		// 
		public IList<IList<int>> PermuteUnique(int[] nums)
		{
			if (nums == null || nums.Length == 0)
				return new List<IList<int>>();

			List<IList<int>> result = new List<IList<int>>();

			List<int> current = new List<int>();

			bool[] used = new bool[nums.Length];
			nums = nums.OrderBy(a => a).ToArray();
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
				if (i != 0 && nums[i] == nums[i - 1] && !used[i - 1])
					continue;
				if (used[i])
					continue;
				current.Add(nums[i]);
				used[i] = true;
				GetPermute(nums, current, used, result);
				//error 1: as there are duplicates, use remove will remove the first elment, not the indexed element  
				current.RemoveAt(current.Count - 1);
				used[i] = false;
			}
		}
	}
}
