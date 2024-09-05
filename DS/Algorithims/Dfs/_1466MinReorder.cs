using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Graph = System.Collections.Generic.List<System.Collections.Generic.List<int>>;

namespace Algorithims.Dfs
{
    public static class _1466MinReorder
    {
        static void AddUnDirectedEdge(Graph graph, int from, int to)
        {
            graph[from].Add(to);
            graph[to].Add(from);
        }
        static void AddDirectedEdge(Graph graph, int from, int to)
        {
            graph[from][to] = 1;
        }

        static void Dfs(Graph graph, int node, List<int> visited)
        {                       
            visited[node] = 1;
            
            foreach (int neighbor in graph[node])
            {
                if (node < graph[node][neighbor] && graph[neighbor][node] == 0 )
                {
                    AddDirectedEdge(graph, neighbor, node);
                    AddedEdges += 1;
                }
                if (visited[neighbor] == -1)
                    Dfs(graph, neighbor, visited);
            }
        }
        
        public static  int  AddedEdges { get; set; } = 0;
        public static int MinReOrder(int n, int [][] connections)
        {
            Graph graph = Enumerable.Range(0, n)
                                  .Select(i => new List<int>(n) { 0,0,0,0,0,0 })
                                  .ToList();

            for (int i = 0; i < connections.Length; i++)
                AddDirectedEdge(graph, connections[i][0], connections[i][1]);

            List<int> visited = Enumerable.Range(0, graph.Count).Select(x => -1).ToList();

            for (int i = 0; i < n; i++)
            {
               Dfs(graph, i, visited);  
            }

            return AddedEdges;
        }

        public static void Run ()
        {

            var pair1 = new int[] { 0, 1 };
            var pair2 = new int[] { 1, 3 };
            var pair3 = new int[] { 2, 3 };
            var pair4 = new int[] { 4, 0 };
            var pair5 = new int[] { 4, 5 };

            var paris = new int[][] { pair1, pair2, pair3, pair4 , pair5 };

            Console.WriteLine(MinReOrder(6, paris));
        }
    }
}
