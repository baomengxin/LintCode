using LeedCode.AFeature;
using System;

namespace LeedCode.String
{
	public class AmazonOAItemsInContainer : AmazonOA2020
	{
		public int[] CalculateContainer(string s, int[] begin, int[] end)
		{
			if (string.IsNullOrEmpty(s))
				return new int[0];
			int[] result = new int[begin.Length];
			int[] right = new int[s.Length];
			int[] left = new int[s.Length];

			int beginIndex = 0;
			int endIndex = 1;
			int countStar = 0;
			while(beginIndex < s.Length)
			{
				if (s[beginIndex] == '|')
					break;
				beginIndex++;
			}

			endIndex = beginIndex + 1;

			while(endIndex < s.Length)
			{
				if (s[endIndex] == '|')
				{
					countStar += endIndex - beginIndex - 1;
					for (int i = beginIndex + 1; i < endIndex; i++)
					{
						left[i] = countStar;
					}
					left[endIndex] = right[endIndex] = countStar;

					beginIndex = endIndex;
				}
				else
				{
					right[endIndex] = countStar;
				}

				endIndex++;
			}

			for(int j = 0; j < begin.Length; j++)
			{
				result[j] = Math.Max(right[end[j]-1] - left[begin[j]-1], 0);
			}

			return result;
		}
	}
}
