using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public static class _88RemoveDuplicateII
    {
        public static int  RemoveDuplicates(int[] nums)
        {
            if (nums.Length <= 2)
                return nums.Length;

            int l = 0;
            int r = 0;
            while (r < nums.Length)
            {
                int count = 1;
                while (r + 1 < nums.Length && nums[r] == nums[r + 1])
                {
                    r++;
                    count++;
                }

                for (int i = 0; i < int.Min(count, 2); i++)
                {
                    nums[l] = nums[r];
                    l += 1;
                }
                r += 1;
            }
            return l;
        }
    
        public static  void Run()
        {
            var nums = new int[] { 1, 1, 1, 2, 2, 3 };
            Console.WriteLine(RemoveDuplicates(nums));
        }
    }
}
