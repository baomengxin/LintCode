using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeedCode.Array;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeedCode.Array.Tests
{
	[TestClass()]
	public class AmazonOAFiveStarSellersTests
	{
		[TestMethod()]
		public void fiveStarReviewsTest()
		{
			var instance = new AmazonOAFiveStarSellers();
			var result = instance.fiveStarReviews(new int[][] { new int[] { 4, 4 }, new int[] { 1, 2 }, new int[] { 3, 6 } }, 77);
	
			Assert.AreEqual(result, 3);


		    instance = new AmazonOAFiveStarSellers();

			var  rrr2 = new List<List<int>>
				{
					new List<int> { 3,18 },
					new List<int> { 9,18 },
					new List<int> { 10,100 },
					new List<int> { 8,16 },
					new List<int> { 10,40 },
					new List<int> { 8,64 },
					new List<int> { 8,16 },
					new List<int> { 5,10 },
					new List<int> { 10,40 },
					new List<int> { 5,10 },
					new List<int> { 7,28 },
					new List<int> { 4,8 },
					new List<int> { 4,40 },
					new List<int> { 4,40 },
					new List<int> { 10,20 },
					new List<int> { 5,10 },
					new List<int> { 2,20 },
					new List<int> { 1,4 },
					new List<int> { 3,6 },
					new List<int> { 2,16 },
					new List<int> { 9,36 },
					new List<int> { 6,24 },
					new List<int> { 2,12 },
					new List<int> { 3,30 },
					new List<int> { 2,16 },
					new List<int> { 10,80 },
					new List<int> { 8,64 },
					new List<int> { 2,16 },
					new List<int> { 10,60 },
					new List<int> { 1,2 },
					new List<int> { 2,20 },
					new List<int> { 7,28 },
					new List<int> { 5,20 },
					new List<int> { 7,42 },
					new List<int> { 10,20 },
					new List<int> { 4,24 },
					new List<int> { 10,20 },
					new List<int> { 1,6 },
					new List<int> { 9,54 },
					new List<int> { 2,16 },
					new List<int> { 2,20 },
					new List<int> { 5,40 },
					new List<int> { 4,16 },
					new List<int> { 9,36 },
					new List<int> { 5,50 },
					new List<int> { 10,60 },
					new List<int> { 9,36 },
					new List<int> { 10,40 },
					new List<int> { 9,54 },
					new List<int> { 1,10 },
					new List<int> { 6,36 },
					new List<int> { 9,90 },
					new List<int> { 1,10 },
					new List<int> { 5,30 },
					new List<int> { 8,32 },
					new List<int> { 5,30 },
					new List<int> { 2,20 },
					new List<int> { 1,8 },
					new List<int> { 8,64 },
					new List<int> { 4,24 },
					new List<int> { 4,40 },
					new List<int> { 6,48 },
					new List<int> { 2,8 },
					new List<int> { 6,36 },
					new List<int> { 3,12 },
					new List<int> { 7,70 },
					new List<int> { 1,2 },
					new List<int> { 5,30 },
					new List<int> { 5,50 },
					new List<int> { 4,40 },
					new List<int> { 2,8 },
					new List<int> { 3,30 },
					new List<int> { 3,24 },
					new List<int> { 10,20 },
					new List<int> { 3,12 },
					new List<int> { 5,40 },
					new List<int> { 2,12 },
					new List<int> { 9,18 },
					new List<int> { 6,60 },
					new List<int> { 7,70 },
					new List<int> { 3,12 },
					new List<int> { 10,40 },
					new List<int> { 4,32 },
					new List<int> { 6,60 },
					new List<int> { 1,6 },
					new List<int> { 9,36 },
					new List<int> { 10,60 },
					new List<int> { 8,80 },
					new List<int> { 7,42 },
					new List<int> { 3,18 }};
			var data = new int[rrr2.Count][];

			for(int i = 0; i < rrr2.Count; i++)
			{
				data[i] = rrr2[i].ToArray();
			}
			 result = instance.fiveStarReviews(data, 35);
			var result2 = instance.fiveStarReviewss(data, 35);
			Assert.AreEqual(result, result2);


		}
	}
}