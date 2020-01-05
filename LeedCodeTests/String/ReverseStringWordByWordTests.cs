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
	public class ReverseStringWordByWordTests
	{
		[TestMethod()]
		public void reverseWordsTest()
		{
			var stringInstance = new ReverseStringWordByWord();
			var stringTest = "the sky is blue";
			var resultExpected = "blue is sky the";
			Assert.AreEqual(stringInstance.reverseWords1(stringTest), resultExpected);
		}

		[TestMethod()]
		public void reverseWordsTest2()
		{
			var stringInstance = new ReverseStringWordByWord();
			var stringTest = "  the sky is blue";
			var resultExpected = "blue is sky the";
			Assert.AreEqual(stringInstance.reverseWords2(stringTest), resultExpected);
		}

		[TestMethod()]
		public void reverseWordsTest3()
		{
			var stringInstance = new ReverseStringWordByWord();
			var stringTest = "  the sky is blue";
			var resultExpected = "blue is sky the";
			Assert.AreEqual(stringInstance.reverseWords3(stringTest), resultExpected);
		}
	}
}