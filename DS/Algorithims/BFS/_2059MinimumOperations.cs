using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithims.BFS
{
    public static class _2059MinimumOperations
    {

        private static bool process(
            Queue<int> queue,
            List<int> visited,
            int cur, 
            int goal)
        {
            if (cur == goal)
                return true;
            if (cur < 0 || cur > 1000)
                return false;
           if (visited[cur] == 0)
            {
                visited[cur] = 1;
                queue.Enqueue(cur);
            }
            return false;
        }

        public static int MinimumOperations(int[] nums, int start, int goal) 
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);

            List<int> visited = new List<int>(new int [1001]);

            visited[start] = 1;

            for (int level = 0 , sz = 1; queue.Count != 0  ; ++level, sz = queue.Count)
            {
                while (sz-- != 0)
                {
                    int cur = queue.Dequeue();

                    for (int i = 0 ; i < nums.Length; i++)  {
                        if (process(queue, visited, cur + nums[i], goal) ||
                            process(queue, visited, cur - nums[i], goal) ||
                            process(queue, visited, cur ^ nums[i], goal) )
                            return level + 1;
                    }
                   
                }
            }
            return -1;
        }
        public  static void Run ()
        {

            var arr = new int[] { 2, 4, 12 };
            int num = 2;
            Console.WriteLine(_2059MinimumOperations.MinimumOperations(arr, num, 12));
        }
      
    }
    
  }
