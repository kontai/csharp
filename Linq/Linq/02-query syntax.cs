string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };

IEnumerable<string> query =
    from n in names
    where n.Contains("a")
    orderby n.Length
    select n.ToUpper();

Console.WriteLine($"{string.Join(',', query).Trim(',')}");


//mixed-syntax queries
int count =
    (from n in names
     where n.Contains('a')
     select n).Count();
Console.WriteLine($"Count: {count}");


//deferred execution   延遲執行
// Where , Select , orderBy
var list = new List<int> { 1 };
IEnumerable<int> enu = from n in list select n * 10; //building query syntax

list.Add(2);

list.ForEach(i => Console.Write($"{i} "));  //execution query 

//immediate execution
//First , Last , Count , max
// ToArray()、ToList()、ToDictionary()、ToLookup()、ToHashSet()