using LeedCode.AFeature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeedCode.Array
{

	//Given a sorted array of n integers, find the starting and ending position of a given target value.

 //   If the target is not found in the array, return [-1, -1].
	public class LintCode61SearchForARange : LintCode, Medium
	{
		public int NumberLintCode => 61;

		public string UrlLintCode =>"https://www.lintcode.com/problem/search-for-a-range/description";

		public int Time => throw new NotImplementedException();

		/**
	* @param A: an integer sorted array
	* @param target: an integer to be inserted
	* @return: a list of length 2, [index1, index2]
	*/
		public int[] searchRange(int[] A, int target)
		{
			int[] result = new int[] { -1, -1 };
			// write your code here
			if (A == null || A.Length == 0)
				return result;

			int beginIndex = 0;
			int endIndex = A.Length - 1;

			while(beginIndex +1 < endIndex)
			{
				int middle = beginIndex + (endIndex - beginIndex) / 2;

				if(A[middle] == target)
				{
					endIndex = middle;
				}
				else if(A[middle] < target)
				{
					beginIndex = middle;
				}
				else
				{
					endIndex = middle;
				}
			}

			return result;

		}
	}
}
