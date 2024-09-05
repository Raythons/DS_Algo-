using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EdgedGraph = System.Collections.Generic.List<Algorithims.Edge>;


namespace Algorithims
{
    public static  class GraphOfEdges
    {
        public static void AddEdge(EdgedGraph graph, int from , int to , int cost ) { // Almost o(1) 
            Edge newEdge = new(from, to, cost);
            graph.Add(newEdge);
        }

        public static void PrintEdgesGraph(EdgedGraph graph) { 
            graph.Sort();
            foreach (var item in graph)
            {
                Console.WriteLine($"Edge Cost : ${item.Weight} From : ${item.From} To : ${item.To}");
            }
        }
        public static void CreateAndAddAndPrint()
        {
            EdgedGraph graph = new EdgedGraph();
            AddEdge(graph, 15, 33, 288);
            AddEdge(graph, 10, 32, 800);
            AddEdge(graph, 1, 3, 5);
            AddEdge(graph, 2, 3, 2);
            AddEdge(graph, 3, 3, 8);
            AddEdge(graph, 20, 15, 18);

            PrintEdgesGraph(graph);
        }

    }
}
