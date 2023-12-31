using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp1
{
    public partial class SinglyLinkedList<T> : IDisposable where T : IComparable<T>
    {

        public Node<T>? Head { get; set; } = null;
        public Node<T>? Tail { get; set; } = null;
        public int length { get; set; } = 0;


        private void Print_Reverse_Recursivly(Node<T> curr)
        {
            if (curr == null) return; // Base case: Reach the end of the list
            Print_Reverse_Recursivly(curr.Next); // Recursively traverse to the end of the list
            Console.WriteLine(curr.Data); // Print the data in reverse order
        }
        public void Print()
        {
            Node<T> temp_head = Head;
            while (temp_head is not null)
            {
                Console.WriteLine(temp_head.Data);
                temp_head = temp_head.Next;
            }
        }

        // Recusion way Dont Use If Its  Big 
        [Obsolete("Print_Reversed may cause performance issues" +
                 " for large lists .")]
        public void PrintReverse()
        {
            Print_Reverse_Recursivly(Head);
        }

        public void Insert_Front(T Data)
        {
            if (Data is null) return;
            Node<T> NodeToInsert = new(Data);

            NodeToInsert.Next = Head;
            ++length;
            Head = NodeToInsert;

            if (length == 1) Tail = Head;
        }
        public void Insert_Front(Node<T> NodeToEmbed)
        {
            if (NodeToEmbed is null) return;


            NodeToEmbed.Next = Head;
            ++length;
            Head = NodeToEmbed;

            if (length == 1) Tail = Head;
        }


        /// <summary>
        /// Insert The Data At The End  - O(1) Space & Time
        /// </summary>
        /// <param name="data"></param>
        public void Inser_End(T data)
        {
            Node<T> NodeToAdd = new Node<T>(data);
            if (Head is null)
                Head = Tail = NodeToAdd;
            else
                Tail.Next = NodeToAdd; Tail = NodeToAdd;

            ++length;
        }
        // Fun Fact i decided To Make it Zero Indexed :3

        public int Search(T Data)
        {
            int idx = 0;
            for (Node<T> curr = Head; curr is not null; curr = curr?.Next)
            {
                if (curr.Data.Equals(Data))
                    return idx;
                ++idx;
            }


            return -1;
        }
        // Used Tuple Insted of Swap Function
        ////private void Swap(ref T Data1,ref T Data2)
        //{
        //    (Data2, Data1) = (Data1, Data2);
        //}

        [Obsolete("It May Return Null;")]
        public Node<T>? Get_Nth(int n)
        {
            if (n > length) return null;

            int Counter = 0;
            for (Node<T> cur = Head; cur is not null; cur = cur.Next)
                if (++Counter == n)
                    return cur;

            return null;
        }


        [Obsolete("Its Old Version OF  Improved Search")]
        public int Search_Improve(T Data)
        {
            int idx = 0;
            Node<T>? Prev_Node = null;

            for (Node<T>? Curr_Node = Head; Curr_Node is not null; idx++)
            {
                if (Curr_Node.Data.Equals(Data))
                {
                    if (Prev_Node is null)
                        return idx;
                    // better way in c#
                    (Prev_Node.Data, Curr_Node.Data) = (Curr_Node.Data, Prev_Node.Data);
                    // Swap Throw erro becuase its a property 
                    //Swap(ref  Prev_Node.Data, ref Curr_Node.Data);
                    return idx;
                }
                Prev_Node = Curr_Node;
            }
            return -1;
        }

        public int Search_Improve_V2(T Data)
        {
            int idx = 0;

            for (Node<T>? Curr_Node = Head, prv = null;
                Curr_Node is not null; prv = Curr_Node,
                Curr_Node = Curr_Node.Next)
            {
                if (Curr_Node.Data.Equals(Data))
                {
                    if (prv is null)
                        return idx;
                    // better way in c#
                    (prv.Data, Curr_Node.Data) = (Curr_Node.Data, prv.Data);
                    // Swap Throw erro becuase its a property 
                    //Swap(ref  Prev_Node.Data, ref Curr_Node.Data);
                    return idx;
                }
                ++idx;
            }
            return -1;
        }

        public bool Verify_Data_Entgirty()
        {
            bool Is_Passed = true;
            if (length == 0)
            {
                Is_Passed = Head == null & Tail == null;
                return Is_Passed;
            }

            if (length == 1)
                Is_Passed = Head == Tail;
            else
            {
                Is_Passed = Head != Tail;
                if (length == 2) {
                    Is_Passed = Head.Next == Tail;
                }
            }
            return Is_Passed;
        }

        public void DeleteFirst()
        {
            if (Head is not null)
            {
                Node<T>? cur = Head.Next;
                Head.Dispose();
                Head = cur;
                --length;
            }
            if (length < 1)
                Tail = Head;
        }

        public void DeleteLast()
        {
            if (length <= 1)
            {
                DeleteFirst();
                return;
            }

            Node<T>? Prev = Get_Nth(length - 1);

            //Prev!.Next = null;
            Tail?.Dispose();
            Tail = Prev;

            if (Tail is not null)
                Tail.Next = null;

            --length;
        }

        public void Delete_Nth(int idx)
        {
            if (idx < 1 || idx > length)
            {
                // Basic way to validate insted of exeption
                Console.WriteLine("Erorr : Invalid Length");
                return;
            }
            if (idx == 1)
            {
                DeleteFirst();
                return;
            }

            Node<T>? Before_Nth = Get_Nth(idx - 1);

            Node<T>? Nth = Before_Nth?.Next;
            bool is_Tail = Nth == Tail;

            Before_Nth!.Next = Nth?.Next;

            if (is_Tail) Tail = Before_Nth;

            --length;
            Nth?.Dispose();

        }


        public bool DeleteNextNode(ref Node<T> node)
        {
            Node<T> NodeToDelete = node.Next;

            bool IsTail = NodeToDelete == Tail;

            node.Next = node.Next.Next;
            NodeToDelete?.Dispose();

            if (IsTail)
                Tail = node;

            return true;
        }
        public bool DeleteByKey(T Data)
        {
            if (Data == null || length == 0) return false;

            if (Data.Equals(Head.Data))
            {
                DeleteFirst();
                return true;
            }

            // This Line Can BeUseful If Your LL have Unique values
            //if (Data.Equals(Tail.Data)) DeleteLast(); return ;
            for (Node<T>? curr = Head, Prev = null; curr is not null; curr = curr.Next)
            {
                if (Data.Equals(curr.Data))
                {
                    DeleteNextNode(ref Prev);
                    return true;
                }

            }
            return false;
        }

        public void SwapPairs()
        {
            if (length == 1) return;
            for (Node<T> curr = Head; curr is not null; curr = curr.Next)
            {
                if (curr.Next is not null)
                {
                    (curr.Data, curr.Next.Data) = (curr.Next.Data, curr.Data);
                    curr = curr.Next;
                }
            }
        }

        public void Reverse()
        {
            if (length == 0 || length == 1) return;


            Node<T> prev = null;
            Node<T>? Temp = Head;

            Head = Tail; Tail = Temp;

            for (Node<T> curr = Tail; curr is not null;)
            {
                // 1 2 3
                Temp = curr.Next; // 2

                curr.Next = prev;//  1 => null
                prev = curr;
                curr = Temp;
            }

        }

        public bool IsSameLL(ref SinglyLinkedList<T> OtherList)
        {
            if (length != OtherList.length)
                return false;

            Node<T>? Other_Head = OtherList.Head;
            // Here Can Make Both Moves  in The For Statment
            for (Node<T>? curr = Head; curr is not null; curr = curr.Next)
            {
                if (!curr.Data.Equals(Other_Head.Data))
                    return false;
                Other_Head = Other_Head.Next;


            }
            return true;
        }
        public void DeleteEvenIndexes()
        {
            // Here  u can use length To Make It Easier but ill work Around it
            if (Head.Next is null) return;

            for (Node<T> curr = Head.Next, prev = Head; curr is not null;)
            {
                // Idea Here Is I Want  Prev always To
                // Be In Odd Position And The curr In Even  So we can always delete curr
                DeleteNextNode(ref prev);

                if (prev.Next is null) break;

                curr = prev.Next.Next;
                prev = prev.Next;

            }

        }


        private void EmbedAfter(Node<T> EmbedAfter, Node<T> NodeToEmbed)
        {
            if (EmbedAfter.Next is null)
            {
                EmbedAfter.Next = NodeToEmbed;
                Tail = EmbedAfter;

            }
            NodeToEmbed.Next = EmbedAfter.Next;
            EmbedAfter.Next = NodeToEmbed;
            ++length;
        }

        private void EmbedBefore(Node<T> Prev, Node<T> NodeToEmbed)
        {
            //Here Iam Sure THHAT THE Head will not  be null
            if (Prev is null)
            {

                Insert_Front(NodeToEmbed);
                return;
            }

            NodeToEmbed.Next = Prev.Next;

            Prev.Next = NodeToEmbed;
            ++length;

        }

        // Here It Wont Be Sorted if a single item wasnt  Sorted
        // It Can Be More ReadAble If You Removed SortType
        public void Insert_Sorted(T Data, enSortType sortType = enSortType.Asencding)
        {

            if (Head is null)
            {
                Insert_Front(Data);
                return;
            }

            Node<T> NodeToInsert = new Node<T>(Data);
            switch (sortType)
            {
                case SinglyLinkedList<T>.enSortType.Asencding:
                    for (Node<T> curr = Head; curr is not null; curr = curr.Next)
                    {
                        if (curr.Data.CompareTo(NodeToInsert.Data) < 0)
                        {
                            EmbedAfter(curr, NodeToInsert);
                            break;
                        }
                    }
                    break;
                case SinglyLinkedList<T>.enSortType.Descending:
                    Node<T> Prev = null;
                    for (Node<T> curr = Head; curr is not null; curr = curr.Next)
                    {

                        if (curr.Data.CompareTo(NodeToInsert.Data) > 0)
                        {
                            EmbedBefore(Prev, NodeToInsert);
                            break;
                        }
                        Prev = curr;

                    }
                    break;
                default:
                    break;
            }

        }

        private void Swap( Node<T> Node1, Node<T> Node2)
        {
            Node<T> temp = Node1;
            Node1 = Node2;
            Node2 = temp;
        }
        public void SwapHeadTail()
        {

            if (length == 0 || length == 1) return;

            if (length == 2)
            {
                (Head, Tail) = (Tail, Head);
                Head.Next = Tail;
                Tail.Next = null;

            }

            Node<T>? PrevTail = Get_Nth(length - 1);

            Tail.Next = Head.Next;
            PrevTail.Next = Head;
            Head.Next = null;

            Swap( Head,  Tail);
            (Head, Tail) = (Tail, Head);
        }
        
       

        // Generate Key ()

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}

