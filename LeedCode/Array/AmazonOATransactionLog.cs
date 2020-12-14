using LeedCode.AFeature;
using System.Collections.Generic;
using System.Linq;

namespace LeedCode.Array
{
	public class AmazonOATransactionLog : AmazonOA2020
	{

		public string[] processLogFile(string[] logs, int threshold)
		{
			if (logs == null || logs.Length == 0)
				return new string[0];
			Dictionary<string, int> dic = new Dictionary<string, int>();

			for (int i = 0; i < logs.Length; i++)
			{
				var transactions = logs[i].Split(' ');
				if (!dic.ContainsKey(transactions[0]))
					dic.Add(transactions[0], 0);
				if (!dic.ContainsKey(transactions[1]))
					dic.Add(transactions[1], 0);

				dic[transactions[0]]++;
				if (!Equals(transactions[0], transactions[1]))
					dic[transactions[1]]++;
			}

			var result = new List<string>();
			var query = dic.Where(a => a.Value >= threshold).OrderBy(b => b.Key).Select(c => c.Key);

			foreach(var element in query)
			{
				result.Add(element);
			}

			return result.ToArray();
		}

	}
}
