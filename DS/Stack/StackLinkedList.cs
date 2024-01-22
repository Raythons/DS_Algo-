using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Stack
{
    public class StackLinkedList
    {
        Node head = null;
        public void push(int data)
        {
            Node newNode = new Node(data);
            newNode.Next = head;
            head = newNode;
        }

        public bool isEmpty()
        {
            return head is null;
        }
        public Node Pop()
        {
            if (isEmpty()) return null;
            Node temp = head;
            int element = temp.Data;
            head = head.Next;
            temp = null;

            return temp;
        }

        public int Peek()
        {
            if (isEmpty()) throw new Exception("Peek");
            return head.Data;
        }
    }


}
