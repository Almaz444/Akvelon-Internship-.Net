using QueueImplementation.Service;
using System;

namespace QueueImplementation.Implementation
{
    public class Queue : IQueueService
    {
        private int[] queue;
        private int front;
        private int rear;
        private int size;

        public Queue(int size)
        {
            if (size <= 0)
            {
                Console.WriteLine("Size must be greater than zero.");
                throw new ArgumentNullException();
            }
            else 
            {
                this.size = size;
                queue = new int[size];
                front = -1;
                rear = -1;
            }  
        }
        public bool Enqueue(int item)
        {
            if (isFull())
            {
                Console.WriteLine("Queue is full. Please dequeue first in order to add item.");
                return false;
            }
            else
            {
                if (front == -1)
                {
                    front = 0;
                }  
                queue[++rear] = item;
                Console.WriteLine(item + " is added to Queue");
                return true;
            }
        }

        public int Dequeue()
        {
            int item;
            if (isEmpty())
            {
                Console.WriteLine("Queue is empty.");
                return -1;
            }
            else
            {
                item = queue[front];
                if (front == rear)
                {
                    front = -1;
                    rear = -1;
                }
                else
                {
                    front++;
                }
                Console.WriteLine(item + " was deleted.");
                return item;
            }
        }
        public int Peek()
        {
            int item;
            if (isEmpty())
            {
                Console.WriteLine("Queue is empty.");
                return -1;
            }
            else
            {
                item = queue[front];
                Console.WriteLine("First item in queue is " + item);
                return item ;
            }
        }
        private bool isFull()
        {
            if (rear == size-1 && front == 0)
            {
                return true;
            }
            return false;
        }
        private bool isEmpty()
        {
            if (front < 0)
                return true;
            else
                return false;
        }
    }
}
