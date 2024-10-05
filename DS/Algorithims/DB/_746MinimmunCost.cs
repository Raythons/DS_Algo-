//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Algorithims.DB
//{
//    public static class _746MinimmunCost
//    {
//        public static int[] StaticCosts;
//        public static int[][] Memo;

//        public static int MinCostClimbingStairs(int[] cost)
//        {
//           StaticCosts = cost;
//            Memo = Enumerable.Repeat(-1, 1001)
//                    .Select(i => Enumerable.Repeat(-1, 1000).ToArray())
//                    .ToArray();
//            return MinCostClimbingStairsHelper(0, 0);

//        }

//        //public static int MinCostClimbingStairsHelper(int idx, int cost)
//        //{
//        //    if (idx == StaticCosts.Length)
//        //        return 0;

//        //    var ret = Memo[idx][cost];

//        //    if(ret != -1)
//        //        return ret;

//        //    var pick = StaticCosts[idx] + 

//        //}
//    }
//}
