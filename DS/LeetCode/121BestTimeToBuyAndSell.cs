using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public static class _121BestTimeToBuyAndSell
    {
        public static int[] StaticPrices { get; set; }
        public static int[][] Memo { get; set; }

        public static int MaxProfitHelper(int idx,  int stock)
        {


            if (idx == StaticPrices.Length)
                return 0;

            var ret = Memo[idx][stock];
            if (ret != -1)
                return ret;

            var leave =  MaxProfitHelper(idx + 1,  stock);


            var sell = 0;
            if (stock != 0)
            {
                sell =  StaticPrices[idx];
            }

            var buy = 0;
            if (stock == 0)
                 buy = -StaticPrices[idx] +  MaxProfitHelper(idx + 1, stock + 1);

            var maxProfit = Math.Max(Math.Max(leave, buy), sell);
            Memo[idx][stock] = maxProfit;

            return maxProfit;
        }

        public static int MaxProfit(int[] prices)
        {
            prices = new int[] { 7, 6, 4, 3, 1 };
            StaticPrices = prices;
            if (prices.Length == 1)
                return 0;
            Memo = Enumerable.Repeat(-1, prices.Length )
                      .Select(x => new int[] { -1, -1 })
                      .ToArray()
                        .ToArray();

            return MaxProfitHelper(0, 0);
        }
        public static void Run ()
        {
            Console.WriteLine(MaxProfit(new int[] {  }));
        }
    }
}
