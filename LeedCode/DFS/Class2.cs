using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeedCode.DFS
{
	class Class2
	{

		public int CoinChange(int[] coins, int amount)
		{
			if (amount == 0)
				return 0;
			if (coins.Length == 0)
				return -1;
			if (coins.Any(a => a == amount))
				return 1;
			int result = -1;

			HashSet<int> ps = new HashSet<int>();
			Stack<Tuple<int, HashSet<int>>> st = new Stack<Tuple<int, HashSet<int>>>();

			st.Push(new Tuple<int, HashSet<int>>(amount, ps));
			// Instantiate the reverse comparer.
			var newcoins = coins.Where(a => (a <= amount)).OrderByDescending(p => p).ToList();

			result = DFS(newcoins, st);
			return result;
		}


		public int CoinChange(int[] coins, int amount)
		{
			if (amount == 0)
				return 0;
			if (coins.Length == 0)
				return -1;
			if (coins.Any(a => a == amount))
				return 1;
			int result = -1;

			int[] dp = new int[amount + 1];
			dp[0] = 0;
			for (int i = 1; i <= amount; i++)
			{
				dp[i] = Int32.MaxValue;
			}
			var newCoins = coins.Where(a => (a <= amount)).OrderBy(p => p).ToList();
			for (int j = 0; j < newCoins.Count; j++)
			{
				dp[newCoins[j]] = 1;
			}

			for (int i = 1; i <= amount; i++)
			{
				int tmpCount = Int32.MaxValue;
				for (int j = 0; j < newCoins.Count; j++)
				{
					if (i < newCoins[j])
						continue;
					if (dp[i - newCoins[j]] != Int32.MaxValue)
						tmpCount = Math.Min(tmpCount, dp[i - newCoins[j]] + 1);
				}
				dp[i] = Math.Min(dp[i], tmpCount);
				//Console.WriteLine(dp[i]);
			}
			return dp[amount] == Int32.MaxValue ? -1 : dp[amount];
		}


		private int DFS(List<int> coins, Stack<Tuple<int, HashSet<int>>> st)
		{
			var intervals = new int[10][];
			var newList = intervals.ToList();
			intervals.Sort(array=>array[0]);

			int[][] result = new int[intervals.Length][];
			return result;


			if (st.Count == 0)
				return -1;

			var amount = st.Pop();
			if (amount.Item1 < coins[coins.Count - 1])
				return -1;
			Console.WriteLine(amount);
			for (int i = 0; i < coins.Count; i++)
			{
				if (amount.Item2.Contains(coins[i]))
					continue;
				if (amount.Item1 % coins[i] == 0)
					return amount.Item1 / coins[i];
				int number = amount.Item1 / coins[i];

				for (int j = number; j >= 0; j--)
				{
					amount.Item2.Add(coins[i]);
					st.Push(new Tuple<int, HashSet<int>>(amount.Item1 - j * coins[i], amount.Item2));
					var lessCoins = DFS(coins, st);
					if (lessCoins == -1)
						continue;
					else
						return lessCoins + number;

				}
				//amount.Item2.Remove(coins[i]);
			}
			return -1;
		}
	}
}
