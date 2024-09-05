using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Algorithims.Dfs
{
    public static class MatrixDfs
    {

        public static int[] dirRowArray = new int[] { 1, 0, -1, 0 };
        public static int[] dirColArray = new int[] { 0, 1, 0, -1 };
        //733   Fill Flood


        public static bool isValid(int row, int col , List<List<int>> image)
        {
            if (row < 0 || row > image.Count - 1)
                return false;
            if (col < 0 || col > image[0].Count - 1)
                return  false;
            return true;      
        }

        public static List<List<int>> FloodFill (List<List<int>> image, int SourceRow,
            int SourceCol, int newColor)
        {
          List<List<int>> visited = Enumerable.Range(0, image.Count)
                                   .Select(i => new List<int>(image[0].Count))
                                   .ToList();

            ImageDfs(SourceRow, SourceCol, image, visited, image[SourceRow][SourceCol], newColor); 
            return image;
        }
        
        public static void ImageDfs(int row , int col , List<List<int>> matrix,
            List<List<int>> visited, int oldColor , int newColor)
        {
            if (!isValid(row, col, matrix) || visited[row][col] != 0 || matrix[row][col] != oldColor)
                return;

     
            for (int i = 0; i < dirRowArray.Length; i++)
                ImageDfs(row + dirRowArray[i], col + dirColArray[i], matrix, visited, oldColor, newColor);

        }

        // 1254LeetCode
       
      
        
        //LeetCode Coliornig Border
        public static void ColoringBorderDfs(List<List<int>> grid, int row , int col ,
            int oldColor , List<List<int>>  visited)
        {
            if (!isValid(row, col, grid) || visited[row][col] != 0 || grid[row][col] != oldColor)
                return;


            visited[row][col] = 1;

            for (int d = 0; d < 4; ++d)
                ColoringBorderDfs(grid , row + dirRowArray[d], col + dirColArray[d], oldColor, visited);
        }
        
        public static void CreateBoundries(List<List<int>> grid, List<List<int>> visited, int newColor)
        {
            int rows = grid.Count, cols = grid[0].Count();

            for (int r = 0; r < rows; ++r)
            {
                for (int c = 0; c < cols; ++c)
                {
                    for (int d = 0; d < 4; ++d)
                    {
                        if (visited[r][c] == 0)
                            continue;   // NOT part of the CC
                        int nr = r + dirRowArray[d], nc = c + dirColArray[d];
                        if (!isValid(nr, nc, grid) || visited[nr][nc] != 1)
                            grid[r][c] = newColor;  // Boundary
                    }
                }
            }
        }
        public static int [][] ColoringBorder(int[][] grid, int row, int col, int color)
        {
            List<List<int>> visited = Enumerable.Range(0, grid.Length)
                                  .Select(i => Enumerable.Repeat(0, grid[0].Length).ToList())
                                  .ToList();

            List<List<int>> listedGrid = grid.Select(x => x.ToList()).ToList();

            ColoringBorderDfs(listedGrid, row, col, grid[row][col], visited);

            CreateBoundries(listedGrid, visited, color);

            int[][] s = listedGrid.Select(x => x.ToArray()).ToArray();
            return s;

        }
    }
}
