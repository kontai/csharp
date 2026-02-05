Console.WriteLine(new TimeSpan(2, 30, 0)); // 02:30:00 (2 小時 30 分)
Console.WriteLine(TimeSpan.FromHours(2.5)); // 02:30:00 (2.5 小時)
Console.WriteLine(TimeSpan.FromHours(-2.5)); // -02:30:00 (負 2.5 小時)

Console.WriteLine(TimeSpan.FromHours(2) + TimeSpan.FromMinutes(30)); // 結果是 02:30:00;

Console.WriteLine(TimeSpan.FromDays(10) - TimeSpan.FromSeconds(1)); // 結果是 9 天 23:59:59


//integer Property
TimeSpan nearlyTenDays = TimeSpan.FromDays(10) - TimeSpan.FromSeconds(1);
Console.WriteLine(nearlyTenDays.Days);        // 9 天
Console.WriteLine(nearlyTenDays.Hours);       // 23 小時
Console.WriteLine(nearlyTenDays.Minutes);     // 59 分
Console.WriteLine(nearlyTenDays.Seconds);     // 59 秒
Console.WriteLine(nearlyTenDays.Milliseconds); // 0 毫秒

//double Property
Console.WriteLine(nearlyTenDays.TotalDays);        // 9.99998842592593 天
Console.WriteLine(nearlyTenDays.TotalHours);       // 239.999722222222 小時
Console.WriteLine(nearlyTenDays.TotalMinutes);     // 14399.9833333333 分
Console.WriteLine(nearlyTenDays.TotalSeconds);     // 863999 秒
Console.WriteLine(nearlyTenDays.TotalMilliseconds); // 863999000 毫秒

//from string
TimeSpan fromString = TimeSpan.Parse("2:20:0");
Console.WriteLine(fromString);

TimeSpan now = DateTime.Now.TimeOfDay;

string s = DateTime.Now.ToString("O");
Console.WriteLine(s);
Nut
