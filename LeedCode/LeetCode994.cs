using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeedCode
{
    public class LeetCode994
    {
        public int OrangesRotting(int[][] grid)
        {
            int numberOranges = 0;
            int len = grid.length;
            int height = grid[0].length;
            Stack<int, int> toCheck = new Stack<int, int>();
            bool[][] checkedGrid = new bool[len][]();
            int numberBadOrange = 0;
            int steps = 0;

            for (int i = 0; i < grid.length; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (j == 0) checkedGrid[i] = new bool[height];
                    if (grid[i][j] == 2)
                    {
                        toCheck.push(i, j);
                        checkedGrid[i][j] = true;
                        numberBadOrange++;
                        numberOranges++;
                    }
                    else if (grid[i][j] == 1)
                        numberOranges++;
                }
            }
            if (toCheck.size() == 0) return -1;
            if (numberBadOrange == numberOranges) return 0;

            while (!toCheck.isEmpty())
            {
                var badOrange = checkedGrid.Pop();
                for ()
                }


        }


    }