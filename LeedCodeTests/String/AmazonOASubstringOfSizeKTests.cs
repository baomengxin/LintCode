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
	public class AmazonOASubstringOfSizeKTests
	{
		[TestMethod()]
		public void SubstringOfSizeKTest()
		{
			var instance = new AmazonOASubstringOfSizeK();
			var s = "abcabc";
			var k = 3;
			var result = instance.SubstringOfSizeK(s, k);

			var expectedOutput = new string[] { "abc", "bca", "cab" };
			Test(result, expectedOutput);

			s = "awaglknagawunagwkwagl";
			k = 4;
			result = instance.SubstringOfSizeK(s, k);

			expectedOutput = new string[] { "wagl", "aglk", "glkn", "lkna", "knag", "gawu", "awun", "wuna", "unag", "nagw", "agwk", "kwag" };
			Test(result, expectedOutput);


		}

		private void Test(string[] result, string[] expectedOutput)
		{
			Assert.AreEqual(result.Length, expectedOutput.Length);
			for(int i = 0; i < result.Length; i++)
			{
				Assert.IsTrue(expectedOutput.Any(a => a.Equals(result[i])));
			}
		}
	}
}