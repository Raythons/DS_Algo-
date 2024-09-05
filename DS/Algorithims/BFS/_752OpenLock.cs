using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithims.BFS
{
    public static class _752OpenLock
    {
        public static int OpenLock(string[] deadends, string target)
        {
            
            Queue<string> queue = new Queue<string>();
            HashSet<string> codes = new HashSet<string>();

            string start = "0000";
            foreach (string deadend in deadends)
                codes.Add(deadend);

            queue.Enqueue(start);
            codes.Contains(start);
            for (int level = 0, sz = 1; queue.Count != 0; ++level, sz = queue.Count)
            {
                while (sz-- != 0)
                {
                    var cur = queue.Dequeue();

                    for (int i = 0; i < 4; i++)
                    {
                        StringBuilder curBuilder = new StringBuilder(cur);
                        curBuilder[i] = next(cur[i]);
                        cur = curBuilder.ToString();

                        if (cur == target)
                            return level+ 1;

                        if(codes.Add(cur))
                            queue.Enqueue(cur);


                        curBuilder[i] = prev(prev(cur[i]));
                        cur = curBuilder.ToString();

                        cur = curBuilder.ToString();
                        if (cur == target)
                            return level+ 1;

                        if (codes.Add(cur))
                            queue.Enqueue(cur);

                        curBuilder[i] = next(cur[i]);

                       cur = curBuilder.ToString();
                    }
                }
            }
            return -1;
        }

         public static char prev(char v)
        {
            if ((int)v == 48)
                return '9';

            var c = (int)v - 1;
            return (char)c;
        }

        public static char next(char v)
        {
            if ((int)v == 57)
                return '0';
            var c = (int)v + 1;
            return (char)c;

        }
        public static void Run() {

            var deadends = new string[] { "0201", "0101", "0102", "1212", "2002", "0201" };
            var target = "0202";

            Console.WriteLine(OpenLock(deadends, target));
        }
    }
}
