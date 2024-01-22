// See https://aka.ms/new-console-template for more information
using DobuleLinkedList;

Console.WriteLine("Hello, World!");


DoublyLinkedList List = new DoublyLinkedList();

List.InsertFront(4);
List.InsertFront(3);
List.InsertFront(2);
List.InsertFront(1);
// List.SwapK(2);
List.Reverse();
List.Print();
Console.WriteLine("#############");
// Console.WriteLine(List.Head.Data);
// Console.WriteLine(List.Tail.Data);
