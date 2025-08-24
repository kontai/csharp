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
    Left=2,
    Right=4,
    Bottom=8,
}

public enum HorizontalAlignment
{
    Left = BorderSide.Left,
    Right = BorderSide.Right,
    Center
}
