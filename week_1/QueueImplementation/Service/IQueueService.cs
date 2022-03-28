

namespace QueueImplementation.Service
{
    public interface IQueueService
    {
        public bool Enqueue(int item);
        public int Dequeue();
        public int Peek();
    }
}
