FunWithDirectoryType();
static void FunWithDirectoryType()
{
    // 列出目前電腦上的所有磁碟機。
    string[] drives = Directory.GetLogicalDrives();
    Console.WriteLine("Here are your drives:");
    foreach (string s in drives)
    {
        Console.WriteLine("--> {0} ", s);
    }
    // 刪除先前建立的目錄。
    Console.WriteLine("Press Enter to delete directories");
    Console.ReadLine();
    try
    {
        Directory.Delete("MyFolder");
        // 第二個參數指定是否要一併刪除
        // 所有子目錄。
        Directory.Delete("MyFolder2", true);
    }
    catch (IOException e)
    {
        Console.WriteLine(e.Message);
    }
}