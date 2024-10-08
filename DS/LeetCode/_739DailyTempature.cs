using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class Solution
    {
        public int[] DailyTemperatures(int[] temperatures)
        {
            int[] ans = new int[temperatures.Length];
            var st = new Stack<(int temp, int index)>();

            for (int i = 0; i < temperatures.Length; i++)
            {
                while (st.Count > 0 && temperatures[i] > st.Peek().temp)
                {
                    (int temp, int index) = st.Pop();
                    ans[index] = i - index;
                }
                st.Push((temperatures[i], i));
            }
            return ans;
        }

    }
}
