using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeedCode.Array.Tests
{
	[TestClass()]
	public class AmazonOATransactionLogTests
	{
		[TestMethod()]
		public void processLogFileTest()
		{
			var instance = new AmazonOATransactionLog();
			var logs = new string[] { "88 99 200", "88 99 300", "99 32 100", "12 12 15" };
			var result = instance.processLogFile(logs, 2);
			Assert.AreEqual(result.Length, 2);


			logs = new string[]
	   {
			"345366 89921 45",
			"029323 38239 23",
			"38239 345366 15",
			"029323 38239 77",
			"345366 38239 23",
			"029323 345366 13",
			"38239 38239 23"
	   };

			result = instance.processLogFile(logs, 3);
			Assert.AreEqual(result.Length, 3);

		}
	}
}