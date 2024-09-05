using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HashSetGraph = System.Collections.Generic.List<System.Collections.Generic.HashSet<int>>;

namespace Algorithims
{
    public static class GraphOfHashSet
    {
        public static void Add(HashSetGraph graph, int from, int to, int cost)
        { // Almost o(1) 
            graph[from].Add(to);
        }

        public static void PrintHashSetGraph(HashSetGraph graph)
        {
            for (int i = 0; i < graph.Count; i++) { 
                Console.WriteLine(graph[i]  + " " + " Have Neighbours :" );
                foreach (var item in graph[i])
                {
                    Console.WriteLine(item);
                } 
            }
        }
        public static void CreateAndAddAndPrint()
        {
            HashSetGraph graph = new HashSetGraph();
            Add(graph, 15, 33, 288);
            Add(graph, 10, 32, 800);
            Add(graph, 1, 3, 5);
            Add(graph, 2, 3, 2);
            Add(graph, 3, 3, 8);
            Add(graph, 20, 15, 18);

            PrintHashSetGraph(graph);
        }

    }
}

