using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

// Wrong
namespace Algorithims.BFS
{
    public static class _417WaterFlow
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


        public static void handleNeighbour
            (int[][] heights ,
            int CameFromValue,
            int r,
            int c,
            Dictionary<(int r, int c), (bool Pacific, bool Atlantic)> visited,
            List<IList<int>> result, 
            (bool Pacific, bool Atlantic) visitedVals,
            Queue<(int r, int c)> q
            )
            {
            visited.TryGetValue((r, c), out var neighbourVisitedVals);

            if (!isValid(r,c ,heights) || neighbourVisitedVals.Pacific  && neighbourVisitedVals.Atlantic )
                    return;


            if (!neighbourVisitedVals.Pacific && !neighbourVisitedVals.Atlantic)
                q.Enqueue((r,c));

            if (CameFromValue <= heights[r][c])
            {
                (bool Pacific, bool Atlantic) newVals = (visitedVals.Pacific ? true : neighbourVisitedVals.Pacific,
                              visitedVals.Atlantic ? true : neighbourVisitedVals.Atlantic);

                if (newVals.Pacific && newVals.Atlantic)
                    result.Add(new int[] { r, c });

                visited[(r, c)] = newVals;
            }

          }
        public  static IList<IList<int>> PacificAtlantic(int[][] heights)
        {

            Queue<(int r, int c)> q = new();
            Dictionary<(int r, int c), (bool Pacific, bool Atlantic)> visited = new();
            List<IList<int>> result = new();

            AddAllTopLeftCells(heights, q, visited,result);
            AddAllBottomRightCells(heights, q, visited);


            for (int level = 0, sz = q.Count ; q.Count > 0; ++level, sz = q.Count)
            {
                while (sz-- > 0)
                {
                    var (r, c) = q.Dequeue();
                    visited.TryGetValue((r, c), out var visitedVals);

                    for (int i = 0; i < 4; ++i)
                        handleNeighbour(heights, heights[r][c] ,r + dirRowArray[i], c + dirColArray[i],
                                        visited, result, visitedVals, q);
                }
            }
            return result;
        }

        public static void AddAllTopLeftCells(
            int[][] heights,
            Queue<(int r, int c)> queue,
            Dictionary<(int r , int c), (bool Pacific , bool Atlantic)> visited,
            List<IList<int>> result
            )     
        {
            for (int r = 0, c = 0; c < heights[0].Length; c++)
            {
                queue.Enqueue((r, c));
                if (c == heights[0].Length - 1)
                {
                    visited.Add((r, c), (true, true));
                    result.Add( new int[] {r,c });
                }
                else
                    visited.Add((r, c), (true, false));
            }

            for (int c = 0, r = 1; r < heights.Length; r++)
            {
                queue.Enqueue((r, c));
                if(r == heights.Length - 1)
                {
                    visited.Add((r, c), (true, true));
                    result.Add(new int[] { r, c });
                } else 
                     visited.Add((r, c), (true, false));


            }
        }

          public static void AddAllBottomRightCells
            (int[][] heights,
             Queue<(int r, int c)> queue,
             Dictionary<(int r, int c), (bool Pacific, bool Atlantic)> visited)
           {
                for (int r = 1, c = heights[0].Length - 1; r < heights.Length; r++)
                {
                    queue.Enqueue((r, c));
                    visited.Add((r, c), (false, true));
                }

                for (int c = 1, r = heights.Length - 1; c <= heights[0].Length -2; c++)
                {
                    queue.Enqueue((r, c));
                    visited.Add((r, c), (false, true));
                }
           }


        public static void Run()
        {
            var r1 = new int[] { 1, 2, 2, 3, 5 };
            var r2 = new int[] { 3, 2, 3, 4, 4 };
            var r3 = new int[] { 2, 4, 5, 3, 1 };
            var r4 = new int[] { 6, 7, 1, 4, 5 };
            var r5 = new int[] { 5, 1, 1, 2, 4 };

            var heights = new int[][] { r1, r2, r3, r4, r5 };

            var gg = _417WaterFlow.PacificAtlantic(heights);
            foreach (var r in gg)
            {
                foreach (var c in r)
                    Console.Write($"[{c}]");
                Console.WriteLine();
            }
                
        }
    }
}
