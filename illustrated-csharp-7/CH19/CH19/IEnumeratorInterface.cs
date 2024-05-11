using System.Collections;

internal partial class Program
{
    private static void Main(string[] args)
    {
        int[] arr = new int[] { 1, 2, 3, 4, 5 };
        IEnumerator myEnum = arr.GetEnumerator();
        while (myEnum.MoveNext())
        {
            var item = myEnum.Current;
            Console.WriteLine($"Item value: {item}");
        }
    }
}