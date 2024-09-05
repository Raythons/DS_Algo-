using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithims.Dfs
{
    public static class _1631MinimumEffortPath
    {

        public static int[] dirRowArray = new int[] { 1, 0, -1, 0 };
        public static int[] dirColArray = new int[] { 0, 1, 0, -1 };
        public static bool isValid(int row, int col, int[][] image)
        {
            if (row < 0 || row > image.Length - 1)
                return false;
            if (col < 0 || col > image[0].Length - 1)
                return false;
            return true;
        }

        public static int Min = int.MaxValue;

        public static void Dfs(int[][] heights,
                        int r, 
                        int c, 
                        int prevVal,
                        Dictionary<(int r, int c), List<(int, int)>> visited,
                        int maxSoFar = 0)
        {
            if (!isValid(r, c, heights) || visited.TryGetValue((r,c),  out var  gg) )
                return;

            maxSoFar = Math.Abs(heights[r][c] - prevVal);
            if (r == heights.Length - 1 && c == heights[0].Length - 1)
            {
                Min = int.Min(maxSoFar, Min);
                return;
            }

            for (int i = 0; i < 4; i++)
                Dfs(heights, r + dirRowArray[i], c + dirColArray[i], heights[r][c], visited, maxSoFar);
        }
        public static int MinimumEffortPath(int[][] heights)
        {
            var visited = new Dictionary<(int r,int c), List<(int, int)>>();
            Dfs(heights, 0, 0, heights[0][0], visited,  Min);
            return Min;
        }
        public static void  Run()
        {
            var pair1 = new int[] { 1, 2,2 };
            var pair2 = new int[] { 3, 8, 2 };
            var pair3 = new int[] { 5, 3, 5 };

            var heights = new int[][] { pair1 , pair2, pair3 };
            Console.WriteLine(MinimumEffortPath(heights));
        }
    }
   
}
      
            
    

