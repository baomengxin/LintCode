using LeedCode.AFeature;
using System.Collections.Generic;

namespace LeedCode.Array
{

	//Given an integer array nums, return all possible subsets(the power set).

	//The solution set must not contain duplicate subsets.
	public class LeetCode78SubSets : LeetCode
	{
		public int NumberLeetCode => 78;

		public string UrlLeetCode => "https://leetcode.com/problems/subsets/";


		// First way to solve the problme : divide and conquer 
		public IList<IList<int>> Subsets(int[] nums)
		{

			List<IList<int>> result = new List<IList<int>>();

			if (nums == null || nums.Length == 0)
				return result;

			// int numElements = 0;
			int totalLayer = nums.Length;

			//int currentLayer = 0;




			result = GetSubSets(nums, 0, nums.Length - 1);
			result.Add(new List<int>());

			return result;
		}


		private List<IList<int>> GetSubSets(int[] nums, int beginIndex, int endIndex)
		{
			if (beginIndex == endIndex)
			{
				var newElement = new List<int>() { nums[beginIndex] };

				//result.Add(newElement);
				//return result;
				return new List<IList<int>>() { newElement };
			}

			var tmpResult = new List<IList<int>>();
			if (beginIndex < endIndex)
			{
				var middleIndex = beginIndex + (endIndex - beginIndex) / 2;

				var listLeft = GetSubSets(nums, beginIndex, middleIndex);

				var listRight = GetSubSets(nums, middleIndex + 1, endIndex);
				tmpResult.AddRange(listLeft);
				tmpResult.AddRange(listRight);

				for (int i = 0; i < listLeft.Count; i++)
				{
					for (int j = 0; j < listRight.Count; j++)
					{
						var list = new List<int>(listLeft[i]);
						list.AddRange(listRight[j]);

						tmpResult.Add(list);
					}
				}
			}

			return tmpResult;

		}

		// DFS/SUBSET
		public IList<IList<int>> Subsets1(int[] nums)
		{
			List<IList<int>> results = new List<IList<int>>();

			if(nums == null || nums.Length == 0)
				return results;

			List<int> currentSet = new List<int>();
			GetSubsetsHelper(nums, currentSet, 0, results);

			return results;
		}


		
		private void GetSubsetsHelper(int[] nums, List<int> currentSet, int index, List<IList<int>> results)
		{
			//error 2 instead of create a list in the loop, we should copy the list here 
			//results.Add(currentSet);
			results.Add(new List<int>(currentSet));
			for(int i = index; i < nums.Length; i++)
			{
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
