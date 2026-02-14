
using System;
using System.Linq;

indexDemo();
void indexDemo()
{
    string[] myString = { "one", "two", "Three" };
    Index index = 1;
    for (int i = 0; i < myString.Length; i++)
    {
        //index = i;
        index = ^(i+1); //^0會報錯, ^1是最後一個元素
        Console.WriteLine(myString[index]);
    }

    Range range = 0..100;


    foreach (var v in myString[..^0])
    {
        Console.WriteLine(v);
    }

    //var bb = myString.ElementAt(^2);



}
