using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithims.DB
{
    public static class _1691MaximmunHeightByCupidos
    {
        public static int[][] Sortedcuboids { get; set; }
        public static int[][] Memo ;
        public static int MaxHeight(int[][] cuboids)
        {
            foreach (var cuboid in cuboids)
                Array.Sort(cuboid);
            Sortedcuboids = cuboids.OrderBy(s => s[0]).ToArray();

            if (cuboids.Length == 0)
                return 0;
            if (cuboids.Length == 1)
                return Sortedcuboids[0][2];
            
            Memo = Enumerable.Repeat(0, 101)
                        .Select(s => Enumerable.Repeat(-1, 101).ToArray() )
                        .ToArray();

            return MaxHeightHelper(0, Sortedcuboids.Length);
        }

        private static bool LessOrEqual (int i, int j)
        {
            return Sortedcuboids[i][1] <= Sortedcuboids[j][1] &&
                   Sortedcuboids[i][2] <= Sortedcuboids[j][2];
        }

        public static int MaxHeightHelper(int cur, int prev)
        {
            if (cur == Sortedcuboids.Length)
                return 0;

            var ret = Memo[cur][prev];

            if (ret != -1)
                return ret;
            
            var Leave = MaxHeightHelper(cur + 1, prev);

            var Pick = 0;
            if ( prev == Sortedcuboids.Length || LessOrEqual(prev, cur))
                Pick = Sortedcuboids[cur][2] + MaxHeightHelper(cur + 1, cur);

            var Max = int.Max(Pick, Leave);

            Memo[cur][prev] = Max;

            return Max;
        }

        public static void Run()
        {
            var cuboids1 = new int[] { 50, 45, 20 };
            var cuboids2 = new int[] { 95, 37, 53 };
            var cuboids3 = new int[] { 45, 23, 12 };
            int[][] cuboids = new int[][] { cuboids1, cuboids2, cuboids3};

            Console.WriteLine(MaxHeight(cuboids));
        }
    }
}
