Console.WriteLine("***** Simple IO with the File Type *****\n");
// 請改成你電腦上有讀寫權限的資料夾，或以系統管理員身分執行
var fileName = $@"C{Path.VolumeSeparatorChar}{Path.DirectorySeparatorChar}temp{Path.DirectorySeparatorChar}Test.dat";
// 在 C 磁碟機上建立新檔案。
FileInfo f = new FileInfo(fileName);
FileStream fs = f.Create();
// 使用 FileStream 物件...
// 關閉檔案資料流。
fs.Close();


// 把檔案資料流包在 using 陳述式中
// 為檔案 I/O 定義 using 範圍
FileInfo f1 = new FileInfo(fileName);
using (FileStream fs1 = f1.Create())
{
    // 使用 FileStream 物件...
}
f1.Delete();

// 透過 FileInfo.Open() 建立新檔案。
FileInfo f2 = new FileInfo(fileName);
using(FileStream fs2 = f2.Open(FileMode.OpenOrCreate,
          FileAccess.ReadWrite, FileShare.None))
{
    // 使用 FileStream 物件...
}
f2.Delete();
// 取得唯讀權限的 FileStream 物件。
FileInfo f3 = new FileInfo(fileName);
// 使用 OpenRead 之前檔案必須存在
f3.Create().Close();
using(FileStream readOnlyStream = f3.OpenRead())
{
    // 使用 FileStream 物件...
}
f3.Delete();
// 接著取得唯寫權限的 FileStream 物件。
FileInfo f4 = new FileInfo(fileName);
using(FileStream writeOnlyStream = f4.OpenWrite())
{
    // 使用 FileStream 物件...
}
f4.Delete();

// 取得 StreamReader 物件。
// 如果不是 Windows 電腦，請對應修改檔名
FileInfo f5 = new FileInfo(fileName);
// 使用 OpenText 之前檔案必須存在
f5.Create().Close();
using(StreamReader sreader = f5.OpenText())
{
    // 使用 StreamReader 物件...
}
f5.Delete();
FileInfo f6 = new FileInfo(fileName);
using(StreamWriter swriter = f6.CreateText())
{
    // 使用 StreamWriter 物件...
}
f6.Delete();
FileInfo f7 = new FileInfo(fileName);
using(StreamWriter swriterAppend = f7.AppendText())
{
    // 使用 StreamWriter 物件...
}
f7.Delete();

var fileName1 = Path.Combine(Path.GetTempPath(), "Test.dat");
Console.WriteLine(fileName1);