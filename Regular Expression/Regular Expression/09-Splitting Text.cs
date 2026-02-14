//例子（用數字分隔字串）

using System.Text.RegularExpressions;

foreach (string str in Regex.Split("a5b7c", @"\d"))
{
    Console.Write($"{str} ");
}
// Output: a b c

//例子（分割駝峰命名法如 "oneTwoThree"）

Console.WriteLine("");
string orf = "oneTwoThree";
foreach (string str in Regex.Split(orf, @"(?<!^)(?=[A-Z])"))
{
    Console.Write($"{str} ");
}
