using LeedCode.AFeature;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeedCode.DFS
{
	public class LeetCode93RestoreIPAddress : LeetCode
	{
		public int NumberLeetCode => throw new NotImplementedException();

		public string UrlLeetCode => throw new NotImplementedException();

		// First Error: did not consider the range of the IP address [0, 255]
		// Second Error: did not consider valid the last IP address should not begin with 0
		// Third Error: did not consider the situation of 0000
		// Fourth Errror: did not add limit to the substring range 
		public IList<string> RestoreIpAddresses(string s)
		{
			if (string.IsNullOrEmpty(s))
				return new List<string>();

			List<string> subString = new List<string>();
			List<string> result = new List<string>();

			RestoreIpAddressesHelper(s, subString, result, 0);

			return result;
		}

		private void RestoreIpAddressesHelper(string s, List<string> subString, List<string> result, int index)
		{
			if (index == s.Length && subString.Count == 4)
			{
				string ipAddress = GetIpAddress(subString);
				result.Add(ipAddress);
				return;
			}


			int currentCount = subString.Count;
			if (currentCount == 4)
				return;

			if ((4 - currentCount) * 3 < (s.Length - index)
				// error 4: didn't check minimun length
				|| 4 - currentCount > s.Length - index)
			{
				return;
			}

			// error 3: did not consider 0000
			//if (currentCount != 0 && s[index] == '0')
			//	return;


			if (currentCount == 3)
			{
				string ip = s.Substring(index, s.Length - index);
				subString.Add(ip);
				// eror 1 did not check range 
				if (!IsValidIp(ip))
					return;
				RestoreIpAddressesHelper(s, subString, result, s.Length);
				subString.RemoveAt(subString.Count - 1);
				return;
			}

			for (int i = 1; i <= 3 
				//error 4 didn't check boundary
				&& i + index < s.Length ; i++)
			{
				string ip = s.Substring(index, i);
				subString.Add(ip);
				RestoreIpAddressesHelper(s, subString, result, index + i);
				subString.RemoveAt(subString.Count - 1);
			}
		}

		private string GetIpAddress(List<string> subString)
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(subString[0]);

			for (int i = 1; i < 4; i++)
			{
				sb.Append(".");
				sb.Append(subString[i]);
			}
			return sb.ToString();
		}

		private bool IsValidIp(string s)
		{
			int ip = 0;

			//error 2 did not check begin with 0
			if (s[0] == '0' && s.Length > 1)
				return false;
			if (Int32.TryParse(s, out ip))
			{
				if (ip >= 0 && ip <= 255)
					return true;
			}

			return false;
		}



		public IList<string> RestoreIpAddresses2(string s)
		{
			List<string> result = new List<string>();
			if (string.IsNullOrEmpty(s) || s.Length < 4)
				return result;

			for (int i = 0; i <= 2; i++)
			{
				for (int j = 0; j <= 2 && j < s.Length; j++)
				{
					for (int k = 0; k <= 2 && k < s.Length; k++)
					{
						for (int l = 0; l <= 2 && l < s.Length; l++)
						{
							if (i + j + k + l + 4 != s.Length)
								continue;
							int v1 = Convert.ToInt32(s.Substring(0, i + 1));
							if (v1 > 255)
								continue;
							if (i != 0 && v1.ToString().Length != i + 1)
								continue;
							int v2 = Convert.ToInt32(s.Substring(i + 1, j + 1));
							if (v2 > 255)
								continue;
							if (j != 0 && v2.ToString().Length != j + 1)
								continue;
							int v3 = Convert.ToInt32(s.Substring(i + j + 2, k + 1));
							if (v3 > 255)
								continue;
							if (k != 0 && v3.ToString().Length != k + 1)
								continue;
							int v4 = Convert.ToInt32(s.Substring(i + j + k + 3, l + 1));
							if (v4 > 255)
								continue;
							if (l != 0 && v4.ToString().Length != l + 1)
								continue;
							string s1 = v1.ToString() + "." + v2.ToString() + "." + v3.ToString() + "." + v4.ToString();
							result.Add(s1);
						}
					}
				}
			}
			return result;
		}
	}
}
