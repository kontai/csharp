namespace ch2;

public class generic_demo2
{
    static void Main(string[] args)
    {
        int[] intArr = { 1, 2, 3, 4, 5 };

        string[] str = { "a", "b", "c", "d", "e", null };
        Zap(str);
    }

    static void Zap<T>(T[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = default;
        }

        foreach (var x1 in array)
        {
            Console.WriteLine(x1);
        }
    }
}