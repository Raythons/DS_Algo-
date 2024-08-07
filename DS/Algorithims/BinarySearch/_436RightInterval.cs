using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithims.BinarySearch
{
    public class _436RightInterval
    {
        static int FoundInterval(List<int[]> intervals, int val, int idx)
        {
            if (intervals[idx][0] >= val)
                return intervals[idx][1];
            return -1;
        }

        int[] FindRightInterval(int[][] intervals)
        {
            List<int[]> sortedInterval = new List<int[]>();

            for (int i = 0; i < intervals.Length; i++)
            {
                int[] vals = new int[] { intervals[i][0], i };
                sortedInterval.Add(vals);
            }
            sortedInterval = sortedInterval.OrderBy(x => x[0]).ToList();

            int[] ansArray = new int[sortedInterval.Count];

            for (int i = 0; i < intervals.Length; i++)
            {
                int start = 0;
                int end = sortedInterval.Count - 1;
                var ans = -1;
                while (start <= end)
                {
                    int mid = start + (end - start) / 2;
                    int currans = 0;
                    if ((currans = FoundInterval(sortedInterval, intervals[i][1], mid)) != -1)
                    {
                        ans = currans;
                        end = mid - 1;
                    }
                    else
                        start = mid + 1;
                }
                ansArray[i] = ans;
            }
            return ansArray;
        }
    }
}
