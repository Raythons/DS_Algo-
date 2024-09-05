using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ImageGraph = System.Collections.Generic.List<System.Collections.Generic.List<int>>;

namespace Algorithims
{
    public static class ImageAsGraph
    {
        public static List<int> CreateMatrix(int C, int R)
        {
            var matrix = new List<int>();
            for (int i = 0; i < C * R ; i++)
            {
                matrix.Add(i);
            }
            return matrix;
        }

        public static ImageGraph CreateGraphOfImageMatrix(List<int> matrix)
        {
            var graph = new ImageGraph() { 
                new List<int>() ,
                new List<int>(),
                new List<int>(),
                new List<int>(),
                new List<int>(),
                new List<int>(),
                new List<int>(),
                new List<int>(),
                new List<int>(),
                new List<int>(),
                new List<int>(),
                new List<int>() } ;

            for (int i = 0; i < matrix.Count; i++) { 
                if(! (i - 1 < 0))
                    graph[i].Add(matrix[i - 1]);
                if (!(i - 4 < 0))
                    graph[i].Add(matrix[i - 4]);

                if (!(i + 1 > matrix.Count - 1) && i + 1 % 4 == 0)
                    graph[i].Add(matrix[i + 1]);
                if (!(i + 4 > matrix.Count - 1))
                    graph[i].Add(matrix[i + 4]);
            }
            return graph;
        }
        public static void PrintImageGraph(ImageGraph graph)
        {

            for (int i = 0; i < graph.Count; i++)
            {
                Console.WriteLine($"val ${i} has edges With : ");
                for (int j = 0; j < graph[i].Count; j++)
                {
                    Console.WriteLine($" ${graph[i][j]} ");
                }
            }
        }
        public static void CreateAndAddAndPrint()
        {
            var matrix = CreateMatrix(3, 4);
            var graph = CreateGraphOfImageMatrix(matrix);
            PrintImageGraph(graph);
        }


    }
}
