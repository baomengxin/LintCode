using LeedCode.AFeature;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeedCode.OA
{
	public class Client
	{
		public int Index { get; set; }
		public int Direction { get; set; }

		public int ArriveTime { get; set; }

		public int PassTime { get; set; }

		public Client(int index, int direction, int arriveTime)
		{
			this.Index = index;
			this.Direction = direction;
			this.ArriveTime = arriveTime;
		}
	}
	public class AmazonOATurnstile : AmazonOA2020
	{
		public int[] getTimes(int numCustomers, int[] arrTime, int[] direction)
		{
			Queue<Client> enterQueue = new Queue<Client>();
			Queue<Client> exitQueue = new Queue<Client>();
			bool exitPriority = true;
			int time =  Int32.MaxValue;
			int[] result = new int[numCustomers];
			List<Client> clients = new List<Client>();
			for(int i = 0; i < numCustomers; i++)
			{
				clients.Add(new Client(i, direction[i], arrTime[i]));
				time = Math.Min(time, arrTime[i]);
			}

			foreach (var item in clients.OrderBy(a => a.ArriveTime))
			{
				if (item.Direction == 1)
					exitQueue.Enqueue(item);
				else
					enterQueue.Enqueue(item);
			}


			while(exitQueue.Count > 0 || enterQueue.Count > 0)
			{
				bool timeUsed = false;

				if(exitPriority && exitQueue.Count> 0)
				{
					if(exitQueue.Peek().ArriveTime<= time)
					{
						var element = exitQueue.Dequeue();
						element.PassTime = time;
						timeUsed = true;
					}
				}
			    if(!exitPriority && enterQueue.Count > 0)
				{
					if (enterQueue.Peek().ArriveTime <= time)
					{
						var element = enterQueue.Dequeue();
						element.PassTime = time;
						timeUsed = true;
						exitPriority = false;
					}
				}

				if (!timeUsed)
				{
					var exitFirst = exitQueue.Count > 0 ? exitQueue.Peek() : new Client(Int32.MaxValue, Int32.MaxValue, Int32.MaxValue);
					var enterFirst = enterQueue.Count > 0 ? enterQueue.Peek() : new Client(Int32.MaxValue, Int32.MaxValue, Int32.MaxValue);
					if (exitFirst?.ArriveTime > enterFirst ?.ArriveTime)
					{
						enterFirst = enterQueue.Dequeue();
						enterFirst.PassTime = Math.Max(enterFirst.ArriveTime, time);
						time = Math.Max(enterFirst.ArriveTime, time);
						exitPriority = false;
					
					}
					else if(exitFirst.ArriveTime != Int32.MaxValue)
					{
						var element = exitQueue.Dequeue();
						element.PassTime = Math.Max(element.ArriveTime, time);
						exitPriority = true;
						time = Math.Max(element.ArriveTime, time);
					}
				}

				time++;
			}

			return clients.Select(a => a.PassTime).ToArray();
		}
	}
}
