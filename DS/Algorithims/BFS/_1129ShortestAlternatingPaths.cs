using Algorithims.BFS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Algorithims.BFS._1129ShortestAlternatingPaths;

namespace Algorithims.BFS
{
    public static class _1129ShortestAlternatingPaths
    {
        public  enum EnColor
        {
            Red,
            Blue,
            Both,
            Empty
        }


        public static void BuildGraph(edge[][]  graph, int[][] redEdges, int[][] blueEdges)
        {


            for (int i = 0; i < redEdges.Length; i++)
            {
                if (graph[redEdges[i][0]][redEdges[i][1]] == null)
                    graph[redEdges[i][0]][redEdges[i][1]] = new edge { color = EnColor.Red };

            }
            for (int i = 0; i < blueEdges.Length; i++)
            {
                if (graph[redEdges[i][0]][redEdges[i][1]] == null)
                    graph[redEdges[i][0]][redEdges[i][1]] = new edge { color = EnColor.Blue };
                else
                    graph[redEdges[i][0]][redEdges[i][1]] = new edge { color = EnColor.Both };
            }

        }


        public static void dfsGraph(edge[][] graph, int[][] edges, EnColor color, int[] result)
        {
            Queue<int> q = new Queue<int>();
            Dictionary<int, bool> visitedRed= new Dictionary<int, bool>();
            Dictionary<int, bool> visitedBlue = new Dictionary<int, bool>();
            q.Enqueue(0);

            for (int level = 0, sz = q.Count; q.Count > 0; ++level, sz = q.Count)
            {
                while (sz-- > 0)
                {
                    var cur = q.Dequeue();

                    if (color == EnColor.Red && visitedRed.TryGetValue(cur, out var isRedVisited) && isRedVisited ||
                        color == EnColor.Blue && visitedBlue.TryGetValue(cur, out var isBlueVisited) && isBlueVisited)
                        continue;

                    for (int i = 0; i < graph[0].Length ; i++)
                    {
                        if (graph[cur][i] != null)
                        {
                            if(graph[cur][i].color == color || graph[cur][i].color == EnColor.Both)
                            {
                                q.Enqueue(i); 
                                if (result[i] == -1 || level < result[i])
                                    result[i] = level +1  ;
                            }
                        }
                    }
                    if (color == EnColor.Red)
                        visitedRed.Add(cur, true);
                    else
                        visitedBlue.Add(cur, true);
                }
                if (color == EnColor.Red)
                    color = EnColor.Blue;
                else
                    color = EnColor.Red;
            }
        }

        public static int[] ShortestAlternatingPaths(int n, int[][] redEdges, int[][] blueEdges)
        {
            edge[][] graph = Enumerable.Repeat(new edge[n], n).ToArray(); 

            BuildGraph(graph, redEdges, blueEdges);
            int[] result = Enumerable.Repeat(-1, n).ToArray();

            dfsGraph(graph, redEdges, EnColor.Red, result);
            //dfsGraph(graph, blueEdges, EnColor.Blue, result);
            result[0] = 0;
            return result;
        }

        public static void Run()
        {
            int n = 5;
            var r1 = new int[] { 0, 1 };
            var r2 = new int[] { 1, 2 };
            var r3 = new int[] { 2, 3 };
            var r4 = new int[] { 4, 4 };

            var b1 = new int[] { 1, 2 };
            var b2 = new int[] { 2, 3 };
            var b3 = new int[] { 3, 1 };

            var redEdges = new int[][] { r1, r2,r3,r4 };
            var blueEdges = new int[][] { b1,b2,b3};
            var answer = ShortestAlternatingPaths(n, redEdges, blueEdges);

            foreach (var item in answer)
                Console.WriteLine(item);

            
        }
        public class edge
        {
            public EnColor color { get; set; }
        }
    }
   

}
