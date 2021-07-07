using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeedCode.Tree.Tests
{
	[TestClass()]
	public class LintCode892AlienDictionaryTests
	{
		[TestMethod()]
		public void alienOrderTest()
		{
			var instance = new LintCode892AlienDictionary();

			var data = new string[] { "wrt", "wrf", "er", "ett", "rftt" };

			var result = instance.alienOrder(data);

			Assert.IsNotNull(result);

			Assert.AreEqual("wertf", result);

			data = new string[] { "z", "x" };
			result = instance.alienOrder(data);

			Assert.IsNotNull(result);

			Assert.AreEqual("zx", result);

			data = new string[] {"ze", "yf", "xd", "wd", "vd", "ua", "tt", "sz", "rd", "qd", "pz", "op", "nw", "mt", "ln", "ko", "jm", "il", "ho", "gk", "fa", "ed", "dg", "ct", "bb", "ba"};
			result = instance.alienOrder(data);

			Assert.IsNotNull(result);
		}
	}
}