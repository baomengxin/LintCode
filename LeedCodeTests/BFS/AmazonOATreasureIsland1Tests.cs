using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeedCode.BFS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeedCode.BFS.Tests
{
	[TestClass()]
	public class AmazonOATreasureIsland1Tests
	{
		[TestMethod()]
		public void GetMinStepTest()
		{

			var input = new Char[][]
			{
				new Char[]{'O', 'O', 'O', 'O'},
				new Char[]{'D', 'O', 'D', 'O'},
				new Char[]{'O', 'O', 'O', 'O'},
				new Char[]{'X', 'D', 'D', 'O' }
			};
			var instance = new AmazonOATreasureIsland1();



			Assert.AreEqual(5, instance.GetMinStep(input));
		}
	}
}