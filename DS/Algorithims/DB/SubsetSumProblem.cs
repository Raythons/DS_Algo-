using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithims.DB
{
    public static class SubsetSumProblem
    {
        public static int[] Vals = new int[] { 3, 40, 4, 12, 5, 2 };
        public static int[,] Memo = new int[Vals.Length, 30 + 1];
        public static bool SubsetSumProblemSol(int idx, int target)
        {
            if (idx == Vals.Length || target < 0)
                return false;

            var ret = Memo[idx,target];
            if (ret == -1)
                return false;
            if (ret == 1) 
                return true;
            if (target - Vals[idx] == 0)
                return true;

            var pick = SubsetSumProblemSol(idx + 1, target - Vals[idx]);
            if (pick)
            {
                Memo[idx, target] = 1;
                return true;
            }
            var leave = SubsetSumProblemSol(idx + 1, target);
            if (leave)
            {
                Memo[idx, target] = 1;
                return true;
            }
            Memo[idx, target] = -1;
            return  false;
        }

        public static void Run()
        {
            Console.WriteLine(SubsetSumProblemSol(0, 30));
        }
    }



}

