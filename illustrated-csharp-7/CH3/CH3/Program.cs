Console.WriteLine("The value: {0}.",500);
Console.WriteLine("The value: {0:C}.",500);     //以貨幣格式輸出
Console.WriteLine("The value: {0,10}.",500);    //一共輸出10位數,正數代表向右對齊,負數是向左肘齊
Console.WriteLine("The value: {0,10:F4}", 500);  //一共輸出10位數,以浮
Console.WriteLine("1024 hex: {0:x}",1024);
Console.WriteLine("1024 hex: {0:n}",1024);

string dec2hex=string.Format("{0}十六進制是:{0:x}",100);
Console.WriteLine(dec2hex);