//StreamReader
using var fs = new FileStream("text.txt", FileMode.Open);
using var sr = new StreamReader(fs);
string line = sr.ReadLine(); // 讀一行文字

//StreamWriter
using var fs = new FileStream("text.txt", FileMode.Create);
using var sw = new StreamWriter(fs);
sw.WriteLine("Hello"); // 寫一行文字

//BinaryReader 讀整數
using var fs = new FileStream("data.bin", FileMode.Open);
using var br = new BinaryReader(fs);
int number = br.ReadInt32(); // 讀 4 字節整數

//BinaryWriter 寫浮點數
using var fs = new FileStream("data.bin", FileMode.Create);
using var bw = new BinaryWriter(fs);
bw.Write(3.14f); // 寫浮點數