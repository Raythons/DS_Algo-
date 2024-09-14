using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


using Graph = System.Collections.Generic.Dictionary<int, System.Collections.Generic.List<int>>;

namespace Algorithims.Topo
{
    public static class _2050ParallelCoursesIII
    {
        //public class Course
        //{
        //    public int 

        //}

        public static int MinimumTime(int n, int[][] relations, int[] time)
        {


            Queue<int> readyQ = new Queue<int>();

            Graph graph = new Dictionary<int , System.Collections.Generic.List<int>> ();

            int[] StartedTime =  new int[n];
            if (relations.Length == 0 ) 
                return time[0];

            for (int i = 0; i < relations.Length; i++)
            {
                if (graph.TryGetValue(relations[i][0], out var list))
                    list.Add(relations[i][1]);
                else
                    graph.Add(relations[i][0], new List<int>() { relations[i][1] });

                if (!graph.ContainsKey(relations[i][1]))
                    graph.Add(relations[i][1], new List<int>());  
            }


            List<int> indegree = Enumerable.Repeat(0, n + 1).ToList();
            for (int i = 1; i <= n; i++)
            {
                foreach (int j in graph[i])
                    indegree[j] += 1;    
            }

            for (int i = 1;  i < indegree.Count ; i++)
                if (indegree[i] == 0)
                    readyQ.Enqueue(i);

            int MinimmunMonthis = 0;
            while (readyQ.Count > 0)
            {

                var levelSize = readyQ.Count;
                int MaxMonthisForLevel = int.MinValue;
                while (levelSize-- > 0)
                {
                    var cur = readyQ.Dequeue();

                    List<int> list;
                    graph.TryGetValue(cur,  out  list);


                    foreach (int j in list)
                        if (--indegree[j] == 0)
                            readyQ.Enqueue(j);
                        

                    MaxMonthisForLevel = int.Max(MaxMonthisForLevel, time[cur - 1]);

                }

                MinimmunMonthis += MaxMonthisForLevel;
            }
            return MinimmunMonthis;
        }

        public static void Run()
        {
            int n = 9;

            int[] r1 = { 2, 7 };
            int[] r2 = { 2, 6 };
            int[] r3 = { 3, 6 };
            int[] r4 = { 4, 6 };
            int[] r5 = { 7, 6 };
            int[] r6 = { 2, 1 };
            int[] r7 = { 3, 1 };
            int[] r8 = { 4, 1 };
            int[] r9 = { 6, 1 };
            int[] r10 = { 7, 1 };
            int[] r11 = { 3, 8 };
            int[] r12 = { 5, 8 };
            int[] r13 = { 7, 8 };
            int[] r14 = { 1, 9 };
            int[] r15 = { 2, 9 };
            int[] r16 = { 6, 9 };
            int[] r17 = { 7, 9 };

            // Create a 2D array to hold all arrays
            int[][] relations = new int[][]
            {
            r1, r2, r3, r4, r5,
            r6, r7, r8, r9, r10,
            r11, r12, r13, r14, r15,
            r16, r17
            };


            var time = new int[] { 9, 5, 9, 5, 8, 7, 7, 8, 4 };
            Console.WriteLine(MinimumTime(n, relations, time));

        }
    }
}
