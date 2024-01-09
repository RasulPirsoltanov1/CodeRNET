using Custom_Activator.Helpers;

namespace Custom_Activator
{
    internal class Program
    {
        //Dinamik Nesne Oluşturma ve CSV Verileriyle Doldurma(C#)
        static void Main(string[] args)
        {
            FileHelper fileHelper = new FileHelper();
            fileHelper.FileReader();
        }
    }
}