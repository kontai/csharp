using System.IO.IsolatedStorage;

File.WriteAllBytes("myFile.bin", new byte[100000]);
using FileStream fs = File.OpenRead("myFile.bin");
using BufferedStream bs = new BufferedStream(fs, 20000);
bs.ReadByte();
Console.WriteLine(fs.Position);

