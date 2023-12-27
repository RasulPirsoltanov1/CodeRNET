using System.Reflection;

namespace Sealed
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var Magazine = new Magazine();
            var Novel = new Novel();
            var Bio = new Bio();
            var Dictionary = new Dictionary();
            var Encyclopedia = new Encyclopedia();
            object[] books = {Magazine, Novel, Bio, Dictionary,Encyclopedia};
            foreach (var book in books)
            {
                MethodInfo[] methodInfos = book.GetType().GetMethods();
                foreach (var methodInfo in methodInfos)
                {
                    if (methodInfo.Name.Contains("Log"))
                    {
                        methodInfo.Invoke(book,null);
                    }
                }
            }
            var types =Assembly.GetExecutingAssembly().GetTypes();
            var derivedTypes =types.Where(x=>x.IsSubclassOf(typeof(Book)));
            foreach (var item in derivedTypes)
            {
                //Console.WriteLine(derivedTypes.GetType().getmet);
            }
        }
    }
}