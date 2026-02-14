using System.Runtime.InteropServices;

namespace TestProject;

delegate void MyDelegate<T>(T myVal);

struct MyStruct
{


    public static void Print(string v)
    {
        Console.WriteLine($"v: {v}");
    }

    public static void toUpper(string v)
    {

        Console.WriteLine($"{v.ToString().ToUpper()}");
    }
}

public class Demo02
{
    static public void MyMethod<T>(T myVal)
    {
        T v1 = myVal;
        Console.WriteLine("v1: {0}", v1);
    }

    static public void ReverseAndPrint<T>(T[] val)
    {
        Array.Reverse(val);
        foreach (var x1 in val)
        {
            Console.Write($"{x1} ");
        }

        Console.WriteLine();
    }

    static void Main(string[] args)
    {
        int[] intArr = { 39, 23, 109, 3, 19 };
        float[] floatArr = { 39.1f, 23.1f, 109.1f, 3.1f, 19.1f };
        string[] strArr = { "39", "23", "109", "3", "19" };

        ReverseAndPrint<int>(intArr);
        ReverseAndPrint(intArr); //自動檢查類型,可以不用寫泛型

        ReverseAndPrint<float>(floatArr);
        ReverseAndPrint(floatArr); //自動檢查類型,可以不用寫泛型


        ReverseAndPrint<string>(strArr);
        ReverseAndPrint(strArr); //自動檢查類型,可以不用寫泛型

        var del = new MyDelegate<string>(MyStruct.Print);
        del("abc");

        del = new MyDelegate<string>(MyStruct.toUpper);
        del("abnc");
    }
}