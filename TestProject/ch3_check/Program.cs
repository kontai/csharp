using System.ComponentModel;
using System.Runtime.Intrinsics.X86;

byte b1 = 200;
byte b2 = 150;
try
{
        byte sum =Add(b1, b2) ;
        System.Console.WriteLine(sum);
}
catch (OverflowException ex)
{
    System.Console.WriteLine(ex.Message);
}

byte Add(byte b1, byte b2)
{
    return  (byte)(b1 + b2);
}