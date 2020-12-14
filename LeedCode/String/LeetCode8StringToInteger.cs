using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeedCode.String
{
	public class LeetCode8StringToInteger
	{

		public int MyAtoi(string s)
		{
			if (string.IsNullOrEmpty(s))
				return 0;
			s = s.TrimStart();
			if (string.IsNullOrEmpty(s))
				return 0;
			if ((s[0] > '9' || s[0] < '0') && s[0] != '-' && s[0] != '+')
				return 0;
			int result = 0;
			bool isNegative = false;
			if (s[0] == '-')
			{
				isNegative = true;
				s = s.Remove(0, 1);
			}
			else if (s[0] == '+')
			{
				s = s.Remove(0, 1);
			}


			for (int i = 0; i < s.Length; i++)
			{
				if (s[i] > '9' || s[i] < '0')
					break;
				var tempResult = result;
				// Console.WriteLine(result);
				result = result * 10 + (int)Char.GetNumericValue(s[i]);
				if (!isNegative)
				{
					if ((Int32.MaxValue - (int)Char.GetNumericValue(s[i])) / 10 < tempResult)
						return Int32.MaxValue;
				}
				else
				{
					if ((Int32.MaxValue - (int)Char.GetNumericValue(s[i])) / 10 < tempResult)
						return Int32.MinValue;
				}



			}
			if (isNegative)
				return (-result);
			return result;
		}
	}
}
