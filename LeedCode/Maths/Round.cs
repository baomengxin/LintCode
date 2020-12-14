using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeedCode.Maths
{
	public class Round
	{

		public Round()
		{

		}

		public void Test()
		{
			double[] values = new double[]
			{
				2.785,
				3.567
			};

			for(int i = 0; i < values.Length; i++)
			{
				var newValue = System.Math.Round(values[i], 2, MidpointRounding.AwayFromZero);
				Console.WriteLine(newValue);
			}
		}
	}
}
