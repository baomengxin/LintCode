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
	public class AmazonOAFreshPromotionTests
	{
		[TestMethod()]
		public void MatchSecretListsTest()
		{

			List<List<string>> codeList1 = new List<List<string>>{ new List<string>{ "apple", "apple" }, new List<string> { "banana", "anything", "banana" } };
			List<string> shoppingCart1 = new List<string>{ "orange", "apple", "apple", "banana", "orange", "banana" };
			List<List<string>> codeList2 = new List<List<string>> { new List<string> { "apple", "apple" }, new List<string> { "banana", "anything", "banana" } };
			List<string>  shoppingCart2 = new List<string> { "banana", "orange", "banana", "apple", "apple" };
			List<List<string>> codeList3 = new List<List<string>> { new List<string> { "apple", "apple" }, new List<string> { "banana", "anything", "banana" } };
			List<string>  shoppingCart3 = new List<string> { "apple", "banana", "apple", "banana", "orange", "banana" };
			List<List<string>> codeList4 = new List<List<string>> { new List<string> { "apple", "apple" }, new List<string> { "apple", "apple", "banana" } };
			List<string>  shoppingCart4 = new List<string> { "apple", "apple", "apple", "banana" };
			List<List<string>> codeList5 = new List<List<string>> { new List<string> { "apple", "apple" }, new List<string> { "banana", "anything", "banana" } };
			List<string>  shoppingCart5 = new List<string> { "orange", "apple", "apple", "banana", "orange", "banana" };
			List<List<string>> codeList6 = new List<List<string>> { new List<string> { "apple", "apple" }, new List<string> { "banana", "anything", "banana" } };
			List<string>  shoppingCart6 = new List<string> { "apple", "apple", "orange", "orange", "banana", "apple", "banana", "banana" };
			List<List<string>> codeList7 = new List<List<string>> { new List<string> { "anything", "apple" }, new List<string> { "banana", "anything", "banana" } };
			List<string>  shoppingCart7 = new List<string> { "orange", "grapes", "apple", "orange", "orange", "banana", "apple", "banana", "banana" };
			List<List<string>> codeList8 = new List<List<string>> { new List<string> { "apple", "orange" }, new List<string> { "orange", "banana", "orange" } };
			List<string>  shoppingCart8 = new List<string> { "apple", "orange", "banana", "orange", "orange", "banana", "orange", "grape" };
			List<List<string>> codeList9 = new List<List<string>> { new List<string> { "anything", "anything", "anything", "apple" }, new List<string> { "banana", "anything", "banana" } };
			List<string>  shoppingCart9 = new List<string> { "orange", "apple", "banana", "orange", "apple", "orange", "orange", "banana", "apple", "banana" };
			var instance = new AmazonOAFreshPromotion();

			var result = instance.MatchSecretLists(codeList1, shoppingCart1);
			Assert.IsTrue(result);

			result = instance.MatchSecretLists(codeList2, shoppingCart2);
			Assert.IsTrue(!result);

			result = instance.MatchSecretLists(codeList3, shoppingCart3);
			Assert.IsTrue(!result);

			result = instance.MatchSecretLists(codeList4, shoppingCart4);
			Assert.IsTrue(!result);

			result = instance.MatchSecretLists(codeList5, shoppingCart5);
			Assert.IsTrue(result);

			result = instance.MatchSecretLists(codeList6, shoppingCart6);
			Assert.IsTrue(result);

			result = instance.MatchSecretLists(codeList7, shoppingCart7);
			Assert.IsTrue(result);

			result = instance.MatchSecretLists(codeList8, shoppingCart8);
			Assert.IsTrue(result);

			result = instance.MatchSecretLists(codeList9, shoppingCart9);
			Assert.IsTrue(result);


		}
	}
}