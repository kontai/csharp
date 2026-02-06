/*
 * c#的if只判斷bool值,不像c/c++判斷是否條件為0
 */

using System;

int i = 1;
bool tRuE = true;
ifelsePatternMatching();
IfElsePatternMatchingUpdatedInCSharp9();

/*

//c#只接受bool值
if (i)
{
    Console.WriteLine("no");
}

//正確
if(i>0){
}

*/

void ifelsePatternMatching()
{
    Console.WriteLine("===If Else Pattern Matching ===");
    object testItem1 = 123;
    object testItem2 = "Hello";

    if (testItem1 is string MyStringVale1)
    {
        Console.WriteLine($"{MyStringVale1} is a string.");
    }
    MyStringVale1 = "hi";
    if (testItem1 is int MyVale1)
    {
        Console.WriteLine($"{MyVale1} is a int");
    }

    MyVale1 = 20;
    /*
  if (testItem2 is string MyStringVale1)
  {
      Console.WriteLine($"{MyStringVale1} is a string.");
  }

  if (testItem2 is int MyVale1)
  {
      Console.WriteLine($"{MyVale1} is a int");
  }
    */
    Console.WriteLine($"{MyStringVale1},{MyVale1}");
}

static void IfElsePatternMatchingUpdatedInCSharp9()
{
    Console.WriteLine("======= C# 9 If Else Pattern Matching Improvements =======");
    object testItem1 = 123;
    Type t = typeof(string);
    char c = 'f';

    //Type patterns
    if (t is Type)
    {
        Console.WriteLine($"t is a Type");
    }

    //Relational, Conjuctive, and Disjunctive patterns
    //傳統寫法:
    //if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'))

    if (c is >= 'a' and <= 'z' or >= 'A' and <= 'Z')
    {
        Console.WriteLine($"{c} is a character ");
    }

    //Parenthesized patterns
    if (c is (>= 'a' and <= 'z') or (>= 'A' and <= 'Z'))
    {
        Console.WriteLine($"{c} is a character ");
    }

    //Negative patterns
    if (testItem1 is not string)
    {
        Console.WriteLine($"{testItem1} is not a string.");
    }

    //Negative patterns
    if (testItem1 is not null)
    {
        Console.WriteLine($"{testItem1} is not a null.");
    }

    Console.WriteLine();
}


