

using Queues;
using System;

internal class Program
{
    private static void Main(string[] args)
    {
        QueueOnStacks queueOnStacks = new QueueOnStacks(10);
        queueOnStacks.Enqueue(1);
        queueOnStacks.Enqueue(2);
        queueOnStacks.Enqueue(3);
        queueOnStacks.Enqueue(4);
        queueOnStacks.Enqueue(5);


        queueOnStacks.Dqeueue();
        queueOnStacks.Dqeueue();
        queueOnStacks.Dqeueue();
        queueOnStacks.Enqueue(6);
        queueOnStacks.Dqeueue();

        queueOnStacks.Display();
        Console.ReadKey();
    }
}