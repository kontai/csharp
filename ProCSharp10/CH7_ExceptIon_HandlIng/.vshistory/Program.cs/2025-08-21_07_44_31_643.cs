using System.Collections;
using SimpleException;

Car myCar = new Car("Zippy", 20); // 建立一台車，初速 20
myCar.CrankTunes(true);           // 開收音機

try
{
    for(int i = 0; i < 10; i++)
    {
        myCar.Accelerate(10); // 超速會丟例外
    }
}
catch(Exception e)
{
    // 這裡是處理例外的程式碼
    Console.WriteLine("\n*** Error! ***");
    Console.WriteLine("Method: {0}", e.TargetSite); // 哪個方法丟的
    Console.WriteLine("Message: {0}", e.Message);    // 例外訊息
    Console.WriteLine("Source: {0}", e.Source);     // 例外來源
    Console.WriteLine("HelperLink:{0}",e.HelpLink);
    Console.WriteLine("Data:");
    foreach (DictionaryEntry o in e.Data)
    {
        Console.WriteLine($@"{o.Key}:{o.Value}");
    }
}


// 處理完例外後，程式會繼續執行
Console.WriteLine("\n***** Out of exception logic *****");
