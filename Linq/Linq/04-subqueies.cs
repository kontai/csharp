// subqueies - ordering by first name

string[] musos = { "David Gilmour", "Roger Waters", "Rick Wright", "Nick Mason" };
IEnumerable<string> subQueies = musos.OrderBy(n => n.Split().First());
foreach (string s in subQueies)
{
    Console.WriteLine($"{s} ");
}

// shortest name version 1
string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };
IEnumerable<string> shortName =
    names.Where(n => n.Length ==
                     (names.OrderBy(n2 => n2.Length).Select(n2 => n2.Length).First()));
Console.WriteLine(string.Join(',', shortName));


// shortest name version 2
string[] names2 = { "Tom", "Dick", "Harry", "Mary", "Jay" };
int shortNumber = names2.Min(n => n.Length);
IEnumerable<string> shortName2 = names2.Where(n => n.Length == shortNumber);

Console.WriteLine(string.Join(',', shortName2));
