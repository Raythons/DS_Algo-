using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


using Graph = System.Collections.Generic.List<System.Collections.Generic.List<int>>;

namespace Algorithims.BFS
{
    public  static class BasicBFS
    {

        public static List<int> BFS_v2(List<List<int>> adjList, int start)
        {
            List<int> len = Enumerable.Repeat(int.MaxValue, adjList.Count).ToList();
            Queue<int> q = new Queue<int>();
            q.Enqueue(start);

            len[start] = 0;

            for (int level = 0, sz = 1; q.Count > 0; ++level, sz = q.Count)
            {
                while (sz-- > 0)
                {
                    int cur = q.Dequeue();

                    foreach (int neighbor in adjList[cur])
                    {
                        if (len[neighbor] == int.MaxValue)
                        {
                            q.Enqueue(neighbor);
                            len[neighbor] = level + 1;
                        }
                    }
                }
            }

            return len;
        }
    }
}
