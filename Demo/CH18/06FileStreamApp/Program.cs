using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.VisualBasic;

Console.WriteLine("***** Fun with FileStreams *****\n");

string filepath = Path.Combine(AppContext.BaseDirectory, "Test.dat");

// 取得一個 FileStream 物件。
await using (
    FileStream fStream = new FileStream(
        filepath,
        new FileStreamOptions
        {
            Mode = FileMode.Create,
            Access = FileAccess.ReadWrite,
            Options = FileOptions.Asynchronous,
        }
    )
)
{
    string message = "Hello!";
    // 將字串轉換為字元陣列。
    byte[] msgByteArray = Encoding.UTF8.GetBytes(message);
    // 寫入字元陣列到檔案。
    await fStream.WriteAsync(msgByteArray, 0, msgByteArray.Length);
    //重設串流的位置
    fStream.Position = 0;

    // 從檔案讀取這些型別，並顯示到主控台。
    Console.Write("Your message as an array of bytes: ");

    byte[] byteFromFile = new byte[msgByteArray.Length];
    await fStream.ReadExactlyAsync(byteFromFile);
    Console.WriteLine(Encoding.UTF8.GetString(byteFromFile));
    Console.WriteLine("一共讀取到 {0}個位元.", byteFromFile.Length);
    MemoryStream memoryStream = new MemoryStream();

}
