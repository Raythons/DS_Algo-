using System;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a SinglyLinkedList of integers
            SinglyLinkedList<int> intList = new SinglyLinkedList<int>();
            SinglyLinkedList<int> intList2 = new SinglyLinkedList<int>();




            intList2.Inser_End(1);
            intList2.Inser_End(1);
            intList2.Inser_End(1);
            intList2.Inser_End(2);
            intList2.Inser_End(3);
            intList2.Inser_End(4);


            intList.Insert_Alternate(intList2);

            intList.Print();
            // StringBuilder y = new StringBuilder();
            // y.Append("hello");
            // Foo(y);
            // Console.WriteLine(y == null);
            // Console.WriteLine(y);
            // //////////////////////////////////////////////////////////////////
            // void Foo1(StringBuilder x)
            // {
            //     x.Append(" world");
            // }

            // StringBuilder Y = new StringBuilder();
            // Y.Append("hello");
            // Foo1(Y);
            // Console.WriteLine(Y);
            // Insert elements at the beginning


            //intList.SwapHeadTail();


            ////intList.Insert_Sorted(15, SinglyLinkedList<int>.enSortType.Descending);
            //Console.WriteLine($" Head; ${intList.Head?.Data } Tail ${intList.Tail?.Data}\n\n");
            //intList.Print();

            // Insert elements at the end
            //intList.Inser_End(4);
            //intList.Inser_End(5);
            //intList.Inser_End(6);

            //// Print the list
            //Console.WriteLine("Linked List:");
            //intList.Print();

            //// Print in reverse (using deprecated method)
            //Console.WriteLine("\nPrinting in Reverse (Deprecated Method):");
            //intList.PrintReverse();

            //// Search for an element
            //int elementToSearch = 4;
            //int index = intList.Search(elementToSearch);
            //Console.WriteLine($"\nIndex of {elementToSearch}: {index}");

            //// Get the node at position 3
            //var nodeAtPosition3 = intList.Get_Nth(3);
            //Console.WriteLine($"\nNode at Position 3: {nodeAtPosition3?.Data}");

            //// Delete the first node
            //intList.DeleteFirst();
            //Console.WriteLine("\nLinked List after deleting first node:");
            //intList.Print();

            //// Delete the last node
            //intList.DeleteLast();
            //Console.WriteLine("\nLinked List after deleting last node:");
            //intList.Print();

            //// Search for an element after improvements
            //int indexImproved = intList.Search_Improve_V2(2);
            //Console.WriteLine($"\nIndex of 2 (Improved Search): {indexImproved}");

            //// Verify the integrity of the list
            //bool integrity = intList.Verify_Data_Entgirty();
            //Console.WriteLine($"\nList Integrity: {integrity}");

            //// Delete the node at position 2
            //Console.WriteLine("Before Delete");
            //intList.Print();

            //intList.Delete_Nth(2);
            //Console.WriteLine("\nLinked List after deleting node at position 2:");
            //intList.Print();

            Console.ReadKey();
        }
    }
}
