using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStacko
{
    public class MyStack

    {
        public int size { get; set; }
        public int[] array { get; set; } = { };
        public int top { get; set; }

        public MyStack(int size)
        {
            this.size = size;
            array = new int[size];
            top = -1;
        }
        private bool isFull()
        {
            return top == size - 1;
        }

        public bool isEmpty()
        {
            return top == -1;
        }
        public void Push(int x)
        {
            if (isFull()) return;
            array[++top] = x;
        }


        private void InsertAtBottom(int x, MyStack myStack = null)
        {
            if (myStack.isEmpty())
            {
                myStack.Push(x);
                return;
            }

            int item = myStack.Pop();
            InsertAtBottom(x, this);
            myStack.Push(item);
        }

        public void InsertAtBottom(int x)
        {
            InsertAtBottom(x, this);
        }

        public void reverse()
        {
            if (isEmpty())
                return;
            // 1,2,3,4
            int element = this.Pop();
            reverse();

            InsertAtBottom(element);
        }
        public int Pop()
        {
            if (isEmpty()) throw new Exception();
            return array[top--];
        }


        public int Peek()
        {
            if (isEmpty()) throw new Exception();
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
