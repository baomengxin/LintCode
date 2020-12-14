using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeedCode.OA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeedCode.OA.Tests
{
	[TestClass()]
	public class AmazonOATurnstileTests
	{
		[TestMethod()]
		public void getTimesTest()
		{
			var arrTime = new int[] { 0, 0, 1, 5 };

			var direction = new int[] { 0, 1, 1, 0 };

			var output = new int[] { 2, 0, 1, 5 };

			var instance = new AmazonOATurnstile();

			var result = instance.getTimes(4, arrTime, direction);

			Test(result, output);

			arrTime = new int[] { 0, 1, 1, 3, 3 };

			direction = new int[] { 0, 1, 0, 0, 1 };

			output = new int[] { 0, 2, 1, 4, 3 };

			result = instance.getTimes(5, arrTime, direction);

			Test(result, output);
		}

		private void Test(int[] result, int[] output)
		{
			for(int i = 0; i < result.Length; i++)
			{
				Assert.AreEqual(result[i], output[i]);
			}
		}
	}
}