//createTupe();
//namedRule();
using System.Runtime.ExceptionServices;equality();
var names=SplitName("sdkfjf");
Console.WriteLine(names);
var (a, b, c) = SplitName("askdfjkfjl");
Console.WriteLine($"{a},{b},{c}");
Console.WriteLine();

//Discards with Tuples
Console.WriteLine("-------Discards with Tuples----------");
var(first,_,last) =SplitName("sdkfjf");
Console.WriteLine($"{first},{last}");


static void createTupe()
{

(string, int, string) values = ("a", 5, "c");
var values2 = ("a", 5, "c");

Console.WriteLine($"First item: {values.Item1}");
Console.WriteLine($"Second item: {values.Item2}");
Console.WriteLine($"Third item: {values.Item3}");

(string FirstLetter, int TheNumber, string SecondLetter) valuesWithNames = ("a", 5, "c");
var valuesWithNames2 = (FirstLetter: "a", TheNumber: 5, SecondLetter: "c");

Console.WriteLine($"First item: {valuesWithNames.FirstLetter}");
Console.WriteLine($"Second item: {valuesWithNames.TheNumber}");
Console.WriteLine($"Third item: {valuesWithNames.SecondLetter}");
//Using the item notation still works!
Console.WriteLine($"First item: {valuesWithNames.Item1}");
Console.WriteLine($"Second item: {valuesWithNames.Item2}");
Console.WriteLine($"Third item: {valuesWithNames.Item3}");
}

//命名陷阱：var vs. 明確型別
static void namedRule(){
////////////////////////
    /// 情境 A：使用 var (推薦)
// 正確：編譯器看到 var，會採用右邊的名字
    var goodTuple = (Custom1: 5, Custom2: 7);

// 結果：你可以用名字存取
    Console.WriteLine(goodTuple.Custom1); // 成功！

//情境 B：使用明確型別 (陷阱)
// 錯誤：左邊寫死了 (int, int)
    (int, int) badTuple = (Custom1: 5, Custom2: 7);

// 結果：名字不見了！編譯器只給你 Item1, Item2
    //Console.WriteLine(badTuple.Custom1); // 編譯錯誤！
    Console.WriteLine(badTuple.Item1);      // 只能這樣用
}


//Tuple Equality/Inequality
static void equality()
{
Console.WriteLine("=> Tuples Equality/Inequality");
// lifted conversions
var left = (a: 5, b: 10);
(int? a, int? b) nullableMembers = (5, 10);
Console.WriteLine(left == nullableMembers); // Also true
// converted type of left is (long, long)
(long a, long b) longTuple = (5, 10);
Console.WriteLine(left == longTuple); // Also true
// comparisons performed on (long, long) tuples
(long a, int b) longFirst = (5, 10);
(int a, long b) longSecond = (5, 10);
Console.WriteLine(longFirst == longSecond); // Also true
}

static (string first, string mid, string last) SplitName(string name)
{
    return ("john", "bill", "michael");
}

//Switch expression with Tuples
static string RockPaperScissors(string first, string second)
{
  return (first, second) switch
  {
    ("rock", "paper") => "Paper wins.",
    ("rock", "scissors") => "Rock wins.",
    ("paper", "rock") => "Paper wins.",
    ("paper", "scissors") => "Scissors wins.",
    ("scissors", "rock") => "Rock wins.",
    ("scissors", "paper") => "Scissors wins.",
    (_, _) => "Tie.",
  };
}

static string RockPaperScissorsP(
  (string first, string second) value){
  return value switch
  {
    //omitted for brevity
  };
}
