<<<<<<< HEAD
﻿//string format example
=======
﻿using System;
//string format example
>>>>>>> 74806036cd0bd06043a96e84d89456abddd353bf
string sf = string.Format("{0:C}", 123456);

Console.WriteLine(sf);

int myValue = 100000;

// 現代寫法：直接把變數填在括號裡，冒號後面接格式
string userMessage = $"100000 in hex is {myValue:x}"; 
string moneyMessage = $"The cost is {myValue:C}";

Console.WriteLine(userMessage);
Console.WriteLine(moneyMessage);

int i = new();

