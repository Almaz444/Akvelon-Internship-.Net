
namespace SynchronizationTask
{

    public class Program
    {
        static void Main()
        {
            ThreadScheduler scheduler = new ThreadScheduler();
            scheduler.Execute();
        }
    }
}
