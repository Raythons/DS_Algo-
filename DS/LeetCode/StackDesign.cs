using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class MinStack
    {

        private PriorityQueue<int, int> minHeap;
        private int[] stackArr;
        private int[] lowwstArray;
        private int top;

        public MinStack()
        {
            minHeap = new PriorityQueue<int, int>();
            stackArr = new int[30001];
            lowwstArray = new int[30001];
            top = -1;
        }

        public void Push(int val)
        {
            top++;
            stackArr[top] = val;
            lowwstArray[top] = int.Min(top != 0 ? lowwstArray[top - 1] : int.MaxValue,  val);
        }

        public void Pop()
        {
            top -= 1;
        }

        public int Top()
        {
            return stackArr[top];
        }
        private int LowestTop() => lowwstArray[top];


            public int GetMin()
        {
            return lowwstArray[top];
        }

        public static void Run()
        {
            MinStack minStack = new MinStack();
            minStack.Push(-2);
            minStack.Push(0);
            minStack.Push(-3);

            Console.WriteLine(minStack.GetMin());

            minStack.Pop();
            Console.WriteLine(minStack.Top());
            Console.WriteLine(minStack.GetMin());

        }
    }

  
    /**
     * Your MinStack object will be instantiated and called as such:
     * MinStack obj = new MinStack();
     * obj.Push(val);
     * obj.Pop();
     * int param_3 = obj.Top();
     * int param_4 = obj.GetMin();
     */
}
