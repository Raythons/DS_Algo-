using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithims
{
    public class Flight : IComparable
    {
        public string From { get; set; }
        public string To { get; set; }
        public int Weight { get; set; }
        public Flight(string from, string to, int weight)
        {
            From = from;
            To = to;
            Weight = weight;
        }

        public int CompareTo(object? obj)
        {
            if (obj == null)
                return 1;
            if (obj == this) return 0;

            if (obj.GetType() == typeof(Flight)) ;
            Flight flight = (Flight)obj;

            if (flight.From.CompareTo(this.From) == 1)
                return -1;
            else if (flight.From.CompareTo(this.From) == -1)
                return 1;

            if (flight.To.CompareTo(this.To) == 1)
                return -1;
            else if (flight.To.CompareTo(this.To) == -1)
                return 1;

            if (flight.Weight > this.Weight)
                return -1;
            if (flight.Weight < this.Weight)
                return 1;

            return 0;
        }
    }
}
