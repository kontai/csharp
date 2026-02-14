using System.Threading.Channels;

namespace ch2;

public class enum_demo
{
    static void Main(string[] args)
    {
        Console.WriteLine(sizeof(BorderSide));
    }
}

enum BorderSide
{
    Top,
    Left=0b01,
    Right=0x02,
    Bottom
}
