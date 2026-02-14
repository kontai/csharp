namespace ch2;

public class generic_demo
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello generic!");
        Type a1 = typeof(A<>);
        Type a2 = typeof(A<,>);

        Console.WriteLine(a1.Name);  // 輸出: A`1
        Console.WriteLine(a2.Name);  // 輸出: A`2

        Console.WriteLine(a1.IsGenericType);  // 輸出: True
        Console.WriteLine(a2.IsGenericType);  // 輸出: True

        Type[] genericArgs1 = a1.GetGenericArguments();
        Type[] genericArgs2 = a2.GetGenericArguments();

        Console.WriteLine($"A<> 參數數量: {genericArgs1.Length}"); // 輸出: 1
        Console.WriteLine($"A<,> 參數數量: {genericArgs2.Length}"); // 輸出: 2
    }

}

class A<TT>{}

class A<T1,T2>{}