using System;

Console.WriteLine("{0:C}", 10000); //print currency format(貨幣格式)

Console.WriteLine("{0:E}", 12345);   //print scientific format(科學記號格式)

Console.WriteLine("{0:D3}", 20); //print decimal format(十進位格式), at least 3 digits

Console.WriteLine("{0:N}", 12345.00);   //print number format(數字格式)

Console.WriteLine("{0:F3}", 123.4);  //print fixed-point format(小數點格式), 3 digits after decimal point

Console.WriteLine("{0:X}", 232);    //print hexadecimal format(十六進位格式)

Console.WriteLine(new string('=',30));

// 呼叫範例 (放在程式進入點)
FormatNumericalData();

// Now make use of some format tags.
static void FormatNumericalData()
{
  Console.WriteLine("The value 99999 in various formats:");
  
  // c format: 貨幣格式
  // 注意：你的電腦如果是台灣地區設定，可能會看到 NT$
  Console.WriteLine("c format: {0:c}", 99999);
  
  // d9 format: 十進位並補零到 9 位數
  // 99999 只有 5 位，所以前面補 4 個 0 -> 000099999
  Console.WriteLine("d9 format: {0:d9}", 99999);
  
  // f3 format: 定點數，取小數點後 3 位
  // 整數後面會補上 .000
  Console.WriteLine("f3 format: {0:f3}", 99999);
  
  // n format: 加上千分位逗點
  // 預設通常也是兩位小數 -> 99,999.00
  Console.WriteLine("n format: {0:n}", 99999);
  
  // Notice that upper- or lowercasing for hex
  // determines if letters are upper- or lowercase.
  // X format: 十六進位
  // 99999 轉成 16 進位是 1869F
  Console.WriteLine("E format: {0:E}", 99999);
  Console.WriteLine("e format: {0:e}", 99999);
  Console.WriteLine("X format: {0:X}", 99999);
  Console.WriteLine("x format: {0:x}", 99999);
}