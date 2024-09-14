using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithims.DB
{
    public static class _309ButSell
    {
        public enum EnBuySell
        {
            Buy, 
            Sell,
            Nothing
        }
        public static int[] StaticPrices;
        public static int[][][] Memo;
        public static int MaxProfit(int[] prices)
        {
            if (prices.Length == 1)
                return prices[0];

            Memo = Enumerable.Repeat(0, 5001)
                               .Select(
                                        s => Enumerable.Repeat(-1, 3).
                                                Select(s => Enumerable.Repeat(-1, 2).ToArray()).ToArray())
                                       .ToArray();

            StaticPrices = prices;
            return LIS(0, EnBuySell.Nothing, false);
        }

        public  static int LIS(int idx, EnBuySell LastOpertaion, bool haveStock)
        {
            if (idx == StaticPrices.Length)
                return 0;

            var ret = Memo[idx][(int)LastOpertaion][haveStock ? 1 : 0];
            if (ret != -1)
                return ret;

            var doNothing = LIS(idx + 1, EnBuySell.Nothing, haveStock);

            var buy = 0;
            var sell =0 ;

            if (haveStock)
                sell = StaticPrices[idx] +  LIS(idx + 1, EnBuySell.Sell, false);

            else if (LastOpertaion is not  EnBuySell.Sell )
                buy = -StaticPrices[idx] +  LIS(idx + 1 , EnBuySell.Buy, true);

            var Max = int.Max(int.Max(buy, sell), doNothing);

            Memo[idx][(int)LastOpertaion][haveStock ? 1 : 0] = Max;
            return Max;
        }

        public  static void Run()
        {
            var prices =  new int[] { 1, 2, 3, 0, 2 };

            Console.WriteLine(MaxProfit(prices));
        }
    }
}
