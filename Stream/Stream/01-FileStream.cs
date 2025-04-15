using System.Text;

/*FileStream writeFile = File.Create("test.txt");
byte[] buffer = Encoding.UTF8.GetBytes("haha");

writeFile.Write(buffer, 0, buffer.Length);
writeFile.Close();*/

//FileStream f=new FileStream("test.txt", FileMode.Open);

//string[] f1=File.ReadAllLines("test.txt");
//foreach (var se in f1)
//{
//    Console.WriteLine(se);
//}
using (FileStream f = new FileStream("test.txt", FileMode.Open))
{
    byte[] buffer = new byte[f.Length];
    int readBuffer = 0;
    while (readBuffer < f.Length)
        readBuffer += f.Read(buffer, readBuffer, (int)(f.Length) - readBuffer);

    string s = Encoding.UTF8.GetString(buffer);
    Console.WriteLine(s);
}

string sAll = File.ReadAllText("test.txt");
Console.WriteLine(sAll);
