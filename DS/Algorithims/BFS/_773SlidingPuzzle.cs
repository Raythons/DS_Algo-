using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Algorithims.BFS._365WaterAndJug;

namespace Algorithims.BFS
{
    public static class _773SlidingPuzzle
    {

        public static int[] dirRowArray = new int[] { 1, 0, -1, 0 };
        public static int[] dirColArray = new int[] { 0, 1, 0, -1 };
        public static bool gotVisited  = false;
        public static bool isValid(int row, int col, int[][] matrix)
        {
            if (row < 0 || row > matrix.Length - 1)
                return false;
            if (col < 0 || col > matrix[0].Length - 1)
                return false;
            return true;
        }

        public class Board
        {
            public int[][] BoardState { get; set; }
            public (int i , int j) ZeroIdx { get; set; }
            public Board(int[][] board, (int i, int j) zeroIdx) {
                BoardState = board;
                ZeroIdx = zeroIdx;
            }

        }
        public static int SlidingPuzzle(int[][] board)
        {
            Queue<Board> q = new Queue<Board>();
            Dictionary<(string board, (int i, int j)), bool> visited = new();

            var startIdx = (0,0);
            for (int i = 0; i < board.Length; i++)
                for (int j = 0; j < board[i].Length; j++)
                    if (board[i][j] == 0)
                        startIdx = (i, j);
      
            Board start =  new Board (board, startIdx);
            q.Enqueue(start);

            for (int level = 0, sz = q.Count; q.Count > 0; ++level, sz = q.Count)
            {
                while (sz-- > 0)
                {
                    var cur = q.Dequeue();

                    if (process(cur,q,visited))
                        return level ;

                }
              

            }
            return -1;
        }

        public static string TwoDArrayToString(int[][] board)
        {
            string s = "";
            for (int i = 0;i < board.Length; i++)
                for(int j = 0;j < board[i].Length; j++)
                    s += board[i][j].ToString();

            return s;
        }
        private static bool process(Board cur,
            Queue<Board> q,
            Dictionary<(string board, (int i, int j)), bool> visited)
        {
            (int i, int j) = cur.ZeroIdx;
            int[][] board = cur.BoardState;

            if (visited.ContainsKey((TwoDArrayToString(board), (i, j))))
                return false;

            if (Succes(board, i, j))
                return true;

            for (int iterator = 0; iterator < 4; iterator++)
                    handleSwap(board, i , j , i + dirRowArray[iterator], j + dirColArray[iterator], visited, q);

            visited.Add((TwoDArrayToString(board), (i, j)), true);
            return false;
        }

        private static void handleSwap(int[][] board,
            int curI, int curJ,
            int neighbourRow,
            int neighbourCol,
            Dictionary<(string board, (int i, int j)), bool> visited,
            Queue<Board> q
            )
        {
            if (!isValid(neighbourRow, neighbourCol, board) )
                return;

            (board[curI][curJ], board[neighbourRow][neighbourCol]) = (board[neighbourRow][neighbourCol], board[curI][curJ]);

            if (visited.ContainsKey((TwoDArrayToString(board), (neighbourRow, neighbourCol))))
            {
                (board[neighbourRow][neighbourCol], board[curI][curJ]) = (board[curI][curJ], board[neighbourRow][neighbourCol]);
                return;
            }


            Board boardToEnqueue = new Board(board.Select(row => row.ToArray()).ToArray(), (neighbourRow, neighbourCol));
            q.Enqueue(boardToEnqueue);

            (board[neighbourRow][neighbourCol], board[curI][curJ]) = (board[curI][curJ], board[neighbourRow][neighbourCol]);

        }

        private static bool Succes(int[][] board, int i, int j)
        {
            if (board[board.Length - 1][board[0].Length - 1] != 0) 
                return false;

            var row1 = new int[] { 1, 2, 3 };
            var row2 = new int[] { 4, 5, 0 };

            int[][] goodMatrix = new int[][] { row1, row2 } ;

            for (int i1 = 0; i1 < board.Length; i1++)
                for (int j1 = 0; j1 < board[0].Length; j1++)
                    if (board[i1][j1] != goodMatrix[i1][j1])
                        return false;
            
            return true;                
        }


        public static void Run()
        {
            var arr1 = new int[] { 1, 2, 3 };
            var arr2 = new int[] { 5, 4, 0 };
            var board = new int[][] { arr1, arr2 };

            Console.WriteLine(SlidingPuzzle(board));
        }

       
    }
}

