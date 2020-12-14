using System.Collections.Generic;
using System.Linq;

namespace LeedCode.String
{
	public class AmazonOASubstringOfSizeK
	{

		public string[] SubstringOfSizeK(string input, int k)
		{
			if (string.IsNullOrEmpty(input) || k == 0)
				return new string[0];

			HashSet<string> result = new HashSet<string>();

			int beginIndex = 0;
			int endIndex = 0;
			bool[] existsElement = new bool[26];
			while(endIndex < input.Length)
			{
				
			    if(existsElement[input[endIndex] - 'a'])
				{
					while(input[beginIndex] != input[endIndex])
					{
						existsElement[input[beginIndex]-'a'] = false;
						beginIndex++;
					}
					beginIndex++;
					endIndex++;
					continue;
				}
				else
				{
					existsElement[input[endIndex]-'a'] = true;
					int currentLength = endIndex - beginIndex + 1;
					if (currentLength == k)
					{
						result.Add(input.Substring(beginIndex, k));
						existsElement[input[beginIndex] - 'a'] = false;
						beginIndex++;
					}
					endIndex++;
				}
			}

		    int currentLength1 = endIndex - beginIndex;
			if (currentLength1 == k)
			{
				result.Add(input.Substring(beginIndex, k));
			}

			return result.ToArray();


		}
	}
}
