var a1 = new { X = 2, Y = 4 };
var a2 = new { X = 2, Y = 4 };
Console.WriteLine(a1.GetType()==a2.GetType());

Console.WriteLine(a1.Equals(a2));   //Equals 是比較內容
Console.WriteLine(a1 == a2);   //'==' 是比較參考

//once anonymous type is created,it cannot be changed.
var a3 = a1 with { X = 5 }; //"with" keyword 可以在建立新物件時, 透過參考對象的屬性來建立新物件 from c#10




//Anonymous  Type Array
var dudes = new[]
{
    new { Name = "Alice", Age = 20 },
    new { Name = "Bob", Age = 30 }
};

