Console.WriteLine("***** Fun with Directory(Info) *****\n");
// ShowWindowsDirectoryInfo();
string wallpaperPath = "D:\\w11Home\\Pictures\\wallpaper";
DirectoryInfo d = new DirectoryInfo(wallpaperPath);
ShowWallpaperDirectory(d);
static void ShowWindowsDirectoryInfo()
{
    // 傾印目錄資訊。如果你不是使用 Windows，請改填入另一個目錄
    DirectoryInfo dir = new DirectoryInfo($@"C{Path.VolumeSeparatorChar}{Path.
        DirectorySeparatorChar}Windows");
    Console.WriteLine("***** Directory Info *****");
    Console.WriteLine("FullName: {0}", dir.FullName);
    Console.WriteLine("Name: {0}", dir.Name);
    Console.WriteLine("Parent: {0}", dir.Parent);
    Console.WriteLine("Creation: {0}", dir.CreationTime);
    Console.WriteLine("Attributes: {0}", dir.Attributes);
    Console.WriteLine("Root: {0}", dir.Root);
    Console.WriteLine("**************************\n");
}

static void ShowWallpaperDirectory(DirectoryInfo dir)
{
    if (!dir.Exists)
    {
        Console.WriteLine("path not exist!");
        return;
    }


    var subDirs=    dir.GetDirectories();
    if (subDirs.Length > 0)
    {
        foreach (var subDir in subDirs)
        {
            try
            {
                ShowWallpaperDirectory(subDir);
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    Console.WriteLine("******Current Direactory ******: {0}",dir.FullName);
    // var files=  dir.GetFiles("*.jpg");
    var files = dir.EnumerateFiles("*.jpg").ToList();
    if (files.Count==0)
    {
        Console.WriteLine(" Current Directory is Empty!");
        return;
    }
    foreach (var f in files)
    {
        Console.WriteLine("***************************");
        Console.WriteLine("File name: {0}", f.Name);
        Console.WriteLine("File size: {0}K", f.Length/1024);
        Console.WriteLine("Creation: {0}", f.CreationTime);
        Console.WriteLine("Attributes: {0}", f.Attributes);
        Console.WriteLine("***************************\n"); 
        
    }

    Console.WriteLine("tatoal {0} files.",files.Count());
    static void ModifyAppDirectory()
    {
        DirectoryInfo dir = new DirectoryInfo(".");
        // 在應用程式目錄下建立 \MyFolder。
        dir.CreateSubdirectory("MyFolder");
        // 在應用程式目錄下建立 \MyFolder2\Data。
        dir.CreateSubdirectory(
            $@"MyFolder2{Path.DirectorySeparatorChar}Data");
    }}