using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Graph = System.Collections.Generic.List<System.Collections.Generic.List<int>>;

namespace Algorithims.Dfs
{
    public static class _785IsBipartite
    {

        static void Dfs(
                    int[][] graph,
                    int node,
                    Dictionary<int, int> Red,
                    Dictionary<int, int> Black,
                    bool isRed = true)
        {

           if (Black.ContainsKey(node) ||  Red.ContainsKey(node))
                return;

            if (isRed)
                Red.Add(node, node);
            else
                Black.Add(node, node);

            foreach (int neighbor in graph[node])
            {
                if (isRed && Red.ContainsKey(neighbor) || !isRed && Black.ContainsKey(neighbor))
                    CanBipartite = false;
                Dfs(graph, neighbor, Red, Black, !isRed);
            }     
        }
        public static bool CanBipartite { get ; set; } = true;

        public static bool IsBipartite(int[][] graph)
        {
            Dictionary<int, int> Reds = new Dictionary<int, int>();
            Dictionary<int, int> Blacks =  new Dictionary<int, int>();

            for (int i = 0; i < graph.Length; i++)
            {
                 Dfs(graph, i, Reds, Blacks);
                 if(!CanBipartite)
                      return false;  
            }
            return true;
        }
        public static void Run ()
        {
            //var pair1 = new int[] { 1, 2, 3 };
            //var pair2 = new int[] { 0, 2 };
            //var pair3 = new int[] { 0, 1, 3 };
            //var pair4 = new int[] { 0, 2 };

            var pair1 = new int[] { 1, 3 };
            var pair2 = new int[] { 0, 2 };
            var pair3 = new int[] { 1, 3 };
            var pair4 = new int[] { 0, 2 };
            var paris = new int[][] { pair1, pair2, pair3, pair4 };

            Console.WriteLine(_785IsBipartite.IsBipartite(paris));

        }

    }
}
