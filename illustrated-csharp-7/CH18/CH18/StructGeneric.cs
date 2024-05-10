using System.Drawing;

namespace CH18;

internal struct PieceOfData<T>
{
    public PieceOfData(T value)
    {
        data = value;
    }

    private T data;

    public T Data
    {
        get => data;
        set => data = value;
    }
}

public class StructGeneric
{
    private static void Main(string[] args)
    {
        var intData = new PieceOfData<int>(10);
        var stringData = new PieceOfData<string>("Hi there");

        Console.WriteLine($"intData ={intData.Data}");
        Console.WriteLine($"stringData ={stringData.Data}");
    }
}