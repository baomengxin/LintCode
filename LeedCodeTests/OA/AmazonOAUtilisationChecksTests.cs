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
	public class AmazonOAUtilisationChecksTests
	{
		[TestMethod()]
		public void finalInstancesTest()
		{
			var instance = new AmazonOAUtilisationChecks();
			var data = new int[] {46, 73, 77, 53, 75, 22, 55, 84, 45, 40, 80, 66, 54, 39, 68, 23, 54, 22, 11, 91, 47, 56, 91, 97, 5, 44, 62, 73, 26, 99, 96, 74, 4, 0, 8, 56, 3, 21, 37, 94, 83, 68, 91, 83, 41, 22, 81, 59, 37, 29, 93, 8, 88, 41, 94, 62, 63, 97, 73, 46, 80, 91, 65, 69, 52, 31, 35, 81, 60, 44, 8, 80, 75, 94, 16, 45, 12, 29, 22, 59, 88, 87, 55, 43, 67, 8, 15, 26, 31, 99, 35, 99, 1, 98};
			var result = instance.finalInstances(46,data);
		}
	}
}