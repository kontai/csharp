using System.Threading.Channels;

namespace ch2;

public class enum_demo
{
    private static void Main(string[] args)
    {
        //print borderside members
        Console.WriteLine(BorderSide.Top); // Output: Top
        Console.WriteLine(HorizontalAlignment.Left);
        Console.WriteLine((int)HorizontalAlignment.Top);
        //Console.WriteLine(HorizontalAlignment.Top+BorderSide.Top);

        //check if a value is a flag
        BorderSide side = BorderSide.Top | BorderSide.Left;
        Console.WriteLine(Enum.IsDefined(side));
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