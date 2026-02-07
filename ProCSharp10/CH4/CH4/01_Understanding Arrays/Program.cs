using System;

Console.WriteLine("***** Fun with Arrays *****");
SimpleArrays();

ArrayOfObjects();
//Console.ReadLine();

/// <summary>
/// Simples the arrays.
/// </summary>
/// <returns></returns>
static void SimpleArrays()
{
    Console.WriteLine("=> Simple Array Creation.");

    // Create and fill an array of 3 integers
    // 建立一個可以裝 3 個整數的陣列
    // 注意：這裡的 [3] 代表「總數量」，不是「最大索引」
    int[] myInts = new int[3];

    // Create a 100 item string array, indexed 0 - 99
    // 建立一個可以裝 100 個字串的陣列，索引是 0 到 99
    string[] booksOnDotNet = new string[100];

    //使用陣列初始化器來建立陣列,不需要指定陣列大小,編譯器會自動推斷
    int[] myInts2 = new int[] { 100, 200, 300 };
    string[] booksOnDotNet2 = new string[3]
    {
        "C# 9.0 in a Nutshell", 
        "Pro C# 9 with .NET 5", 
        "C# 9 and .NET 5 - Modern Cross-Platform Development"
    };

    //a是一個匿名陣列,編譯器會自動推斷陣列的類型和大小
    var a = new[] { 1, 10, 100, 1000 };
    Console.WriteLine("a is a: {0}",a.ToString());

    //b是一個匿名陣列,編譯器會自動推斷陣列的類型和大小,由於陣列中有整數和浮點數,編譯器會將整數轉換為浮點數,所以b的類型是double[]
    var b = new[] { 1, 1.4, 2, 2.6 };
    Console.WriteLine("b is a {0}",b.ToString());
    Console.WriteLine();
}

//Object 是所有類型的基底類別,所以 object[] 可以裝任何類型的物件
static void ArrayOfObjects()
{
  Console.WriteLine("=> Array of Objects.");
  // An array of objects can be anything at all. 
  object[] myObjects = new object[4]; 
  myObjects[0] = 10;
  myObjects[1] = false;
  myObjects[2] = new DateTime(1969, 3, 24); 
  myObjects[3] = "Form & Void";
  foreach (object obj in myObjects)
  {
    // Print the type and value for each item in array. 
    Console.WriteLine("Type: {0}, Value: {1}", obj.GetType(), obj);
  } 
  Console.WriteLine();
}