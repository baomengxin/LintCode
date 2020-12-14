using System.Collections.Generic;
using System.Linq;
using LeedCode.AFeature;

namespace LeedCode
{
//	Description
//	There are a total of n courses you have to take, labeled from 0 to n - 1.
//	Some courses may have prerequisites, for example to take course 0 you have to first take course 1, which is expressed as a pair: [0,1]

//Given the total number of courses and a list of prerequisite pairs, return the ordering of courses you should take to finish all courses.

//There may be multiple correct orders, you just need to return one of them.If it is impossible to finish all courses, return an empty array.

//Have you met this question in a real interview?
//Example
//Given n = 2, prerequisites = [[1, 0]]
//Return [0,1]

//Given n = 4, prerequisites = [1,0],[2,0],[3,1],[3,2]]
//Return [0,1,2,3]
//or [0,2,1,3]
	public class Amazon616CourseSchedule : LeetCode
	{
		/*
   * @param numCourses: a total of n courses
   * @param prerequisites: a list of prerequisite pairs
   * @return: the course order
   */
		/// <summary>
		/// 用到 广度优先遍历 还有 topological sort
		/// BFS:
		//Kahn's algorithm
		//	One of these algorithms, first described by Kahn(1962), works by choosing vertices in the same order as the eventual topological sort.First, find a list of "start nodes" which have no incoming edges and insert them into a set S; at least one such node must exist in a non-empty acyclic graph.Then:
		//L ← Empty list that will contain the sorted elements
		//S ← Set of all nodes with no incoming edges
		//while S is non-empty do
		//remove a node n from S

		//add n to tail of L
		//for each node m with an edge e from n to m do
		//remove edge e from the graph
		//if m has no other incoming edges then
		//	insert m into S
		//if graph has edges then
		//return error(graph has at least one cycle)
		//	else 
		//	return L(a topologically sorted order)
		//If the graph is a DAG, a solution will be contained in the list L(the solution is not necessarily unique). Otherwise, the graph must have at least one cycle and therefore a topological sorting is impossible.
		//	Reflecting the non-uniqueness of the resulting sort, the structure S can be simply a set or a queue or a stack.Depending on the order that nodes n are removed from set S, a different solution is created.A variation of Kahn's algorithm that breaks ties lexicographically forms a key component of the Coffman–Graham algorithm for parallel scheduling and layered graph drawing.

		/// </summary>
		/// <param name="numCourses"></param>
		/// <param name="prerequisites"></param>
		/// <returns></returns>
		public int[] findOrder(int numCourses, int[][] prerequisites)
		{
			List<List<int>> nodeToRequisiteList = new List<List<int>>();
			int[] eachNodeDepthList = new int[numCourses];
			int[] result = new int[numCourses];
			for (int i = 0; i < numCourses; i++)
			{
				nodeToRequisiteList.Add(new List<int>());
			}
			for (int i = 0; i < prerequisites.GetLength(0); i++)
			{
				if(nodeToRequisiteList[prerequisites[i][0]] == null)
				nodeToRequisiteList[prerequisites[i][0]] = new List<int>();
				nodeToRequisiteList[prerequisites[i][1]].Add(prerequisites[i][0]);
				eachNodeDepthList[prerequisites[i][0]]++;
			}
			Queue<int> nodesWith0Depth = new Queue<int>();
			int numberInResult = 0;
			for (int i = 0; i < eachNodeDepthList.Length; i++)
			{
				if(eachNodeDepthList[i] ==0)
				{
					
					nodesWith0Depth.Enqueue(i);
				}
			}

			while (nodesWith0Depth.Count > 0)
			{
				int selectedNode = nodesWith0Depth.Dequeue();
				List<int> selectedNodeDependents = nodeToRequisiteList[selectedNode];
				foreach (var selectedNodeDependent in selectedNodeDependents)
				{
					eachNodeDepthList[selectedNodeDependent]--;
					if (eachNodeDepthList[selectedNodeDependent] == 0)
					{
						nodesWith0Depth.Enqueue(selectedNodeDependent);
					}
				}

				result[numberInResult] = selectedNode;
				numberInResult++;
			}

			if (numberInResult == numCourses)
				return result;
			return new int[0];
		}

		public int NumberLeetCode => 210;
		public string UrlLeetCode => "https://leetcode.com/problems/course-schedule-ii/";

		public int[] FindOrder(int numCourses, int[,] prerequisites)
		{
			List<List<int>> DependencyNumber = new List<List<int>>();
			int[] result = new int[numCourses];
			int[] dependencyCount = new int[numCourses];
			for (int i = 0; i < numCourses; i++)
			{
				DependencyNumber.Add(new List<int>());
			}
			for (int i = 0; i < prerequisites.GetLength(0); i++)
			{
				DependencyNumber[prerequisites[i, 1]].Add(prerequisites[i, 0]);
				dependencyCount[prerequisites[i, 0]]++;
			}
			Queue<int> dependency0Courses = new Queue<int>();
			for (int i = 0; i < dependencyCount.Length; i++)
			{

				if (dependencyCount[i] == 0)
					dependency0Courses.Enqueue(i);
			}

			int numberCoursesAdded = 0;
			while (dependency0Courses.Count > 0)
			{
				var selectedCourse = dependency0Courses.Dequeue();
				result[numberCoursesAdded] = selectedCourse;

				var listCourseDependency = DependencyNumber[selectedCourse];
				foreach (var course in listCourseDependency)
				{
					dependencyCount[course]--;
					if (dependencyCount[course] == 0)
						dependency0Courses.Enqueue(course);
				}
				numberCoursesAdded++;
			}
			if (numberCoursesAdded != numCourses)
				return new int[] { };
			return result;
		}

	}
}
