namespace IDispposable_Intro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                var test = new IntDest(i);
            }
            GC.Collect();
            Console.ReadLine();

        }
    }
    public class IntDest
    {
        int num { get; set; }

        public IntDest(int numer)
        {
            num = numer;
            Console.WriteLine($"connstructor {num}");
        }
        ~IntDest()
        {
            Console.WriteLine($"Ok {num}");
        }
    }

}