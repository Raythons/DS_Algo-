using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithims.DB
{
    public static class _198RobberHouse
    {

        public enum EnState
        {
            Stole,
            DidntStole,
        }


        public static int[] staticNums { get; set; }
        public static int[][] Memo;

        public  static int Rob(int[] nums)
        {
            if (nums.Length == 1)
                return nums[0];

            Memo = Enumerable.Repeat(0, 101)
                      .Select(s => Enumerable.Repeat(-1, 101).ToArray())
                      .ToArray();

            staticNums = nums;
            return LIS(0, EnState.DidntStole);
        }

        public  static int LIS(int i, EnState state)
        {
            if (i == staticNums.Length)
                return 0;

            var ret = Memo[i][(int)state];
            if(ret != -1)
                return ret;

            var Leave = LIS( i + 1, EnState.DidntStole);

            var Pick = 0;
            if (state == EnState.DidntStole)
                Pick = staticNums[i] + LIS(i + 1, EnState.Stole);

            var Max = int.Max(Leave, Pick);

            Memo[i][(int)state] = Max;
            return Max;
        }
        public  static void Run ()
        {
            var nums = new int[] { 2, 7, 9, 3, 1 };

            Console.WriteLine(Rob(nums));
        }
    }
}
