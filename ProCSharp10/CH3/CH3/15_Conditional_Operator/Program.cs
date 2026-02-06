using System;

ConditionalRefExample();

static void ConditionalRefExample()
{
    var smallArray = new int[] { 1, 2, 3, 4, 5 };
    var largeArray = new int[] { 10, 20, 30, 40, 50 };

     int index = 7;
     
    //表達式必須有ref,因為三目運算符為右值會自動解引用
    ref int refRes =  ref((index < 5)
        ? ref smallArray[index]
        : ref largeArray[index - 5]);
    refRes = 0;

    index = 2;
    //三目運算符為左值,保持引用
    ((index < 5)
        ? ref smallArray[index]
        : ref largeArray[index - 5]) = 100;

    Console.WriteLine(string.Join(" ", smallArray));
    Console.WriteLine(string.Join(" ", largeArray));
    //1 2 100 4 5
    //10 20 0 40 50
}