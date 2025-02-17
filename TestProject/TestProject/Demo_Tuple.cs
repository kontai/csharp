(string,int,string) bob=("tai",23,"whatever");
Console.WriteLine(bob);
var p = GetPerson();
Console.WriteLine(p.Item1);
//(string,int) GetPerson()=>("tai",19);


//naming tuple
var tuple=(name:"tai",age:19);
Console.WriteLine(tuple.name);
Console.WriteLine(tuple.age);

var p2 = GetPerson();
(string name,int age) GetPerson()=>("tai",19);
