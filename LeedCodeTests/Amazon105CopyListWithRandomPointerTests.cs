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
	public class Amazon105CopyListWithRandomPointerTests
	{
		[TestMethod()]
		public void copyRandomListTest()
		{
			var testInstance = new Amazon105CopyListWithRandomPointer();
			var testData = new Amazon105CopyListWithRandomPointer.RandomListNode(1);
			var testData2 = new Amazon105CopyListWithRandomPointer.RandomListNode(2);
			var testData3 = new Amazon105CopyListWithRandomPointer.RandomListNode(3);
			var testData4 = new Amazon105CopyListWithRandomPointer.RandomListNode(4);
			testData.next = testData2;
			testData.random = testData3;
			testData2.next = testData3;
			testData2.random = testData;
			testData3.next = testData4;
			testData3.random = testData2;

			var resultCopyRandomList = testInstance.copyRandomList(testData);
			Assert.IsNotNull(resultCopyRandomList);
			Assert.IsNotNull(resultCopyRandomList.next);
		}
	}
}