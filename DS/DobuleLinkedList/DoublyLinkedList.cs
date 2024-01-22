using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DobuleLinkedList
{
    // Didnt Use Generic Type For Simplicity
    public class DoublyLinkedList
    {

        public Node Head = null;
        public Node Tail = null;
        public int Length = 0;


        public void PrintReversed()
        {
            for (Node Curr = Tail; Curr is not null; Curr = Curr.Prev)
            {
                Console.WriteLine(Curr.Data);
            }
        }

        private void Link(Node First, Node Second)
        {
            if (First is not null)
                First.Next = Second;
            if (Second is not null)
                Second.Prev = First;

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


        public void Print()
        {
            Node Curr = Head;
            while (Curr != null)
            {
                Console.WriteLine(Curr.Data);

                Curr = Curr.Next;
            }

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
            Node Ret = NodeToDelete.Prev;
            Link(NodeToDelete.Prev, NodeToDelete.Next);
            NodeToDelete = null;
            return Ret;
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


        public void DeleteAllWithKey(int data)
        {
            if (Length == 0)
                return;
            // Dummy Node To Make Life Easier
            InsertFront(-123);
            for (Node Cur = Head; Cur is not null;)
            {
                if (Cur.Data == data)
                {
                    Cur = DeleteAndLink(Cur);
                    if (Cur.Next is null)
                        Tail = Cur;
                }
            }
            DeleteFirst();
        }

        // public void DeleteEvenPositions()
        // {
        //     if (Length <= 1)
        //         return;
        //     for (Node CurrEven = Head.Next; CurrEven is not null; CurrEven = CurrEven.Next.Next)
        //     {
        //         CurrEven = DeleteAndLink(CurrEven);
        //         Length--;
        //         if (CurrEven.Next is null)
        //         {
        //             Tail = CurrEven;
        //             break;
        //         }
        //     }
        // }

        public void DeleteEvenPositions()
        {
            // More Elegant
            if (Length <= 1)
                return;
            for (Node curr = Head; curr is not null && curr.Next is not null; curr = curr.Next)
            {
                DeleteAndLink(curr.Next);
                Length--;
                if (curr.Next is null)
                    Tail = curr;
            }
        }

        public void DeleteOddPositions()
        {
            if (Length == 0)
                return;
            InsertFront(-555);
            DeleteEvenPositions();
            DeleteFirst();
        }

        public bool IsPalindrome()
        {
            if (Length <= 1)
                return true;
            int len = Length / 2;

            Node First = Head;
            Node Last = Tail;
            while (Length-- != 0)
            {
                if (First.Data != Last.Data)
                    return false;
                First = First.Next;
                Last = Last.Prev;
            }
            return true;
        }

        public Node FindMiddle()
        {
            if (Length == 0)
                return null;
            if (Length == 1)
                return Head;
            for (Node LeftMid = Head, RightMid = Tail; LeftMid != RightMid && LeftMid.Next != RightMid;)
            {
                LeftMid = LeftMid.Next;
                RightMid = RightMid.Prev;
            }
            return null;
        }

        public Node FindMiddleFastSlowPointers()
        {
            Node fast = Head;
            Node slow = Head;
            while (fast != null && fast.Next != null)
            {
                fast = fast.Next.Next;
                slow = slow.Next;
            }
            return slow;
        }


        private void Swap(ref Node node1, ref Node node2)
        {
            Node Temp = node1;
            node2 = node1;
            node1 = Temp;
        }


        public Node? Get_Nth(int n)
        {
            if (n > Length) return null;

            int Counter = 0;
            for (Node cur = Head; cur is not null; cur = cur.Next)
                if (++Counter == n)
                    return cur;

            return null;
        }

        //  Tricky
        public void SwapK(int k)
        {
            if (k > Length) return;

            int kth_back = Length - k;

            if (k == kth_back) return;

            // This Move To Always Make Sure That is k will be called the first element()
            if (k > kth_back)
                (k, kth_back) = (kth_back, k);

            // Here We Can Optimize it  by either Make New Function To get  kth From Back 
            //Or Make A function That Return the Nth And a list of 2 Nodes Then Assign them
            Node First = Get_Nth(k);
            Node Last = Get_Nth(kth_back);

            Node FirstNext = First.Next;
            Node FirstPrev = First.Prev;

            Node LastNext = Last.Next;
            Node LastPrev = First.Prev;

            if (k + 1 == kth_back)
            {
                Link(FirstPrev, Last);
                Link(Last, First);
                Link(First, FirstNext);
            }
            else
            {
                Link(FirstPrev, Last);
                Link(Last, FirstNext);

                Link(LastPrev, First);
                Link(First, LastNext);
            }

            if (k == 1)
                (Head, Tail) = (Tail, Head);
        }



        // public void Reverse()
        // {
        //     if (Length == 1)
        //         return;

        //     Node NewTail = Tail;
        //     Node Curr = Tail.Prev;
        //     while (Curr != null)
        //     {
        //         Node Temp = Curr.Prev;
        //         Link(NewTail, Curr);
        //         NewTail = Curr;
        //         Curr = Temp;
        //     }
        //     (Head, Tail) = (Tail, Head);
        //     Head.Prev = Tail.Next = null;
        // }

        public void Reverse()
        {
            if (Length == 1)
                return;

            Node NewHead = Head;
            Node Curr = Head.Next;
            while (Curr != null)
            {
                Node Temp = Curr.Next;
                Link(Curr, NewHead);
                NewHead = Curr;
                Curr = Temp;
            }
            (Head, Tail) = (Tail, Head);
            // Head.Prev = Tail.Next = null;
        }
    }
}
