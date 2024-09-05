using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Graph = System.Collections.Generic.List<System.Collections.Generic.List<int>>;

namespace Algorithims.Dfs
{
    public static  class _1202SmallestStringWithSwap
    {
        static void AddUnDirectedEdge(Graph graph, int from, int to)
        {
            graph[from].Add(to);
            graph[to].Add(from);
        }

        static void Dfs (Graph graph , int node , List<int> visited, List<int> connectedComponent)
        {
            visited[node] = 1;
            connectedComponent.Add(node);

            foreach (int neighbor in graph[node])
            {
                if (visited[neighbor] == 0)
                    Dfs (graph, neighbor, visited, connectedComponent);
            }
        }
        static string SortString(string input)
        {
            char[] characters = input.ToArray();
            Array.Sort(characters);
            return new string(characters);
        }
        public  static string SmallestStringWithSwaps(string s, IList<IList<int>> pairs)
        {
            int nodes = s.Length;

            Graph graph = Enumerable.Range(0, nodes)
                                  .Select(i => new List<int>(nodes))
                                  .ToList();

            for (int i = 0; i < pairs.Count; i++) 
                AddUnDirectedEdge(graph, pairs[i][0], pairs[i][1]);

        
            List<int> visited = Enumerable.Range(0, nodes)
                                  .Select(i => 0)
                                  .ToList();

            StringBuilder strBuilder = new StringBuilder(s);
            for (int i = 0; i < nodes; i++)
            {
                if (visited[i] == 0)
                {
                    List<int> connectedComponent = new List<int>();
                    Dfs(graph, i, visited, connectedComponent);


                    string connectedComponentLetters = "";

                    foreach (int node in connectedComponent)
                        connectedComponentLetters += s[node];

                    connectedComponentLetters = SortString(connectedComponentLetters);
                    //Array.Sort(connectedComponentLetters.ToArray());
                    connectedComponent.Sort();

                    for (int j = 0; j < connectedComponent.Count; j++)
                        strBuilder[connectedComponent[j]] = connectedComponentLetters[j];
                 }
            }

            return strBuilder.ToString(); ;
        }
    }
}
