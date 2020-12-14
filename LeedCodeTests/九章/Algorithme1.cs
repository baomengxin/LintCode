using LeedCode.Array.Tests;
using LeedCode.DFS;

namespace LeedCodeTests.九章
{
	public class Algorithme1
	{

		public void Course()
		{
			// template subset
			var firstExample = new LeetCode78SubSetsTests();

			// template subset 2
			var secondExample = new LeetCode90Subset2Tests();

			// other examples 
			//Permutations
			var permutation = new LeetCode46Permutations();
			//Unique permutations

			var permutation2 = new LeetCode47Permutation2();
			//Combination sum
			var combinationSum = new LeetCode39CombinationSum();
			//Letter combination of a phone number
			//https://leetcode.com/problems/letter-combinations-of-a-phone-number/
			//Palindrome partitioning
			var palindrome = new LeetCode131PalindromePartitioning();
			//Restore ip address
			var ipAddress = new LeetCode93RestoreIPAddress();
		}
	}
}
