using LeedCode.AFeature;
using System.Collections.Generic;
using System.Linq;

namespace LeedCode.String
{
	public class AmazonOAFreshPromotion : AmazonOA2020
	{

		public bool MatchSecretLists(List<List<string>> secretFruitList, List<string> customerPurchasedList)
		{
			bool result = false;

			int indexUser = 0;
			int indexFruit = 0;

			while(indexUser< customerPurchasedList.Count())
			{
				if (indexUser + secretFruitList[indexFruit].Count > customerPurchasedList.Count)
					return false;
				if(MatcList(secretFruitList[indexFruit], customerPurchasedList, indexUser))
				{
					indexUser += secretFruitList[indexFruit].Count;
					indexFruit++;
					if (indexFruit == secretFruitList.Count)
						return true;
				}
				else
				{
					indexUser++;
				}
			}

			return result;

		}

		private bool MatcList(List<string> list, List<string> customerPurchasedList, int indexUser)
		{
			for(int i = 0; i < list.Count; i++)
			{
				if (!MatchWord(customerPurchasedList[indexUser + i], list[i]))
					return false;
			}
			return true;
		}

		private bool MatchWord(string v1, string v2)
		{
			return v2 == "anything" ? true : Equals(v1, v2);
		}
	}
}
