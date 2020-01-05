using System;

namespace LeedCode
{
	class Program
	{
		static void Main(string[] args)
		{
			var testClass = new LeetCode3LongestSubstring();
			string testString = "abba";

			var result = testClass.LengthOfLongestSubstring(testString);

			string testString2 = "abcabcde";
			var result2= testClass.LengthOfLongestSubstring(testString2);

			string testString3 = "ababc";
			var result3 = testClass.LengthOfLongestSubstring(testString3);
			Console.WriteLine(result);
			Console.WriteLine(result2);
			Console.WriteLine(result3);
			Console.ReadLine();
		}
	}
}
