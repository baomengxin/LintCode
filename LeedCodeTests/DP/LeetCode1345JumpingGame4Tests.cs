using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeedCode.DP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeedCode.DP.Tests
{
	[TestClass()]
	public class LeetCode1345JumpingGame4Tests
	{
		[TestMethod()]
		public void MinJumpsTest()
		{





			var steps = new int[] { 100, -23, -23, 404, 100, 23, 23, 23, 3, 404 };

			var instance = new LeetCode1345JumpingGame4();

			var result = instance.MinJumps(steps);
			Assert.AreEqual(3, result);
			steps = new int[] { 51,64,-15,58,98,31,48,72,78,-63,92,-5,64,-64,51,-48,64,48,-76,-86,-5,-64,-86,-47,92,-41,58,72,31,78,-15,-76,72,-5,-97,98,78,-97,-41,-47,-86,-97,78,-97,58,-41,72,-41,72,-25,-76,51,-86,-65,78,-63,72,-15,48,-15,-63,-65,31,-41,95,51,-47,51,-41,-76,58,-81,-41,88,58,-81,88,88,-47,-48,72,-25,-86,-41,-86,-64,-15,-63};
			result = instance.MinJumps(steps);
			Assert.AreEqual(4, result);

			steps = new int[] { 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7 , 11};
			result = instance.MinJumps(steps);
			Assert.AreEqual(2, result);

			steps = new int[] { 7, 6, 9, 6, 9, 6, 9, 7 };
			instance = new LeetCode1345JumpingGame4();

			result = instance.MinJumps(steps);
			Assert.AreEqual(1, result);

			steps = new int[] { 6, 1, 9 };
			instance = new LeetCode1345JumpingGame4();

			result = instance.MinJumps(steps);
			Assert.AreEqual(2, result);


			steps = new int[] { 11, 22, 7, 7, 7, 7, 7, 7, 7, 22, 13 };
			instance = new LeetCode1345JumpingGame4();

			result = instance.MinJumps(steps);
			Assert.AreEqual(3, result);

			steps = new int[] { 7872, -7760, 9126, 9296, 5847, 9525, 5868, -8531, 1093, 7987, 6086, -6893, 9446, 5451, 3011, 4575, 6829, -3429, -5798, -3226, 9434, 7889, 871, 150, -9427, 7872, 7278, 6406, 701, -507, -4503, -823, -7702, 9869, 6847, -9175, 1226, -9598, 513, 3316, 6829 };
			instance = new LeetCode1345JumpingGame4();

			result = instance.MinJumps(steps);
			Assert.AreEqual(11, result);


			steps = new int[] { 25, -28, -51, 61, -74, -51, -30, 58, 36, 68, -80, -64, 25, -30, -53, 36, -74, 61, -100, -30, -52 };
			instance = new LeetCode1345JumpingGame4();

			result = instance.MinJumps(steps);
			Assert.AreEqual(4, result);





			steps = new int[] { 25, -28, -51, 61, -74, -51, -30, 58, 36, 68, -80, -64, 25, -30, -53, 36, -74, 61, -100, -30, -52 };
			instance = new LeetCode1345JumpingGame4();

			result = instance.MinJumps(steps);
			Assert.AreEqual(4, result);

		}
	}
}