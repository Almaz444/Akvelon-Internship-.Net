

namespace LinqTask.Models
{
    public class Consumer
    {
        public int ConsumerCode { get; private set; }
        public int BirthYear { get; private set; }
        public string Address { get; private set; }

        public Consumer(int consumerCode, int birthYear, string address)
        {
            ConsumerCode = consumerCode;
            BirthYear = birthYear;
            Address = address;
        }
    }
}
