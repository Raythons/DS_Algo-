namespace Algorithims
{
    public class Edge  : IComparable{ 
       public int From { get; set; } 
       public int To {get ; set ; } 
       public int Weight { get ; set ; } 
       public Edge (int from , int to , int weight)
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

            if (obj.GetType() == typeof(Edge)) ;
            Edge edge = (Edge)obj;

            if(edge.Weight > this.Weight)
                return -1;
            if (edge.Weight < this.Weight)
                return 1;
            return 0;

        }
    }
}
