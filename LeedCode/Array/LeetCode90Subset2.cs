using LeedCode.AFeature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeedCode.Array
{
	public class LeetCode90Subset2 : LeetCode
	{
		public int NumberLeetCode => 90;

		public string UrlLeetCode => "https://leetcode.com/problems/subsets-ii/";

		public IList<IList<int>> SubsetsWithDup(int[] nums)
		{
			List<IList<int>> results = new List<IList<int>>();

			if (nums == null || nums.Length == 0)
				return results;

			List<int> currentSet = new List<int>();
			nums = nums.OrderBy(a => a).ToArray();
			GetSubsetsHelper(nums, currentSet, 0, results);

			return results;
		}

		private void GetSubsetsHelper(int[] nums, List<int> currentSet, int index, List<IList<int>> results)
		{
			//error 2 instead of create a list in the loop, we should copy the list here 
			//results.Add(currentSet);
			results.Add(new List<int>(currentSet));
			for (int i = index; i < nums.Length; i++)
			{
				if (i != index && nums[i] == nums[i - 1])
					continue;
				// Second error, should not create a new list here, 
				//else at the end of the process, as the newlist will remove the element, the results will also be changed
				//var newList = new List<int>(currentSet);

				//newList.Add(nums[i]);
				currentSet.Add(nums[i]);

				// First Error: pass i+1, instead of index = 1;
				//GetSubsetsHelper(nums, newList, i + 1, results);
				GetSubsetsHelper(nums, currentSet, i + 1, results);

				//newList.RemoveAt(newList.Count - 1);
				currentSet.RemoveAt(currentSet.Count - 1);
			}
		}
	}
}
