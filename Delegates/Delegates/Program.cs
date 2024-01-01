//namespace Delegates
//{
//    internal class Program
//    {

//        public interface ILogger
//        {
//            void Log(string message);
//        }

//        public class SmsLogger : ILogger
//        {
//            public void Log(string message)
//            {
//                Console.WriteLine("Sms gonderildi.");
//            }
//        }

//        public class DbLogger : ILogger
//        {
//            public void Log(string message)
//            {
//                Console.WriteLine("Db de saxlanildi.");
//            }
//        }
//        public class MailLogger : ILogger
//        {
//            public void Log(string message)
//            {
//                Console.WriteLine("Mail gonderilidi"); ;
//            }
//        }
//        ///<summary>
//        ///Xml ucun kayd
//        ///</summary>
//        public class XmlLogger : ILogger
//        {
//            public void Log(string message)
//            {
//                Console.WriteLine("Xml-e kayd edildi."); ;
//            }
//        }
//        ///<summary>
//        ///Text file-i kaydi
//        ///</summary>
//        public class TextFileLogger : ILogger
//        {
//            public void Log(string message)
//            {
//                Console.WriteLine("Text file kayd edildi."); ;
//            }
//        }
//        static void Main(string[] args)
//        {

//            ILogger[] logger = new ILogger[] { new SmsLogger(),new MailLogger(), new XmlLogger(),new TextFileLogger()};
//            foreach (var item in logger)
//            {
//                item.Log("text");
//            }


//        }


//    }
//}














using System.Linq.Expressions;
using System.Runtime.ConstrainedExecution;

public delegate void MyDelegate(string message);

public class MyClass
{
    public void DisplayMessage(string message)
    {
        Console.WriteLine(message);
    }
}

public class Employee
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int Age { get; set; }
}

class Program
{
    static void Main()
    {
        //Expression<Func<int, int, bool>> expression = (x, y) => x > y;
        //Func<int, int, bool> result = expression.Compile();
        //Console.WriteLine(result(34, 2));

        //List<string> strings = new List<string>() {

        //    "codeacadmy",
        //    "text","admin","trycathc","dragrace"
        //};
        //Expression<Func<string, bool>> isContainCode = (x) => x.Contains("code");
        //Func<string, bool> func = isContainCode.Compile(); 
        //var x = strings.Where(func);
        //foreach (var item in x)
        //{
        //    Console.WriteLine(item);
        //}


        //List<string> integers = new List<string>() {

        //    "1",
        //    "2","3","4","5","sad"
        //};

        //var list = integers.Select(x=>int.Parse(x)).Where(x => x is int).ToList();
        ////integers.ConvertAll<int>(x=>int.Parse(x));
        //foreach (var item in list)
        //{
        //    Console.WriteLine(item);
        //}


        //string[] sayilar = { "1", "3", "4" };
        //List<int> ints =sayilar.Select(x => Convert.ToInt32(x)).ToList();


        //int[] nums = Array.ConvertAll(sayilar, int.Parse);

        HashSet<int> rnd = Enumerable.Range(0, 255).OrderBy(x=>Guid.NewGuid()).Take(25).OrderBy(x => x).ToHashSet<int>();
        foreach (var item in rnd)
        {
            Console.WriteLine(item);
        }


    }



}





//Warning

//Deadline Date 12.01.2024

//Dinamik Nesne Oluşturma ve CSV Verileriyle Doldurma (C#)
//Proje Açıklaması:
//Bu projede, öğrenciler bir CSV dosyasındaki verileri okuyacak ve bu verilere dayanarak dinamik bir şekilde nesneler oluşturacaklar. Her satır belirli bir kategoriye ait bilgileri içerecek ve bu bilgileri kullanarak ilgili sınıfın bir örneğini (instance) oluşturacaklar.Oluşturulan her nesne, ilgili listeye eklenecek.

//Örnek CSV Verisi:

//    Category, Beverages, Soft drinks
//    Employee, Andrew, Fuller
//    Order,10248, Vins et alcools Chevalier
//    Product, Chai,10 boxes x 20 bags,18,39,0,10,0,0,0,0
//Gereksinimler:

//CSV Okuma : C#'da System.IO namespace'ini kullanarak verilen CSV dosyasını okuyun.
//Sınıf Tanımları : Her kategori için (Category, Employee, Order, Product) bir C# sınıfı tanımlayın. Sınıfların özellikleri, CSV'deki sütun başlıklarına karşılık gelmelidir.
//Dinamik Nesne Oluşturma : CSV'deki her satırı okudukça, ilgili sınıfın bir örneğini oluşturun ve bu örnekleri ilgili listelere ekleyin.
//Listeleri Yönetme : Oluşturulan her nesneyi, kategori ismine göre ayrı listelerde saklayın. Örneğin, tüm Employee nesneleri bir List<Employee> listesinde olmalıdır. Sonuçları Yazdırma : Oluşturulan nesnelerin ve listelerin içeriğini okunaklı bir şekilde ekrana yazdırın.
//Ekstra Zorluklar: Hata Yönetimi : CSV dosyasında eksik veya hatalı veri varsa uygun hata mesajları verin. Generic Listeler : Oluşturulan nesneleri tutmak için generic listeler (List<T>) kullanın.Bu, tip güvenliği sağlar ve daha esnek bir kod yapısına izin verir. Yansıma (Reflection) : Yansıma kullanarak sınıfları ve özellikleri dinamik olarak oluşturmayı deneyin. Bu, daha ileri düzey bir konsepttir ve öğrencilerin C# dilinin derinliklerine dalmasını sağlar.

//Öğrenme Hedefleri:

//Nesne yönelimli programlamayı anlama ve uygulama
//C# dilinde dosya işlemleri ve veri yönetimi
//Dinamik olarak nesne ve sınıf oluşturma
//Hata yönetimi ve tip güvenliği
//Amaç:

//Bu proje, öğrencilere C# programlama dilinde nesne yönelimli programlama, dosya işlemleri ve daha pek çok konuda pratik yapma imkanı sunacak. Ayrıca, gerçek dünya senaryolarına benzer şekilde düşünme ve problem çözme becerilerini geliştirecekler. Öğrencilerin bu projeyi tamamladıktan sonra, C#'da nesne yönelimli programlama ve veri işleme konularında sağlam bir anlayışa sahip olmaları beklenir.