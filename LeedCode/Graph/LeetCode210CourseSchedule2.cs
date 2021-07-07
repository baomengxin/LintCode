using LeedCode.AFeature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeedCode.Graph
{
	public class LeetCode210CourseSchedule2 : LeetCode, Medium
	{
		public int Time => 20;

		public int NumberLeetCode => 210;

		public string UrlLeetCode => "https://leetcode.com/problems/course-schedule-ii/";

		public int[] FindOrder(int numCourses, int[][] prerequisites)
		{
			// pre test course == 0 
			if (numCourses == 1)
				return new int[] { 0 };
			if (prerequisites == null || prerequisites.Length == 0 || prerequisites[0].Length == 0)
			{
				int[] results = new int[numCourses];
				for (int i = 0; i < numCourses; i++)
				{
					results[i] = i;
				}

				return results;
			}

			//int[] result = new int[numCourses];

			int[] inDegrees = new int[numCourses];

			List<HashSet<int>> edges = new List<HashSet<int>>();

			for (int i = 0; i < numCourses; i++)
			{
				edges.Add(new HashSet<int>());
			}

			for (int i = 0; i < prerequisites.Length; i++)
			{
				var request = prerequisites[i];

				edges[request[1]].Add(request[0]);
				inDegrees[request[0]]++;
			}

			Queue<int> q = new Queue<int>();

			List<int> result = new List<int>();
			for (int i = 0; i < numCourses; i++)
			{
				if (inDegrees[i] == 0)
				{
					q.Enqueue(i);
					result.Add(i);
				}
			}


			while (q.Count > 0)
			{
				int count = q.Count;

				for (int i = 0; i < count; i++)
				{
					var node = q.Dequeue();
					for (int j = 0; j < edges[node].Count; j++)
					{
						int afterCourse = edges[node].ElementAt(j);
						inDegrees[afterCourse]--;
						if (inDegrees[afterCourse] == 0)
						{
							q.Enqueue(afterCourse);
							result.Add(afterCourse);
						}

					}
				}
			}

			if (result.Count == numCourses)
				return result.ToArray();
			return new int[0];
		}
	}
}
