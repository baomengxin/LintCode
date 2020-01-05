using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeedCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeedCode.Tests
{
	[TestClass()]
	public class Amazon613High5_MinHeapTests
	{
		//results = [[1, 91],[1, 92],[2, 93],[2, 99],[2, 98],[2, 97],[1, 60],[1, 58],[2, 100],[1, 61]]
		[TestMethod()]
		public void highFiveTest()
		{
			var instance = new Amazon613High5_MinHeap();
			var input1 = new Amazon613High5_MinHeap.Record(1, 91);
			var input2 = new Amazon613High5_MinHeap.Record(1, 92);
			var input3 = new Amazon613High5_MinHeap.Record(2, 93);
			var input4 = new Amazon613High5_MinHeap.Record(2, 99);
			var input5 = new Amazon613High5_MinHeap.Record(2, 98);
			var input6 = new Amazon613High5_MinHeap.Record(2, 97);
			var input7 = new Amazon613High5_MinHeap.Record(1, 60);
			var input8 = new Amazon613High5_MinHeap.Record(1, 58);
			var input9 = new Amazon613High5_MinHeap.Record(2, 100);
			var input10 = new Amazon613High5_MinHeap.Record(1, 61);
			var inputList = new Amazon613High5_MinHeap.Record[]
			{
				input1,
				input2,
				input3,
				input4,
				input5,
				input6,
				input7,
				input8,
				input9,
				input10
			};
			var restul = instance.highFive(inputList);

			




			Assert.IsNotNull(restul);
			Assert.AreEqual(restul.Count, 2);
			Assert.AreEqual(restul[2], 97.4);
		}
	}
}