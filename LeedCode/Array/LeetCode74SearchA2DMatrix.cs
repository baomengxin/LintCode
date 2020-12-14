using LeedCode.AFeature;
using System;

namespace LeedCode.Array
{
	public class LeetCode74SearchA2DMatrix : LeetCode, LintCode, Amazon, Medium
	{
		public int NumberLeetCode => 74;

		public string UrlLeetCode => "https://leetcode.com/problems/search-a-2d-matrix/";

		public int NumberLintCode => 28;

		public string UrlLintCode => "https://www.lintcode.com/problem/search-a-2d-matrix/description?_from=ladder&&fromId=131"
;

		public int Time => throw new NotImplementedException();


		public bool SearchMatrix(int[][] matrix, int target)
		{
			if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0)
				return false;

			bool result = false;

			int beginIndex = 0;
			int endIndex = matrix.Length;
			int width = matrix[0].Length;
			while (beginIndex + 1 < endIndex)
			{
				int middleIndex = beginIndex + (endIndex - beginIndex) / 2;

				if (matrix[middleIndex][0] == target)
					return true;

				if (matrix[middleIndex][0] > target)
				{
					endIndex = middleIndex;
				}
				else if (matrix[middleIndex][width - 1] == target)
				{
					return true;
				}
				else if (matrix[middleIndex][width - 1] < target)
				{
					beginIndex = middleIndex;
				}
				else
					break;
			}

			int selectedRow = beginIndex + (endIndex - beginIndex) / 2;

			beginIndex = 0;
			endIndex = width;

			// Console.WriteLine("here");
			while (beginIndex + 1 < endIndex)
			{
				int middle = beginIndex + (endIndex - beginIndex) / 2;
				int middleNumber = matrix[selectedRow][middle];

				if (middleNumber == target)
					return true;
				if (middleNumber > target)
				{
					endIndex = middle;
				}
				else
				{
					beginIndex = middle;
				}
			}

			int selectedIndex = beginIndex + (endIndex - beginIndex) / 2;
			if (matrix[selectedRow][selectedIndex] == target)
			{
				return true;
			}

			return result;
		}
	}
}
