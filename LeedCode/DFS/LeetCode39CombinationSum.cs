using LeedCode.AFeature;
using System.Collections.Generic;

namespace LeedCode.DFS
{
	//Given an array of distinct integers candidates and a target integer target, 
	//return a list of all unique combinations of candidates where the chosen numbers sum to target.
	//You may return the combinations in any order.

	//The same number may be chosen from candidates an unlimited number of times. 
	//Two combinations are unique if the frequency of at least one of the chosen numbers is different.

	//It is guaranteed that the number of unique combinations that sum up to target is less than 150 combinations for the given input.
	public class LeetCode39CombinationSum : LeetCode
	{
		public int NumberLeetCode => 39;

		public string UrlLeetCode => "https://leetcode.com/problems/combination-sum/";



		public IList<IList<int>> CombinationSum(int[] candidates, int target)
		{
			if (candidates == null || candidates.Length == 0)
				return new List<IList<int>>();

			var currentList = new List<int>();
			var result = new List<IList<int>>();
			GetCombinationSumHelper(candidates, target, currentList, result, 0, 0);

			return result;
		}

		// First error: result contains duplicates 
		//[2,3,6,7] 7 => [[2,2,3],[2,3,2],[3,2,2],[7]]
		private void GetCombinationSumHelper(int[] candidates, int target, List<int> currentList, List<IList<int>> result, int currentSum, int index)
		{
			if (currentSum == target)
			{
				result.Add(new List<int>(currentList));
				return;
			}

			for (int i = index; i < candidates.Length; i++)
			{
				int currentNumber = candidates[i];
				if (target - currentSum < currentNumber)
					continue;

				var canAddTimes = (target - currentSum) / currentNumber;

				for (int j = 0; j < canAddTimes; j++)
				{
					currentList.Add(currentNumber);
					currentSum += currentNumber;
					GetCombinationSumHelper(candidates, target, currentList, result, currentSum, i + 1);
				}
				for (int j = 0; j < canAddTimes; j++)
				{
					currentList.RemoveAt(currentList.Count - 1);
					currentSum -= currentNumber;
				}
			}

		}

		// optimisation , sort the list firstly, then break whenever the target is smaller than the current number

		private void GetCombinationSumHelper1(int[] candidates, int target, List<int> currentList, List<IList<int>> result, int index)
		{
			if (0 == target)
			{
				result.Add(new List<int>(currentList));
				return;
			}

			for (int i = index; i < candidates.Length; i++)
			{
				int currentNumber = candidates[i];
				if (target < currentNumber)
					break;

				currentList.Add(currentNumber);
				target -= currentNumber;
				GetCombinationSumHelper1(candidates, target, currentList, result, i);
				currentList.RemoveAt(currentList.Count - 1);
				target += currentNumber;
			}
		}

		// First Time 
		public IList<IList<int>> CombinationSum1(int[] candidates, int target)
		{
			IList<IList<int>> result = new List<IList<int>>();
			List<int> nums = new List<int>();
			for (int i = 0; i < candidates.Length; i++)
			{
				nums.Add(candidates[i]);
			}
			Dfs(nums, target, 0, new List<int>(), result);

			return result;

		}

		private void Dfs(List<int> nums, int target, int index, List<int> list, IList<IList<int>> result)
		{
			if (target == 0)
			{
				result.Add(new List<int>(list));
				return;
			}
			if (index == nums.Count || target < 0)
			{
				return;
			}
			int num = nums[index];

			for (int i = 0; i * num <= target; i++)
			{
				target -= num * i;
				for (int j = 0; j < i; j++)
				{
					list.Add(num);
				}

				Dfs(nums, target, ++index, list, result);
				index--;
				for (int j = 0; j < i; j++)
				{
					list.RemoveAt(list.Count - 1);
				}

				target += num * i;
			}

		}
	}
}
