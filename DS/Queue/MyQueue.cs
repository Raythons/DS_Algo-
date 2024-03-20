using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queues
{

    public class MyQueue
    {
        public int Capacity { get; set; }
        public int Front { get; set; } = 0;
        public int Rear { get; set; } = 0;
        public int AddedElements { get; set; }

        public int[] array;

        public MyQueue(int capacit)
        {
            array = new int[Capacity];
        }


        int next(int pos)
        {
            ++pos;
            if (pos == Capacity)
                pos = 0;
            return pos;

        }
        bool IsEmpty() => AddedElements == 0;

        bool IsFull() => AddedElements == Capacity;


        public void Enqueue(int element)
        {
            if (IsFull())
                return;
            array[Rear] = element;
            Rear = next(Rear);
            AddedElements++;
        }


        public int Dequeue(int element)
        {
            if (IsEmpty())
                return 0;
            var val = array[Front];
            Front = next(Front);
            AddedElements--;
            return val;
        }


        public int prev(int index)
        {
            if (--index == -1)
                return Capacity - 1;
            return index;
        }

        public void EnqueueFront(int element)
        {
            Front = prev(Front);
            array[Front] = element;
            AddedElements++;
        }

        public int DequeueRear(int element)
        {
            Rear = prev(Rear);
            int value = array[Rear];
            --AddedElements;
            return value;
        }



    }
}
