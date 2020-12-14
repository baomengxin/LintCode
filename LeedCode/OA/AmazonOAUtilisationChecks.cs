using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeedCode.OA
{
	public class AmazonOAUtilisationChecks
	{
		public int finalInstances(int instances, int[] averageUtil)
		{
			int beginIndex = 0;

			while(beginIndex< averageUtil.Length)
			{
				if(averageUtil[beginIndex] < 25 && instances >1)
				{
					instances = (int)Math.Ceiling((double)instances / 2);
					beginIndex += 10;
				}else if(averageUtil[beginIndex] > 60 && instances <= 10e8)
				{
					instances = instances * 2;
					beginIndex += 10;
				}
				beginIndex++;
			}

			return instances;

		}
	}
}
