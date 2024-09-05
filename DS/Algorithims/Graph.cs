using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph = System.Collections.Generic.List<System.Collections.Generic.List<int>>;


namespace Algorithims
{
    public static  class GraphOperations
    {

        static void AddDirectedEdge (Graph graph , int from,  int to, int coast)
        {
            graph[from][to] += coast;
        }

        static void AddUnDirectedEdge(Graph graph, int from, int to, int coast)
        {
            graph[from][to] += coast;
            graph[to][from] += coast;
        }


     }
}
