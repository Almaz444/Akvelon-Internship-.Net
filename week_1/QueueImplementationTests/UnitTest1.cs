using QueueImplementation.Implementation;
using Xunit;

namespace QueueImplementationTests
{
    public class UnitTest1
    {
        [Fact]
        public void Enqueue_AddingElementWhenQueueFull_ReturnFalse()
        {
            // arrange
            Queue queue = new Queue(2);
            queue.Enqueue(1);
            queue.Enqueue(2);
            bool result = false;

            // act
            bool action = queue.Enqueue(3);

            // assert
            Assert.Equal(result, action);
        }

        [Fact]
        public void Enqueue_AddingElementWhenQueueIsNotFull_ReturnTrue()
        {
            // arrange
            Queue queue = new Queue(3);
            queue.Enqueue(1);
            queue.Enqueue(2);
            bool result = true;

            // act
            bool action = queue.Enqueue(3);

            // assert
            Assert.Equal(result, action);
        }

        [Fact]
        public void Peek_PeekElementFromQueue_ReturnFirstElement()
        {
            // arrange
            Queue queue = new Queue(2);
            queue.Enqueue(1);
            queue.Enqueue(2);
            int result = 1;

            // act
            var action = queue.Dequeue();

            // assert
            Assert.Equal(result, action);
        }


        [Fact]
        public void Dequeue_WhenDequeue_ReturnFirstElement()
        {
            // arrange
            Queue queue = new Queue(2);
            queue.Enqueue(1);
            queue.Enqueue(2);
            int result = 1;

            // act
            var action = queue.Dequeue();

            // assert
            Assert.Equal(result, action);
        }

        
        [Fact]
        public void Peek_WhenQueueIsEmpty_ReturnNegative1()
        {
            // arrange
            Queue queue = new Queue(2);
            int result = -1;

            // act
            var action = queue.Peek();

            // assert
            Assert.Equal(result, action);
        }
        [Fact]
        public void Dequeue_WhenTryDequeueEmptyQueue_ReturnNegative1()
        {
            // arrange
            Queue queue = new Queue(2);
            int result = -1;

            // act
            var action = queue.Dequeue();

            // assert
            Assert.Equal(result, action);
        }

    }
}
