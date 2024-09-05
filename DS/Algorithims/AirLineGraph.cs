using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



using FlightsGraph = System.Collections.Generic.
                                    SortedDictionary<string, System.Collections.Generic.List<Algorithims.Flight>>;

namespace Algorithims
{

    public static class AirLineGraph
    {
        public static void Add(FlightsGraph graph, string from, string to, int cost)
        { // Almost o(1) 
            if (graph.TryGetValue(from, out List<Flight> flights))
                flights.Add(new Flight(from, to, cost));
            else   
                graph.Add(from, new List<Flight>() { new Flight(from, to, cost) });
        }

        public static void PrintHashSetGraph(FlightsGraph graph)
        {
            foreach (var values in graph)
            {
                Console.WriteLine($"Flights From ${values.Key}");

                values.Value.Sort();
                for (var i = 0; i < values.Value.Count; i++) { 
                    Console.WriteLine($"                     To ${values.Value[i].To} with cost ${values.Value[i].Weight}");
                }
            }
        }
        public static void CreateAndAddAndPrint()
        {
            FlightsGraph graph = new FlightsGraph();
            Add(graph, "Califorania", "Texsas", 30);
            Add(graph, "Califorania", "Texsas", 10);

            Add(graph, "Florida", "Califorania", 70);
            Add(graph, "Califorania", "Florida", 75);

            Add(graph, "NewYork", "Califorania", 35);
            Add(graph, "Pennsylvania", "Florida", 18);
            Add(graph, "Pennsylvania", "Florida", 28);
            Add(graph, "Califorania", "Texsas", 35);
            Add(graph, "Califorania", "Pennsylvania", 37);

            PrintHashSetGraph(graph);
        }

    }

}
