using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public static class _128LCN
    {
        public static int LongestConsecutive(int[] nums)
        {
            var LCN = new HashSet<int>();
            var longgest = 0;

            for (int i = 0; i < nums.Length; i++)
                LCN.Add(nums[i]);

            for (int i = 0; i < nums.Length; i++)
            {
                if (!LCN.Contains(nums[i] - 1))
                {
                    var length = 0;
                    while (LCN.Contains(nums[i] + length))
                    {
                        length++;
                    }

                    longgest = int.Max(longgest, length);
                }

            }
            return longgest;
        }

        public static void Run()
        {
            var nums = new int[] { 100, 4, 200, 1, 3, 2 };
            Console.WriteLine(LongestConsecutive(nums));
        }

    }
}
