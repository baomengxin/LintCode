using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeedCode.String;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeedCode.String.Tests
{
	[TestClass()]
	public class LongestPalindromicSubstringTests
	{
		[TestMethod()]
		public void LongestPalindrome3Test()
		{
			var palindromeTestInstance = new LongestPalindromicSubstring();
			var testString = "babad";
			var result = palindromeTestInstance.LongestPalindrome3(testString);
			Assert.AreEqual(result, "bab");
			var testString2 = "ccc";
			var result2 = palindromeTestInstance.LongestPalindrome3(testString2);
			Assert.AreEqual(result2, testString2);

			var testString3 = "cc";
			var result3 = palindromeTestInstance.LongestPalindrome3(testString3);
			Assert.AreEqual(result3, testString3);
		}

		[TestMethod()]
		public void LongestPalindrome4Test()
		{
			var palindromeTestInstance = new LongestPalindromicSubstring();
			var testString = "babad";
			var result = palindromeTestInstance.LongestPalindrome4(testString);
			Assert.AreEqual(result, "bab");
			var testString2 = "ccc";
			var result2 = palindromeTestInstance.LongestPalindrome4(testString2);
			Assert.AreEqual(result2, testString2);

			var testString3 = "cc";
			var result3 = palindromeTestInstance.LongestPalindrome4(testString3);
			Assert.AreEqual(result3, testString3);
		}

		[TestMethod()]
		public void LongestPalindrome5Test()
		{
			var palindromeTestInstance = new LongestPalindromicSubstring();
			var testString = "babad";
			var result = palindromeTestInstance.LongestPalindrome5(testString);
			Assert.AreEqual(result, "bab");
			var testString2 = "ccc";
			var result2 = palindromeTestInstance.LongestPalindrome5(testString2);
			Assert.AreEqual(result2, testString2);

			var testString3 = "cc";
			var result3 = palindromeTestInstance.LongestPalindrome5(testString3);
			Assert.AreEqual(result3, testString3);
		}


	}
}