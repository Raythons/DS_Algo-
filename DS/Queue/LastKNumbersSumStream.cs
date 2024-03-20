using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    public class LastKNumbersSumStream
    {
        public int K { get; set; }
        public Queue<int> Q { get; set; }
        public Stack<int> S { get; set; }

        public LastKNumbersSumStream(int k) { 
            K = k;
        }
        // to do
        //public int Next (int num)
        //{
        //    int Total = 0;
        //    int tempK = K; 
        //    S.Push(num);
        //    while (S.Count != 0  &&  tempK > 0) {
                    
        //    }
        //}
    }
}
