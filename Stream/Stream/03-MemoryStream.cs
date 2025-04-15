using System.Text;

using var s = new FileStream("test.txt", FileMode.Open);
//byte[] buffer = Encoding.UTF8.GetBytes("Hello, World!");

var ms = new MemoryStream();
byte[] buffer = Encoding.ASCII.GetBytes("thusday");
ms.Write(buffer,0,buffer.Length);
//s.CopyTo(ms);
Console.WriteLine($"Length of ms: {ms.Length}");
foreach (var b in ms.ToArray())
{
    Console.Write((char)b);
}