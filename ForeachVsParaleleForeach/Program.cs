namespace ForeachVsParaleleForeach
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Animal cat = new Cat();
        }
    }
    abstract class Animal
    {
        public Animal()
        {

        }
        public string Name { get; }
        public string Description()
        {
            return "asd";
        }
    }

    class Cat : Animal
    {
        public Cat():base()
        {
            
        }
        public int AGE { get; set; }
    }
}