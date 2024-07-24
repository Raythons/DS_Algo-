using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    public class MaxHeap
    {
        private MinHeap MinHeap;
        public MaxHeap(int capacity) {
            MinHeap = new(capacity);
        }   
        
        public void Push (int key)
        {
            MinHeap.Push(key * -1);
        }

        public int Top( )
        {
            return MinHeap.Top() * -1;
        }

        public int  Pop() {
           return  MinHeap.Pop();
        }
    }
}
