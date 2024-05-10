namespace CH18;

internal class Simple
{
    public static void ReverseAndPrint<T>(T[] array)
    {
        Array.Reverse(array);
        foreach (T item in array)
        {
            Console.Write($"{item.ToString()}, ");
        }
        Console.WriteLine("");
    }
}

public class MethodGenericExample
{
    private static void Main(string[] args)
    {
        //創建各類型的數組
        var intArray = new int[] { 2, 5, 7, 9, 11 };
        var stringArray = new string[] { "first", "second", "third" };
        var doubleArray = new double[] { 3.567, 7.891, 2.345 };

        Simple.ReverseAndPrint<int>(intArray);
        Simple.ReverseAndPrint(intArray);

        Simple.ReverseAndPrint<string>(stringArray);
        Simple.ReverseAndPrint(stringArray);

        Simple.ReverseAndPrint<double>(doubleArray);
        Simple.ReverseAndPrint(doubleArray);
    }
}