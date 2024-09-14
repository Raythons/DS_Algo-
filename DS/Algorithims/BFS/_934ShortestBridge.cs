using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Algorithims.BFS._773SlidingPuzzle;

namespace Algorithims.BFS
{
    public  static class _934ShortestBridge
    {
        public static int[] dirRowArray = new int[] { 1, 0, -1, 0 };
        public static int[] dirColArray = new int[] { 0, 1, 0, -1 };

        public static bool isValid(int row, int col, int[][] matrix)
        {
            if (row < 0 || row > matrix.Length - 1)
                return false;
            if (col < 0 || col > matrix[0].Length - 1)
                return false;
            return true;
        }

        public static  bool HaveBorder(int[][] grid, int[][] visited, int r, int c)
        {
            if (!isValid(r, c, grid)  || visited[r][c] == 1)
                return false;
            if (grid[r][c] == 1 && visited[r][c] == 0)
                return true;
            return false;
        }

        public static int ShortestBridge(int[][] grid)
        {
            Queue<(int r , int c)> queue = new Queue<(int r, int c)>();

            var visited = Enumerable.Range(0, grid.Length).ToArray()
                                .Select(i => new int[grid[0].Length]).ToArray();

            Dfs(grid, visited,queue);

            for ( int level = 0 , sz = queue.Count; queue.Count > 0; level++,  sz=queue.Count )
            {
                while (sz-- > 0) {
                
                    var (r, c) = queue.Dequeue();

                    for (int i = 0; i < 4; i++)
                        if (HaveBorder(grid, visited, r + dirRowArray[i], c + dirColArray[i]))
                            return level;

                    if (ProcessVals(grid, visited, queue , r , c))
                        return level ;
                }
            }
            return 0;
        }
        public static bool Connected = false;
        private static bool ProcessVals(int[][] grid, int[][] visited,  Queue<(int r, int c)> queue, int r , int c)
        {
            for (int i = 0; i < 4; i++)
                if (!Connected)
                    handleBfs(grid, visited, queue, r + dirRowArray[i], c + dirColArray[i]);
                else
                    return true;

            return false;
        }

        private static void handleBfs(int[][] grid, int[][] visited, Queue<(int r, int c)> queue, int r, int c)
        {
            if (!isValid(r, c, grid) || visited[r][c] != 0)
                return;

       
            if (grid[r][c] == 1 )
            {
                Connected = true;
                return;
            }
            visited[r][c] = 1;

            queue.Enqueue((r, c));

        }

        private static void DfsFirstBridge(int[][] grid, int[][] visited, Queue<(int r, int c)> queue, int cc_Id, int r, int c)
        {
            if (!isValid(r,c , grid) || visited[r][c] != 0 || grid[r][c] != 1 )
                return;

            visited[r][c] = cc_Id;
            queue.Enqueue((r, c));

            for (int i = 0; i < 4; i++)
                DfsFirstBridge(grid, visited, queue, cc_Id, r + dirRowArray[i], c + dirColArray[i]);
        }
        public static void Dfs(int[][] grid, int[][] visited, Queue<(int r, int c)> queue)
        {
            var cc = 0;
            for (int r = 0; r < grid.Length; r++)
            {
                for(int c = 0; c < grid[0].Length; c++)
                {
                    if (visited[r][c] == 0 && grid[r][c] == 1)
                    {
                        DfsFirstBridge(grid, visited, queue, cc + 1, r, c);
                        return;
                    }
                }
            }
        }

        public static void Run()
        {
            var row1 = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            var row2 = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            var row3 = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 };
            var row4 = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 1, 1 };
            var row5 = new int[] { 0, 0, 0, 0, 0, 0, 0, 1, 1, 1 };
            var row6 = new int[] { 0, 0, 0, 0, 0, 1, 0, 1, 1, 1 };
            var row7 = new int[] { 0, 0, 0, 0, 1, 1, 0, 0, 0, 1 };
            var row8 = new int[] { 0, 0, 0, 1, 1, 1, 0, 0, 0, 0 };
            var row9 = new int[] { 0, 0, 0, 0, 1, 1, 0, 0, 0, 0 };
            var row10 = new int[] { 0, 0, 0, 0, 1, 1, 0, 0, 0, 0 };

            var grid = new int[][] {
                    row1,
                    row2,
                    row3,
                    row4,
                    row5,
                    row6,
                    row7,
                    row8,
                    row9,
                    row10
                };
            Console.WriteLine(ShortestBridge(grid));
        }
    }
}
