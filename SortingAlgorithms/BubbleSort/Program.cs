namespace BubbleSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BubbleSort<int>(new int[] { 1, 2, 234, 324, 123, 445, 64, 2, 3, 54, 5 });
            Console.WriteLine();
            BubbleSort<string>(new string[] { "as", "safg", "Fsd", "sadasd", "zzz" });
        }

        //Time Complexity O(1)
        //Space Complexity O(n^2)

        static void BubbleSort<T>(T[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    T x;
                    if (Comparer<T>.Default.Compare(arr[j], arr[j + 1]) > 0)
                    {
                        x = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = x;
                    }
                }

            }
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }
    }
}