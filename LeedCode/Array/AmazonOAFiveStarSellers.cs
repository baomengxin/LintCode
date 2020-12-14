using LeedCode.AFeature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeedCode.Array
{

	public class CustomComparator : IComparer<Tuple<int, int>>
	{
		public int Compare(Tuple<int, int> x, Tuple<int, int> y)
		{
			double first = (double)(x.Item1 + 1) / (double)(x.Item2 + 1) - (double)x.Item1 / (double)x.Item2;
			double second = (double)(y.Item1 + 1) / (double)(y.Item2 + 1) - (double)y.Item1 / (double)y.Item2;
			if (first != second)
				return second.CompareTo(first);

			if (x.Item1 != y.Item1)
				return x.Item1.CompareTo(y.Item1);
			return x.Item2.CompareTo(y.Item2);
		}
	}
	public class AmazonOAFiveStarSellers : AmazonOA2020
	{


		public int fiveStarReviews(int[][] productRatings, int ratingsThreshold)
		{
			var comparator = new CustomComparator();
			SortedDictionary<Tuple<int, int>, int> pairs = new SortedDictionary<Tuple<int, int>, int>(comparator);

			double sumRating = 0;
			for (int i = 0; i < productRatings.Length; i++)
			{
				double percentageFiveStar = (double)productRatings[i][0] / (double)productRatings[i][1];
				var newPair = new Tuple<int, int>(productRatings[i][0], productRatings[i][1]);
				if (!pairs.ContainsKey(newPair))
					pairs.Add(newPair, 0);
				pairs[newPair]++;
				sumRating += percentageFiveStar;
			}
			double totalThreshhold = ratingsThreshold * productRatings.Length / 100.00;
			int step = 0;
			while (sumRating < totalThreshhold)
			{
				var element = pairs.First();
				sumRating = sumRating - (double)element.Key.Item1 / (double)element.Key.Item2 + (double)(element.Key.Item1 + 1) / (double)(element.Key.Item2 + 1);
				step++;
				if (element.Value > 1)
				{
					pairs[element.Key]--;
				}
				else
				{
					pairs.Remove(element.Key);
				}

				var newPair = new Tuple<int, int>(element.Key.Item1 + 1, element.Key.Item2 + 1);
				if (!pairs.ContainsKey(newPair))
					pairs.Add(newPair, 0);
				pairs[newPair]++;
				//Console.WriteLine("step: " + step + ", sumRating: " + sumRating + " ,numerator: " +newPair.Item1 + " ,demorator:" + newPair.Item2);
				Console.WriteLine("step: " + step + " ,numerator: " + newPair.Item1 + " ,demorator:" + newPair.Item2);

			}

			return step;
		}


		public int fiveStarReviewss(int[][] ratings, int target)
		{
			int n = ratings.Length;
			double threshold = n * target / 100.0;
			double percentage = 0.00;
			for (int i = 0; i < n; i++)
			{
				double a = ratings[i][0];
				double b = ratings[i][1];
				double rate = a / b;
				percentage += rate;
			}
			int maxIndex = 0, res = 0;
			double diff = 0.00, maxDiff = Double.MinValue;
			while (percentage < threshold)
			{
				for (int i = 0; i < n; i++)
				{
					double a = ratings[i][0];
					double b = ratings[i][1];
					double rate = a / b;
					if (rate == 1)
					{
						continue;
					}
					double x = ratings[i][0] + 1;
					double y = ratings[i][1] + 1;
					double updated = x / y;

					diff = updated - rate;
					if (diff > maxDiff)
					{
						maxDiff = diff;
						maxIndex = i;
					}
				}
				percentage += maxDiff;
				maxDiff = Double.MinValue;
				ratings[maxIndex][0] = ratings[maxIndex][0] + 1;
				ratings[maxIndex][1] = ratings[maxIndex][1] + 1;
				res++;
				//Console.WriteLine("step: " + res + ", sumRating: " + percentage);
				Console.WriteLine("step: " + res + ", sumRating: " + percentage + " ,numerator: " + ratings[maxIndex][0] + " ,demorator:" + ratings[maxIndex][1]);
			}
			return res;
		}
	}
}
