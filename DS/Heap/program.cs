

using Heap;

Console.WriteLine("Asda");
Console.WriteLine("s");
Console.WriteLine("Adsas");
var minHeap = new MinHeap(20);

minHeap.Push(10);
minHeap.Push(5);
minHeap.Push(7);
minHeap.Push(2);
minHeap.Push(0);


var lessthanlist = minHeap.PrintLessThan(8, 0);
foreach (var item in lessthanlist)
{
    Console.WriteLine(item);

}

//for (int i  = 0;  i < 5 ; i++)
//{
//    Console.WriteLine($"Iteration  ${i}");
//    Console.WriteLine($"--------------------------------------------------------");
//    Console.WriteLine($"min Heap Top ${minHeap.Top()}");
//    Console.WriteLine($"min Heap Poped Element: ${minHeap.Pop()}");
//}

//var maxHeap = new MaxHeap(20);

//maxHeap.Push(0);
//maxHeap.Push(2);
//maxHeap.Push(10);
//maxHeap.Push(5);
//maxHeap.Push(7);

//Console.WriteLine("#####################Maxheap###################");
//for (int i = 0; i < 5; i++)
//{
//    Console.WriteLine($"Iteration  ${i}");
//    Console.WriteLine($"--------------------------------------------------------");
//    Console.WriteLine($"max Heap Top ${maxHeap.Top()}");
//    Console.WriteLine($"max Heap Poped Element: ${maxHeap.Pop()}");

//}

