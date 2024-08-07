using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithims.Sorting
{
    public class _1005MaximizeSuOfArrayAfterKNegations
    {
        static int Maximizesuofarrayafterknegations2(int[] nums, int k)
        {
            Array.Sort(nums);


            int MinVal = int.MaxValue;
            int Sum = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] < 0 && k > 0)
                {
                    k -= 1;
                    nums[i] *= -1;
                }
                Sum += i;
                MinVal = int.Min(MinVal, nums[i]);
            }

            if (k % 2 != 0)
                Sum -= 2 * MinVal;
            return Sum;

        }
    }
}
