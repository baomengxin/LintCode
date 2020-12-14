using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeedCodeTests
{
	public static class TestHelper
	{
		public static IList<IList<int>> GetListList(string data)
		{
			List<IList<int>> result = new List<IList<int>>();

			List<int> set = new List<int>();
			int currentNumber = 0;
			for(int i = 1; i < data.Length-1; i++)
			{
				if (data[i] == ']')
				{
					if(data[i-1] != '[')
					{
						set.Add(currentNumber);
						currentNumber = 0;
					}
					result.Add(set);
					set = new List<int>();
				}
				else if (data[i] <= '9' && data[i] >= '0')
				{
					currentNumber = currentNumber * 10 + (int)Char.GetNumericValue(data[i]);
				}else if(data[i] == ',')
				{
					set.Add(currentNumber);
					currentNumber = 0;
				}
			}

			return result;
		}


		public static void CompareResult(IList<IList<int>> result1, IList<IList<int>> result2)
		{
			Assert.IsNotNull(result1);
			Assert.IsNotNull(result2);

			Assert.AreEqual(result2.Count, result1.Count);
			bool[] usedElements = new bool[result2.Count];

			var firstNotSecond = result1.Except(result2).ToList();
			var secondNotFirst = result2.Except(result1).ToList();

			//if ((firstNotSecond.Count == 0) && secondNotFirst.Count == 0)
			//	return;
			//Assert.Fail();
			//for (int i = 0; i < result1.Count; i++)
			//{
			//	bool found = false;
			//	foreach(var element in result2.Where(a=>a.Count == result1[i].Count))
			//	{
			//		bool isDjfferent = false;
			//		for(int j = 0; i < element.Count; j++)
			//		{
			//			if(results1[i][j] != results2[)
			//		}
					
			//	}
			//	if (result2.Contains(result1[i]) && !usedElements[result2.IndexOf(result1[i])])
			//		usedElements[result2.IndexOf(result1[i])] = true;
			//	else
			//		Assert.Fail();
			//}

			//if (usedElements.Any(a => !a))
			//	Assert.Fail();
		}
	}
}
