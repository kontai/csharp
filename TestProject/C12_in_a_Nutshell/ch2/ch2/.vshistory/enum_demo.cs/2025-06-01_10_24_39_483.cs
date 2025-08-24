using System.Threading.Channels;

namespace ch2;

public class enum_demo
{
    private static void Main(string[] args)
    {
        //print borderside members
    }
}

[Flags]
internal enum BorderSide
{
    Top=1,
    Left=1<<1,
    Right=1<<2,
    Bottom=1<<3,
}

public enum HorizontalAlignment
{
    Left = BorderSide.Left,
    Right = BorderSide.Right,
    Center
}
