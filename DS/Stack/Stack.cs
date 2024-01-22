using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    public class Stack

    {
        public int size { get; set; }
        public int[] array { get; set; } = { };
        public int top {  get; set; }

        public Stack(int size ) { 
            this.size = size;
            array = new int[size];
            top =-1;
        }
        private  bool isFull()
        {
            return top == size - 1;
        }

        public bool isEmpty ()
        {
            return top == 0;
        }
        public void Push(int x)
        {
            if (isFull()) return;
            array[++top] = x;
        }

        public int Pop()
        {
            if (isEmpty()) throw new Exception();
            return array[top--];
        }

      
        public int Peek()
        {
             if(isEmpty()) throw new Exception();
             return array[top];
        }

        public void display()
        {
            for (int i = top; i >= 0; i--)
            {
                Console.WriteLine(array[i]);
            }
        }
    }
}
