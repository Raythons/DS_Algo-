using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithims.BinarySearch
{
    public class _1238SmallestDevisor
    {
        static int SumOfDivisor(int[] nums, int divisor)
        {
            decimal sum = 0;
            for (int i = 0; i < nums.Length; i++)
                sum += Math.Ceiling((decimal)nums[i] / divisor);
            return (int)sum;
        }

        static int _1238smallestDevisor(int[] nums, int thereshold)
        {
            int start = 1;
            int end = nums.Max();
            int divisor = end;

            while (start <= end)
            {
                int mid = start + (end - start) / 2;

                if (SumOfDivisor(nums, mid) <= thereshold)
                {
                    end = mid - 1;
                    divisor = mid;
                }
                else
                {
                    start = mid + 1;
                }
            }
            return divisor;

        }


    }
}
