"pencil".StringCapitalize();

static class MyExtension
{
    public static void StringCapitalize(this string s) => Console.WriteLine($"{s} in method extension string");
    public static void StringCapitalize(this object o) => Console.WriteLine($"{o} in method extension object");
}