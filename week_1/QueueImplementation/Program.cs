using QueueImplementation.Implementation;
using System;

namespace QueueImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue queue = new Queue(2);
            queue.Peek();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Peek();
            queue.Dequeue();
            queue.Dequeue();
            queue.Peek();
        }
    }
}
