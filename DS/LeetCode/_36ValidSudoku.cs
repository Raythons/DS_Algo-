using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public static class _36ValidSudoku
    {
        public static  bool IsValidSudoku(char[][] board)
        {
            var  numberOccured= new Dictionary<int, bool>();
            
            if(!isValidRows(board))
                return false;
            if(!isValidCols(board))
                return false;
            if(!isValidBlocks(board))
                return false;
            return true;

        }

        private static bool isValidBlocks(char[][] board)
        {
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[0].Length; j++)
                {
                    HashSet<int> sqRecords = new HashSet<int>();
                    for (int m = i; m < i + 3; m++)
                    {
                        for (int n = j; n < j + 3; n++)
                        {
                            if (board[m][n] == '.') continue;
                            if (sqRecords.Contains(board[m][n])) return false;
                            sqRecords.Add(board[m][n]);
                        }
                    }
                    j += 2;
                }
                i += 2;
            }

            return true;
        }
        private static bool isValidCols(char[][] board)
        {
            for (int i = 0; i < board[0].Length; i++)
            {
                var numberOccured = new Dictionary<int, bool>();
                for (int j = 0; j < board.Length; j++)
                {
                    if (board[i][j] == '.') continue;

                    if (numberOccured.ContainsKey(board[j][i]))
                        return false;
                    numberOccured[board[j][i]] = true;
                }
            }
            return true;
        }

        private static bool isValidRows(char[][] board)
        {

            for (int i = 0; i < board.Length; i++) {
                var numberOccured = new Dictionary<int, bool>();
                for (int j = 0; j < board[0].Length; j++) {
                    if (board[i][j] == '.') continue;
                    if (numberOccured.ContainsKey(board[i][j]))
                        return false;
                    numberOccured[board[i][j]] = true;
                }
            }

            return true;
        }
    }
}
