//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Algorithims.DB
//{
//    public static class CodeForcesRound972Div2
//    {
//        public static char[] MyChars = new char[] { 'a', 'e', 'i', 'o', 'u' };
//        public static int Num = 0;
//        public static int[][] Memo ;
//        public static int Solves (int n, string fullstr,  char ComingWith)
//        {
//            if (n == Num)
//                return 0;

//            var ret = Memo[n][(int)ComingWith];
//            if (ret != -1)
//                return ret;

//            var takeA = Solves(n + 1, 'a');
//            var takeE = Solves(n + 1, 'e');
//            var takeI = Solves(n + 1 , 'i');
//            var takeO = Solves(n + 1, 'o');
//            var takeU = Solves(n + 1, 'u');

//            var Min = int.Min(int.Min(int.Min(takeA, takeE), int.Min(takeI, takeO)), takeU);

//            Memo[n][(int)ComingWith] = Min;
//            return 0;
//        }

//        public static void Run ()
//        {
//            int num = 2;
//            Num = num;

//            Memo = Memo = Enumerable.Repeat(0, 101)
//                        .Select(s => Enumerable.Repeat(-1, 118).ToArray())
//                        .ToArray();

//            Console.WriteLine(num);

//        }

//    }
//}
