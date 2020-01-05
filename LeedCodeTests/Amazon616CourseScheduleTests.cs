using LeedCode;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace LeedCode.Tests
{
	[TestClass()]
	public class Amazon616CourseScheduleTests
	{
		[TestMethod()]
		public void findOrderTest()
		{
			//Given n = 2, prerequisites = [[1, 0]]
			var findOrder = new Amazon616CourseSchedule();
			int[][] prerequesites = new int[1][]
			{
				new int[]{1,0}
			};
			var restult = findOrder.findOrder(2, prerequesites);
			Assert.IsNotNull(restult);
			Assert.AreEqual(restult.Length, 2);

			//Given n = 4, prerequisites = [1, 0],[2, 0],[3, 1],[3, 2]]
			//Return[0, 1, 2, 3] or[0, 2, 1, 3]
			int[][] prerequesites2 = new int[4][]
			{
				new int[]{1,0},
				new int[] {2, 0},
				new int[] {3,1},
				new int[] {3,2}
			};
			var restult2 = findOrder.findOrder(4, prerequesites2);
			Assert.IsNotNull(restult2);
			Assert.AreEqual(restult2.Length, 4);
		}

		[TestMethod()]
		public void FindOrderTest()
		{
			//Given n = 2, prerequisites = [[1, 0]]
			var findOrder = new Amazon616CourseSchedule();
			int[,] prerequesites = new int[2, 2]
				{
					{1,0 },{0,1}
				};
			var restult = findOrder.FindOrder(2, prerequesites);
			Assert.IsNotNull(restult);
			Assert.AreEqual(restult.Length, 0);
		}
	}
}