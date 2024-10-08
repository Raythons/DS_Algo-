using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public static class _22GenerateParenthes
    {
        public static IList<string> GenerateParenthesis(int n)
        {
            List<string> result = new List<string>();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < n; i++)
                sb.Append('(');
            for (int i = 0; i < n; i++)
                sb.Append(')');

            List<string> AllPossiblePaenthesis = new List<string>();

            for (int i = 0; i < sb.Length; i++)
            {
                StringBuilder part = new StringBuilder();
                for (int j = 0; j< sb.Length; j++)
                {
                    part.Append(sb[j]);
                }
                AllPossiblePaenthesis.Add(part.ToString());
            }
            FillAllFormedParentheses(result, AllPossiblePaenthesis);

            return result;
        }
        private  static char IdenticalParen(char c)
        {
            if (c == ')')
                return '(';
             else 
                return ')';
        }

        private static void FillAllFormedParentheses(List<string> result, List<string> allPossiblePaenthesis)
        {
            for (int i = 0; i < allPossiblePaenthesis.Count; i++) { 

                Stack<char> parts = new Stack<char>();
                for(int j = 0; j < allPossiblePaenthesis[i].Length; j++)
                {
                    if (parts.Count > 0 && parts.Peek() == IdenticalParen(allPossiblePaenthesis[i][j]))
                        parts.Pop();
                    
                }
                if(parts.Count == 0)
                    result.Add(allPossiblePaenthesis[i]);
            }
        }
    }
}
