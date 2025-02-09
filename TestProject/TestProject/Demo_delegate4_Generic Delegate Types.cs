
int[] values = { 1, 2, 3 };
Util.Transform(values, Square);
foreach (var value in values)
{
    Console.WriteLine(value);
}
int Square(int x) => x * x;

//public delegate TResult Transform<T, TResult>(T arg, TResult Tresult); // Generic Delegate Type


public class Util
{
    public static void Transform<T>(T[] values, Func<T, T> t)
    {
        for (int i = 0; i < values.Length; i++)
        {
            values[i] = t(values[i]);
        }
    }
}