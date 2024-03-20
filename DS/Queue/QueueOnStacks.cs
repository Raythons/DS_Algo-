using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queues
{
    public class QueueOnStacks
    {
        public int AddedElements { get; set; }
        public int Capacity { get; set; }
        public Stack<int> s1 = new Stack<int>();
        public Stack<int> s2 = new Stack<int>();


        public QueueOnStacks(int capacity)
        {
            Capacity = capacity;
        }

        public void Enqueue(int element)
        {
            s1.Push(element);
        }

        public void Move(Stack<int> s1, Stack<int> s2)
        {
            while (s1.Count != 0)
                s2.Push(s1.Pop());
        }
        public int Dqeueue()
        {
            Move(s1, s2);

            if (s2.Count == 0)
                 Move(s1, s2);

            var val = s2.Pop();
            --AddedElements;
            return val;
        }

        public void Display()
        {
            for (int i = 0; s1.Count != 0; i++)
            {
                Console.WriteLine(s1.Pop().ToString());
            }
        }


        // Dequeue in o(1)

        //public void Enqueue(int element)
        //{
        //    Move(s1, s2);
        //    s1.Push(element);
        //    Move(s2, s1);

        //}
        //public void Move(Stack<int> s1, Stack<int> s2)
        //{
        //    while (s1.Count != 0)
        //        s2.Push(s1.Pop());
        //}
        //public int Dqeueue()
        //{
        //    return s1.Pop();
        //}

        //public void Display()
        //{
        //    for (int i = 0; s2.Count != 0; i++)
        //    {
        //        Console.WriteLine(s2.Pop().ToString());
        //    }
        //}
    }
}
