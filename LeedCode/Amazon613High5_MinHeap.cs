using System;
using System.Collections.Generic;
using System.Linq;

namespace LeedCode
{
	//There are two properties in the node student id and scores, to ensure that each student will have at least 5 points, find the average of 5 highest scores for each person.
	//Given results = [[1, 91],[1, 92],[2, 93],[2, 99],[2, 98],[2, 97],[1, 60],[1, 58],[2, 100],[1, 61]]
	public class Amazon613High5_MinHeap
	{
		public class Record
		{
			public int id, score;

			public Record(int id, int score)
			{
				this.id = id;
				this.score = score;
			}
		}
		/**
	* @param results a list of <student_id, score>
	* @return find the average of 5 highest scores for each person
	* Map<Integer, Double> (student_id, average_score)
	*/

		public Dictionary<int, Double> highFive(Record[] results)
		{
			Dictionary<int, Double> result = new Dictionary<int, double>();
			if (results == null || results.Length < 1)
				return result;
			Dictionary<int, List<int>> studentScoreDictionary = new Dictionary<int, List<int>>();
			//PriorityQueue
			foreach (var score in results)
			{
				if (!studentScoreDictionary.ContainsKey(score.id))
					studentScoreDictionary[score.id] = new List<int>();
				studentScoreDictionary[score.id].Add(score.score);
			}

			foreach (var studentWithScore in studentScoreDictionary)
			{
				var AverageTopHigh5Socre = (from valueScore in studentWithScore.Value
										 orderby valueScore descending
										 select valueScore).Take(5).Average();

				result.Add(studentWithScore.Key, AverageTopHigh5Socre);
			}
			return result;
		}
	}
}