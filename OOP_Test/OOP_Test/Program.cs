namespace OOP_Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
           Animal.Name = "Test";
            Console.WriteLine(Animal.Name);
        }
    }

    public  class Animal
    {
        public static string Name { get; set; }
        public static void Sound()
        {
            Console.WriteLine("Ia am animl");
        }
    }
    //public class Cat:Animal{ 
    //public void CatSong()
    //    {
    //        Console.WriteLine("I AM CAT MF");
    //    }
    //}
}
