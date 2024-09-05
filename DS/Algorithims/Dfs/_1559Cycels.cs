using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithims.Dfs
{
    public static class _1559Cycels
    {
        public static int[] dirRowArray = new int[] { 1, 0, -1, 0 };
        public static int[] dirColArray = new int[] { 0, 1, 0, -1 };
        public static bool isValid(int r, int c, char[][] grid)
        {
            if (r  < 0 || r > grid.Length - 1)
                return false;

            if (c < 0 || c > grid[0].Length - 1)
                return false;
            return true;
         }

        public static  bool didCycle = false;
        //public static void CycleDfs(char[][] grid, int r, int c, List<List<int>> visited,char currentChar, (int , int) cameFrom)
        //{
        //    if (!isValid(r, c, grid) || grid[r][c] != currentChar)
        //        return;

        //    if (visited[r][c] != 0 && cameFrom.Item1 == r && cameFrom.Item2 == c)
        //        didCycle = true;
        //    if (visited[r][c] != 0)
        //        return;
            


        //    visited[r][c] = 1;
        //    for (int i = 0; i < 4; i++)
        //        CycleDfs(grid, r + dirRowArray[i], c + dirColArray[i],visited, currentChar,  (r,c));
        //}
        

        //public static bool ContainsCycle(char[][] grid)
        //{
        //    List<List<int>> visited = Enumerable.Range(0, grid.Length)
        //                         .Select(i => Enumerable.Repeat(0, grid[0].Length).ToList())
        //                         .ToList();

        //    for (int r = 0; r < grid.Length; r++) { 
                
        //        for (int c = 0; c < grid[0].Length; c++)
        //        {
        //            CycleDfs(grid, r, c, visited, grid[r][c], (r,c));
        //            if (didCycle)  return true;
        //        }
                
        //    }
        //    return false;
        //}
        public static void CycleDfs(char[][] grid, int r, int c, List<List<int>> visited, char currentChar, (int, int) cameFrom )
        {
            if (!isValid(r, c, grid) || grid[r][c] != currentChar || didCycle)
                return;

            if (visited[r][c] != 0 )
            {
                didCycle = true;
                return;
            }

            visited[r][c] = 1;
            for (int i = 0; i < 4; i++)
            { 
                int newRow = r + dirRowArray[i] , newCol  = c + dirColArray[i];
                if (newRow == cameFrom.Item1 && newCol == cameFrom.Item2)
                    continue;
                CycleDfs(grid, newRow, newCol, visited, currentChar, (r,c));

            }       
        }


        public static bool ContainsCycle(char[][] grid)
        {
            List<List<int>> visited = Enumerable.Range(0, grid.Length)
                                 .Select(i => Enumerable.Repeat(0, grid[0].Length).ToList())
                                 .ToList();

            for (int r = 0; r < grid.Length; ++r)
            {
                for (int c = 0; c < grid[0].Length; ++c)
                {
                    if (visited[r][c] == 0)
                    {
                        didCycle = false;
                        CycleDfs(grid, r, c, visited, grid[r][c], (-1, -1));
                        if (didCycle)
                            return true;
                    }             
                }
            }
            return false;
        }


    }
}
