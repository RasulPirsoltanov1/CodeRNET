using System.Threading.Channels;

namespace IDisposable_and_GargbageCollector
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var test = new Disposable();
            test.Print();
            test.Dispose();
            test.Print();
            test.Dispose();
            test.Print();

        }
    }

    public class Disposable : IDisposable
    {
        private bool status { get; set; }
        public void Print() => Console.WriteLine(" status : " + status);
        public void Dispose()
        {
            status = true;
        }
    }
}