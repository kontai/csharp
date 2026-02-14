using System.Threading.Channels;

namespace ch2;

public class enum_demo
{
    private static void Main(string[] args)
    {
        //print borderside members
        Console.WriteLine(BorderSide.Top); // Output: Top
        Console.WriteLine(HorizontalAlignment.Left);
        Console.WriteLine(HorizontalAlignment.Top);
    }
}

[Flags]
internal enum BorderSide
{
    Top = 1,
    Left = 1 << 1,
    Right = 1 << 2,
    Bottom = 1 << 3,
}

public enum HorizontalAlignment
{
    Left = BorderSide.Left,
    Right = BorderSide.Right,
    Top,
    Bottom,
    Center
}

public enum VerticalAlignment
{
    Top = BorderSide.Top,
    Bottom = BorderSide.Bottom,
    Center
}