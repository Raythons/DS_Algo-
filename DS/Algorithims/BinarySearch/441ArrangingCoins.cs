using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithims.BinarySearch
{
    public class _441ArrangingCoins
    {
        static bool isPossible(int n, long rows)
        {
            long sum = (rows * (rows + 1)) / 2;
            return sum <= n;

        }
        static int _441ArrangingCoinss(int n)
        {
            int left = 0, right = n, answer = 0;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (isPossible(n, mid))
                {
                    answer = mid;
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return answer;
        }

    }
}
