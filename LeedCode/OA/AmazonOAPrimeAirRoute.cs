using System.Collections.Generic;
using System.Linq;

namespace LeedCode.OA
{
	public class AmazonOAPrimeAirRoute
	{

		//You'll be given two arrays
		//arr1 = { {1, 2000}, {2, 3000}, {3, 4000} }
		//arr2 = { { 1, 5000 }, {2, 3000} }
		//the first element of every pair represents id and the second value represents the value.
		//and a target x = 5000
		//Find the pairs from both the arrays whose value add upto a sum which is less than given target and should be close to the target.

		//Output for the above example:
		//{ {1, 2} } // Note that the output should be in id's
		//Attetion, if there are more than one answer, return all the possibilities that sum up to the close target

		public List<List<int>> getIdPairsForOptimal(List<List<int>> forwardList, List<List<int>> backwardList, int maxDistance)
		{
			var forwardSortedList = forwardList.OrderBy(a => a[1]).ToList();
			var backwardSortedList = backwardList.OrderBy(a => a[1]).ToList();

			List<List<int>> result = new List<List<int>>();

			int currentResult = 0;

			int currentBackListIndex = backwardSortedList.Count - 1;

			for(int i = 0; i < forwardSortedList.Count; i++)
			{
				int searchNumber = maxDistance - forwardSortedList[i][1];

				List<int> mostClosePoint = FindOptimalPair(backwardSortedList, searchNumber, currentBackListIndex);

				if(mostClosePoint[1] + forwardSortedList[i][1] > currentResult)
				{
					currentResult = mostClosePoint[1] + forwardSortedList[i][1];
					result.Clear();

					result.Add(new List<int> { forwardSortedList[i][0], mostClosePoint[0] });
				}else if(mostClosePoint[1] + forwardSortedList[i][1] == currentResult)
				{
					result.Add(new List<int> { forwardSortedList[i][0], mostClosePoint[0] });
				}
			}

			return result;
		}


		private List<int> FindOptimalPair(List<List<int>> backwardSortedList, int searchNumber, int currentBackListIndex)
		{
			int beginIndex = 0;

			int endIndex = currentBackListIndex;

			while(beginIndex + 1 < endIndex)
			{
				int mid = beginIndex + (endIndex - beginIndex) / 2;

				if(backwardSortedList[mid][1]> searchNumber)
				{
					endIndex = mid;
				}
				else
				{
					beginIndex = mid;
				}
			}

			if(backwardSortedList[endIndex][1] <= searchNumber)
			{
				return backwardSortedList[endIndex];
			}

			return backwardSortedList[beginIndex];
		}
	}
}
