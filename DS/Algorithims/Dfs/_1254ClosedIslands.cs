using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithims.Dfs
{
    public static  class _1254ClosedIslands
    {
        public static int[] dirRowArray = new int[] { 1, 0, -1, 0 };
        public static int[] dirColArray = new int[] { 0, 1, 0, -1 };

        public static bool DidTouchBoundry = false;

        public static bool isGridBoundry(int row, int col, List<List<int>> grid)
        {
            if (row == 0 || row == grid.Count - 1)
                return true;
            if (col == 0 || col == grid[0].Count - 1)
                return true;
            return false;
        }

        public static bool isValid(int row, int col, List<List<int>> image)
        {
            if (row < 0 || row > image.Count - 1)
                return false;
            if (col < 0 || col > image[0].Count - 1)
                return false;
            return true;
        }

        public static void ClosedIslandsDfs(int row, int col, List<List<int>> grid,
            List<List<int>> ccIDs, int ccId)
        {
            if (!isValid(row, col, grid) || ccIDs[row][col] != 0 || grid[row][col] == 1)
                return;

            if (isGridBoundry(row, col, grid))
                DidTouchBoundry = true;

            ccIDs[row][col] = ccId;
            for (int i = 0; i < dirRowArray.Length; i++)
                ClosedIslandsDfs(row + dirRowArray[i], col + dirColArray[i], grid, ccIDs, ccId);
        }

        public static int ClosedIslands(List<List<int>> grid)
        {
            List<List<int>> ccIDs = Enumerable.Range(0, grid.Count)
                                  .Select(i => new List<int>(grid[0].Count))
                                  .ToList();

            int rows = grid.Count, cols = grid[0].Count, ccId = 0, count = 0;

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    DidTouchBoundry = false;
                    ClosedIslandsDfs(r, c, grid, ccIDs, ++ccId);
                    if (!DidTouchBoundry) count++;
                }
            }
            return count;
        }

    }
}
