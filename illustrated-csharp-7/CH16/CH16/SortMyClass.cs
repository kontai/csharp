namespace CH16;

internal class MyClass : IComparable    //類實現接口
{
    public int TheValue;

    public int CompareTo(object? obj)   //實現方法
    {
        MyClass mc = (MyClass)obj;
        if (this.TheValue > mc.TheValue) return 1;
        if (this.TheValue < mc.TheValue) return -1;
        return 0;
    }
}

public class SortMyClass
{
    private static void PrintOut(string s, MyClass[] mc)
    {
        Console.Write(s);
        foreach (MyClass m in mc)
            Console.Write($"{m.TheValue} ");
        Console.WriteLine("");
    }

    private static void Main(string[] args)
    {
        var myInt = new[] { 20, 4, 15, 8, 2 };
        MyClass[] mcArr = new MyClass[myInt.Length];    //創建MyClass數組
        for (int i = 0; i < mcArr.Length; i++)  //初始化數組
        {
            mcArr[i] = new MyClass();
            mcArr[i].TheValue = myInt[i];
        }
        PrintOut("Initial Order: ", mcArr); //輸出初始順序
        Array.Sort(mcArr);  //數組排序
        PrintOut("Sorted Order: ", mcArr);  //輸出排序後順序
    }
}