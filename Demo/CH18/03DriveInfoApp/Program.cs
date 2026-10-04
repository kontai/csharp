// 取得所有磁碟機的資訊。

DriveInfo[] myDrives = DriveInfo.GetDrives();
// 印出各磁碟機的狀態。
Console.WriteLine("***** Fun with DriveInfo *****");
foreach (DriveInfo d in myDrives)
{
    Console.WriteLine("Name: {0}", d.Name);
    Console.WriteLine("Type: {0}", d.DriveType);
    // 檢查磁碟機是否已掛載（就緒）。
    try
    {
        if (!d.IsReady)
        {continue;}
            Console.WriteLine("Format: {0}", d.DriveFormat);
            Console.WriteLine("Label: {0}", d.VolumeLabel);
            Console.WriteLine("Free space: {0:F1}GB", d.TotalFreeSpace/1024.0/1024.0/1024.0);
            Console.WriteLine("Available space: {0:F1}GB",d.AvailableFreeSpace/1024.0/1024.0/1024.0);
            //TotalFreeSpace：磁碟上全部的可用空間(通常包含系統保留空間)
            // AvailableFreeSpace：目前使用者實際可用的空間，會把磁碟配額（quota）算進去。(受到使用者權限/配額等限制)
    }
    catch (Exception e )when (e is IOException or UnauthorizedAccessException )    
    {
        Console.WriteLine(e);
        throw;
    }

    Console.WriteLine();
}

/* DriveType 列舉的值
值	        意義
Fixed	    固定式磁碟（內接硬碟、SSD）
Removable	卸除式裝置（USB 隨身碟、記憶卡）
Network	    網路磁碟機
CDRom	    光碟機
Ram	RAM     磁碟
NoRootDirectory	    磁碟機沒有根目錄
Unknown	    無法判斷類型
*/