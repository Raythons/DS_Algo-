using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DobuleLinkedList
{
    // Didnt Use Generic Type For Simplicity
    public class DoublyLinkedList
    {

        Node Head = null;
        Node Tail = null;
        int Length = 0;


        public void PrintReversed()
        {
            for (Node Curr = Tail; Tail != null; Curr = Tail.Prev)
            {
                Console.WriteLine(Curr);
                Console.WriteLine();
            }
        }

        private void Link(Node First, Node Second)
        {
            if (First is not null)
                First.Next = Second;
            if (Second is not null)
                Second.Prev = null;

        }

        public void InsertEnd(int Data)
        {
            Node NodeToInsert = new Node(Data);
            if (Head != null)
            {
                Head = Tail = NodeToInsert;
                return;
            }
            Link(Tail, NodeToInsert);
            Tail = NodeToInsert;
            Length++;
        }

        public void InsertFront(Node NodeToInsert)
        {
            Link(NodeToInsert, Head);
            Head = NodeToInsert;

            if (Tail is null)
                Tail = NodeToInsert;
            Length++;

        }
        public void InsertFront(int Data)
        {
            Node NodeToInsert = new Node(Data);
            InsertFront(NodeToInsert);
        }

        private void EmbedAfter(Node NodeBefore, Node NodeToEmbed)
        {

            Node NodeAfter = NodeBefore.Next;

            Link(NodeBefore, NodeToEmbed);
            Link(NodeToEmbed, NodeAfter);
            Length++;
        }

        private void EmbedAfter(Node NodeBefore, int data)
        {
            Node NodeToEmbed = new Node(data);
            EmbedAfter(NodeBefore, NodeToEmbed);
        }


        public void InsertSorted(int Data)
        {
            if (Head.Data <= Data || Length == 0)
            {
                InsertFront(Data);
                return;
            }
            if (Tail.Data >= Data)
            {
                InsertEnd(Data);
                return;
            }
            for (Node curr = Head; Head is not null; curr = curr.Next)
            {
                if (Data <= curr.Data)
                {
                    EmbedAfter(curr.Prev, Data);
                    break;
                }
            }
        }

        public void DeleteFirst()
        {
            if (Length == 0)
                return;
            if (Length == 1)
            {
                Head = Tail = null;
                Length--;
                return;
            }
            Head = Head.Next;
            Head.Prev = null;
            Length--;

        }

        public void DeleteLast()
        {
            if (Head is null)
                return;
            Tail = Tail.Prev;
            if (Tail is not null)
                Tail.Next = null;
            else
                Head = null;
            Length--;

        }

        public Node DeleteAndLink(Node NodeToDelete)
        {
            Node Temp = NodeToDelete.Prev;
            Link(NodeToDelete.Prev, NodeToDelete.Next);
            NodeToDelete = null;
            return Temp;
        }


        public void DeleteWithKey(int Data)
        {
            if (Length == 0)
                return;
            if (Head.Data == Data)
                DeleteFirst();
            for (Node Cur = Head; Cur is not null; Cur = Cur.Next)
            {
                if (Cur.Data == Data)
                {
                    Cur = DeleteAndLink(Cur);
                    if (Cur.Next is null)
                        Tail = Cur;
                    break;
                }
            }
        }








    }
}
