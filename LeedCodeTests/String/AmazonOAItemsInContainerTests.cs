using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeedCode.String.Tests
{
	[TestClass()]
	public class AmazonOAItemsInContainerTests
	{
		[TestMethod()]
		public void CalculateContainerTest()
		{
			var sol = new AmazonOAItemsInContainer();
			string s = "|**|*|*";
			int[] startIndices = { 1, 1 };
			int[] endIndices = { 5, 6 };
			int[] expected = { 2, 3 };
			test(sol, s, startIndices, endIndices, expected);

			string s2 = "*|*|";
			int[] startIndices2 = { 1 };
			int[] endIndices2 = { 3 };
			int[] expected2 = { 0 };
			test(sol, s2, startIndices2, endIndices2, expected2);

			string s3 = "|**|*|";
			int[] startIndices3 = { 1 };
			int[] endIndices3 = { 5 };
			int[] expected3 = { 2 };
			test(sol, s3, startIndices3, endIndices3, expected3);

			string s4 = "****|*|";
			int[] startIndices4 = { 1, 5, 3 };
			int[] endIndices4 = { 3, 7, 7 };
			int[] expected4 = { 0, 1, 1 };
			test(sol, s4, startIndices4, endIndices4, expected4);

			string s5 = "**|*|*||*||***|*|";
			int[] startIndices5 = { 1, 5, 3 };
			int[] endIndices5 = { 3, 7, 9 };
			int[] expected5 = { 0, 1, 2 };
			test(sol, s5, startIndices5, endIndices5, expected5);

			string s6 = "*****************";
			int[] startIndices6 = { 1, 6, 3 };
			int[] endIndices6 = { 3, 7, 9 };
			int[] expected6 = { 0, 0, 0 };
			test(sol, s6, startIndices6, endIndices6, expected6);
		}

		private void test(AmazonOAItemsInContainer sol, string s, int[] startIndices, int[] endIndices, int[] expected)
		{
			var result = sol.CalculateContainer(s, startIndices, endIndices);

			Assert.AreEqual(result.Length, expected.Length);

			for(int i = 0; i < result.Length; i++)
			{
				Assert.AreEqual(expected[i], result[i]);
			}
		}
	}
}