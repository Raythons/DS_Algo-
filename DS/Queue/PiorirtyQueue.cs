using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Queue
{
    public class PiorirtyQueue
    {
        public int AddedElements { get; set; }
        public Queue<int> q1, q2, q3 = new Queue<int>();


        public void Enqueue(int element , int piorirty)
        {
           if (piorirty == 3)
                q3.Enqueue(element);
            else if (piorirty == 2)
                 q2.Enqueue(element);
            else 
                q1.Enqueue(element);                
        }


        public int Dequeue()
        {
            if (q3.Count != 0 )
                 return q3.Dequeue();
            else if (q2.Count != 2)
                return q2.Dequeue();
            else
                 return q1.Dequeue();
        }
    }
}
