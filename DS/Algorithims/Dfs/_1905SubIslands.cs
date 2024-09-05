using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithims.Dfs
{
    public static class  _1905SubIslands
    {
        public static int[] dirRowArray = new int[] { 1, 0, -1, 0 };
        public static int[] dirColArray = new int[] { 0, 1, 0, -1 };

        public static bool isValid(int r, int c, int[][] grid)
        {
            if (r < 0 || r > grid.Length - 1)
                return false;

            if (c < 0 || c > grid[0].Length - 1)
                return false;
            return true;
        }

        public static bool isSubIsland = true;


        public static void CycleDfs(int[][] grid, int r, int c, List<List<int>> visited, int islandNumber)
        {
            if (!isValid(r, c, grid) || grid[r][c] != islandNumber || visited[r][c] != 0 )
                return;

            visited[r][c] = 1;

            for (int i = 0; i < 4; i++)
               CycleDfs(grid, r + dirRowArray[i], c + dirColArray[i], visited, islandNumber);    
        }


        public static void CountSubIslandsDfs(
                int[][] grid2,
                List<List<int>> grid1visited,
                int r,
                int c,
                List<List<int>> grid2Visited,
                int islandNumber)
        {
            if (!isValid(r, c, grid2) || grid2[r][c] != islandNumber || grid2Visited[r][c] != 0)
                return;

            grid2Visited[r][c] = 1;

            if (grid1visited[r][c] == 0)
                isSubIsland = false;


           for (int i = 0; i < 4; i++)
               CountSubIslandsDfs(grid2, grid1visited,  r + dirRowArray[i], c + dirColArray[i], grid2Visited, islandNumber);
        }

        public static int CountSubIslandsHelper(int[][]grid2, List<List<int>> grid1visited)
        {
            List<List<int>> grid2Visited = Enumerable.Range(0, grid2.Length)
                                 .Select(i => Enumerable.Repeat(0, grid2[0].Length).ToList())
                                 .ToList();

            int counter = 0;
            for (int r = 0; r < grid2.Length; ++r)
            {
                for (int c = 0; c < grid2[0].Length; ++c)
                {
                    if (grid2[r][c] == 1 && grid2Visited[r][c] == 0)
                    {
                        CountSubIslandsDfs(grid2, grid1visited, r, c, grid2Visited, 1);
                        if (isSubIsland)
                            counter++;
                        isSubIsland = true;
                    }
                }
            }
            return counter;
        }
        public static int CountSubIslands(int[][] grid1, int[][] grid2)
        {
            List<List<int>> visited = Enumerable.Range(0, grid1.Length)
                                 .Select(i => Enumerable.Repeat(0, grid1[0].Length).ToList())
                                 .ToList();

            for (int r = 0; r < grid1.Length; ++r)
            {
                for (int c = 0; c < grid1[0].Length; ++c)
                {  
                      CycleDfs(grid1, r, c, visited, 1);  
                }
            }
            return CountSubIslandsHelper(grid2, visited);
        }
    }
}

public class Solution
{
    public static int[] dirRowArray = new int[] { 1, 0, -1, 0 };
    public static int[] dirColArray = new int[] { 0, 1, 0, -1 };

    public static bool isValid(int r, int c, int[][] grid)
    {
        if (r < 0 || r > grid.Length - 1)
            return false;

        if (c < 0 || c > grid[0].Length - 1)
            return false;
        return true;
    }

    public static bool isSubIsland = true;

    public static void CycleDfs(int[][] grid, int r, int c, List<List<int>> visited, int islandNumber)
    {
        if (!isValid(r, c, grid) || grid[r][c] != islandNumber || visited[r][c] != 0)
            return;

        visited[r][c] = 1;

        for (int i = 0; i < 4; i++)
            CycleDfs(grid, r + dirRowArray[i], c + dirColArray[i], visited, islandNumber);
    }

    public static void CountSubIslandsDfs(
           int[][] grid2,
           List<List<int>> grid1visited,
           int r,
           int c,
           List<List<int>> grid2Visited,
           int islandNumber)
    {
        if (!isValid(r, c, grid2) || grid2[r][c] != islandNumber || grid2Visited[r][c] != 0)
            return;

        grid2Visited[r][c] = 1;
        if (grid1visited[r][c] == 0)
            isSubIsland = false;


        for (int i = 0; i < 4; i++)
            CountSubIslandsDfs(grid2, grid1visited, r + dirRowArray[i], c + dirColArray[i], grid2Visited, islandNumber);
    }
    public static int CountSubIslandsHelper(int[][] grid2, List<List<int>> grid1visited)
    {
        List<List<int>> grid2Visited = Enumerable.Range(0, grid2.Length)
                             .Select(i => Enumerable.Repeat(0, grid2[0].Length).ToList())
                             .ToList();

        int counter = 0;
        for (int r = 0; r < grid2.Length; ++r)
        {
            for (int c = 0; c < grid2[0].Length; ++c)
            {
                if (grid2[r][c] == 1 && grid2Visited[r][c] == 0)
                {
                    CountSubIslandsDfs(grid2, grid1visited, r, c, grid2Visited, 1);
                    if (isSubIsland)
                        counter++;
                    isSubIsland = true;
                }
            }
        }
        return counter;

    }
    public int CountSubIslands(int[][] grid1, int[][] grid2)
    {
        List<List<int>> visited = Enumerable.Range(0, grid1.Length)
                    .Select(i => Enumerable.Repeat(0, grid1[0].Length).ToList())
                    .ToList();

        for (int r = 0; r < grid1.Length; ++r)
        {
            for (int c = 0; c < grid1[0].Length; ++c)
            {
                CycleDfs(grid1, r, c, visited, 1);
            }
        }
        return CountSubIslandsHelper(grid2, visited);
    }

}
