using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithims.BinarySearch
{
    public class _1482MinDaysToBloom
    {
        static bool isPossibleGuardian(int[] guardian, int m, int k, int NumberOfDays)
        {
            int sum = 0;
            for (int i = 0; i < guardian.Length; i++)
            {
                if (guardian[i] <= NumberOfDays)
                    sum += 1;
                if (sum == k)
                {
                    --m;
                    sum = 0;
                }
                else if (guardian[i] > NumberOfDays)
                {
                    sum = 0;
                }

            }
            return m <= 0;
        }

        // LeetCode 1482
        static int MinDays(int[] bloomDay, int m, int k)
        {
            int start = 1;
            int end = bloomDay.Max();


            int numberOfDays = -1;
            // log n
            while (start <= end)
            {
                int mid = start + (end - start) / 2;
                if (isPossibleGuardian(bloomDay, m, k, mid))
                {
                    numberOfDays = mid;
                    end = mid - 1;
                }
                else
                    start = mid + 1;

            }
            return numberOfDays;
        }

    }
}
