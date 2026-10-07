Console.WriteLine("***** Fun with Binary Writers / Readers *****\n");

// 為一個檔案開啟二進位寫入器。
FileInfo f = new FileInfo("BinFile.dat");
using (BinaryWriter bw = new BinaryWriter(f.OpenWrite()))
{
    // 印出 BaseStream 的型別。
    // （在這個例子中是 System.IO.FileStream）。
    Console.WriteLine("Base stream is: {0}", bw.BaseStream);
    // 建立一些要儲存到檔案中的資料。
    double aDouble = 1234.67;
    int anInt = 34567;
    string aString = "A, B, C, D";
    // 寫入資料。
    bw.Write(aDouble);
    bw.Write(anInt);
    bw.Write(aString);
}
Console.WriteLine("Done!");

// 從串流中讀取二進位資料。
using (BinaryReader br = new BinaryReader(f.OpenRead()))
{
    Console.WriteLine(br.ReadDouble());
    Console.WriteLine(br.ReadInt32());
    Console.WriteLine("字符串長度: {0}", br.Read7BitEncodedInt());
    //Console.WriteLine(br.ReadString());
}
