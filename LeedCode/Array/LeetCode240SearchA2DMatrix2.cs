using LeedCode.AFeature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeedCode.Array
{

	//Write an efficient algorithm that searches for a target value in an m x n integer matrix.The matrix has the following properties:

	//Integers in each row are sorted in ascending from left to right.
	//Integers in each column are sorted in ascending from top to bottom.
	public class LeetCode240SearchA2DMatrix2 : LeetCode
	{
		public int NumberLeetCode => 240;

		public string UrlLeetCode => "https://leetcode.com/problems/search-a-2d-matrix-ii/";

		public bool SearchMatrix(int[][] matrix, int target)
		{
			if (matrix == null || matrix.Length == 0)
				return false;
			int height = matrix.GetLength(0);
			int width = matrix.Length / matrix.GetLength(0);

			int xIndex = height - 1;
			int yIndex = 0;

			while (yIndex < width && xIndex >= 0)
			{
				if(matrix[xIndex][yIndex] < target)
				{
					yIndex++;
				}
				else if (matrix[xIndex][yIndex] > target)
				{
					xIndex--;
				}
				else
					return true;
			}

			return false;

		}
	}
}
