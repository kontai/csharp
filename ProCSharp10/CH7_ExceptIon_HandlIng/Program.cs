using System.Collections;
using SimpleException;

//SimpleException();
/*NullReferenceException nullRefEx = new NullReferenceException();
Console.WriteLine(
    "NullReferenceException is-a SystemException? : {0}",
    nullRefEx is Exception); // True
*/
try
{
    MyException();
}
catch (CarIsDeadException e)
{
    try
    {
        FileStream fs = File.Open(@"C:\carErrors.txt", FileMode.Open);
    }
    catch (Exception e2)
    {
        // 產生新的 CarIsDeadException，把 e2 當成內部例外丟出去
        throw new CarIsDeadException(
            e.CauseOfError,
            e.ErrorTimeStamp,
            e.Message,
            e2);
    }
}

void MyException()
{
    throw new CarIsDeadException("You have a lead foot",
        DateTime.Now, "Thunder has overheated!")
    {
        HelpLink = "http://www.CarsRUs.com",
    };
}

void SimpleException()
{
    Car myCar = new Car("Zippy", 20); // 建立一台車，初速 20
    myCar.CrankTunes(true); // 開收音機

    try
    {
        for (int i = 0; i < 10; i++)
        {
            myCar.Accelerate(10); // 超速會丟例外
        }
    }
    catch (Exception e)
    {
        // 這裡是處理例外的程式碼
        Console.WriteLine("\n*** Error! ***");
        Console.WriteLine("Method: {0}", e.TargetSite); // 哪個方法丟的
        Console.WriteLine("Message: {0}", e.Message); // 例外訊息
        Console.WriteLine("Source: {0}", e.Source); // 例外來源
        Console.WriteLine("HelperLink:{0}", e.HelpLink);
        Console.WriteLine("=====================Data=====================");
        foreach (DictionaryEntry o in e.Data)
        {
            Console.WriteLine($@"{o.Key}:{o.Value}");
        }

        //throw;// 重新丟出例外，讓上層處理
    }


// 處理完例外後，程式會繼續執行
    Console.WriteLine("\n***** Out of exception logic *****");
}