using System;
namespace ConsoleApplication
{

    public struct Address
    {

        // data member of Address structure
        public string City;
        public string State;
    }


    // Another structure 
    struct Person
    {

        // data member of Person structure
        public string Name;
        public int Age;

        // by creating A1 of type Address
        public Address A1;
    }

    class Geeks
    {

        // Main method
        static void Main1(string[] args)
        {

            // Declare p1 of type Person
            Person p1;

            // Assigning values to the variables
            p1.Name = "Raman";
            p1.Age = 12;

            // Assigning values to the nested
            // structure data members
            p1.A1.City = "ABC_City";
            p1.A1.State = "XYZ_State";
            Person p2;

            // Assigning values to the variables
            p2.Name = "Raman";
            p2.Age = 12;

            // Assigning values to the nested
            // structure data members
            p2.A1.City = "ABC_City";
            p2.A1.State = "XYZ_State";

            Console.WriteLine(p1.Equals(p2));

        }

        public static void Main()
        {
            List<(string, int, int)> values = new List<(string, int, int)>();
            values.Add(("sad", 1, 3));
            values.Add(("bud", 3, 5));
            values.Add(("qod", 2, 6));
            values.Add(("vad", 5, 7));
            values.ForEach((x) =>
            {
                Console.WriteLine(x.Item1 + " : " + x.Item2 + " : " + x.Item3);
            });
        }
    }
}