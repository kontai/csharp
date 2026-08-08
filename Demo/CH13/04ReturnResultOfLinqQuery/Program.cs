var getColor = GetStingSubsetAsArray();
const string colors = "Gray";
Console.WriteLine("\n*** fun with Result of linq Query ***");
foreach (var item in getColor.DefaultIfEmpty("No Red"))
{
    Console.WriteLine(item);
}


static string[] GetStingSubsetAsArray()
{
    string[] colors = { "Light Red", "Green", "Yellow", "Dark Red", "Red", "Purple" };
    var res = colors.Where(c => c.Contains("Red")).Select(c => c);
    ReflictOverQueryResult(res);
    return res.ToArray();
}

static void ReflictOverQueryResult(Object obj,string expressType="Express Query")
{
    Console.WriteLine($"Express Type:{expressType}");
    Console.WriteLine("Underlying type is {0}",obj.GetType().Name);
    Console.WriteLine("Assembly names: {0}",obj.GetType().Assembly.GetName().Name);
}