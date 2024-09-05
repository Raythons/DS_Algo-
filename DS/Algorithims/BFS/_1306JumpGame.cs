using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithims.BFS
{
    public static class _1306JumpGame
    {

        private static bool process(List<int> visited, Queue<int> queue, int[] arr, int idx)
        {
            if (idx <= 0 || idx >= arr.Length || visited[idx] != 0)
                return false;

            if (arr[idx] == 0)
                return true;

            visited[idx] = 1;
            queue.Enqueue(idx);
            return false;
        }
        public  static bool CanReach(int[] arr, int start)
        {
            if (arr[start] == 0)
                return true;

            List<int> visited =  Enumerable.Repeat(0, arr.Length)
                                            .Select(x => 0)
                                            .ToList();

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);
            visited[start] = 1;

            for (int level = 0 , sz = 0; queue.Count != 0; ++level,  sz = queue.Count)
            {
                while (sz-- > 0)
                {
                    var cur = queue.Dequeue();
                    if (process(visited, queue, arr, cur + arr[cur]) ||
                        process(visited, queue, arr, cur - arr[cur]) )
                        return true;   
                }
            }
            return false;
        }
       
    }
}

