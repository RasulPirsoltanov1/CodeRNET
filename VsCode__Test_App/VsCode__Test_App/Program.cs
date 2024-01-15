// See https://aka.ms/new-console-template for more information


using System.Text.Json;
using System.Text.Json.Serialization;

class program
{
    public static void Main()
    {
        var cvb = JsonSerializer.Serialize(new test
        {
            age = 21,
            name = "Rasul"
        });
       
        for (int i = 0; i < 10; i++)
        {
            Thread.Sleep(100);
            Console.WriteLine("Hello, World!");
            Console.Beep(1000,100);
        }
        Console.WriteLine("cvb : " + cvb);
    }
}
class test
{
    public int age { get; set; }
    public string name { get; set; }
}