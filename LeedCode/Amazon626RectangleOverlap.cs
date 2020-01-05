using LeedCode.Feature;

namespace LeedCode
{
	/// <summary>
	/// two square:
	/// l1: left top point r2: right bottom point  
	/// </summary>
	public class Amazon626RectangleOverlap : LeetCode
	{

		/// <summary>
		/// 
		/// </summary>
		/// <param name="l1"></param>
		/// <param name="r1"></param>
		/// <param name="l2"></param>
		/// <param name="r2"></param>
		/// <returns>false if the two squares don't have shared parte</returns>
		public bool AreTwoSquareTogether(int[] l1, int[] r1, int[] l2, int[] r2)
		{
			if (l1 == null || r1 == null || l2 == null || r2 == null)
				return false;
			if (l1[0] > r2[0] || r1[0] < l2[0])
				return false;
			if (r1[1] > l2[1] || r2[1] > l1[1])
				return false;
			return true;
		}

		public int NumberLeetCode => 836;
		public string UrlLeetCode => "https://leetcode.com/problems/rectangle-overlap/";

		public bool IsRectangleOverlap(int[] rec1, int[] rec2)
		{
			if (rec1 == null || rec1.Length < 4 || rec2 == null || rec2.Length < 4)
				return false;
			if (rec1[2] <= rec2[0] || rec1[0] >= rec2[2])
				return false;
			if (rec1[1] >= rec2[3] || rec2[1] >= rec1[3])
				return false;
			return true;
		}
	}
}

