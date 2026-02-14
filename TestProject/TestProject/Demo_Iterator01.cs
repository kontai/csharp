//foreach (string ss in Foo(true))
//{
//    Console.WriteLine(ss);
//}
string firstElement = null;
var sequence = Foo(false);
using(var enumerator=sequence.GetEnumerator())

    while (enumerator.MoveNext())
        Console.WriteLine(firstElement = enumerator.Current);
;

IEnumerable<string> Foo(bool breakEarly)
{
    yield return "One";
    yield return "Two";
    if (breakEarly)
    {
        yield break;
    }
    yield return "Three";
}