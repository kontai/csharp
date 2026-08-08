//QueryOverStrings();
QueryOverStrings2();
static void QueryOverStrings()
{
    // Assume we have an array of strings.
    string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };
    IEnumerable<string> res = from g in currentVideoGames
                              where g.Contains(" ")
                              orderby g
                              select g;
    foreach (var s in res)
    {
        Console.WriteLine(s);
    }
}

static void QueryOverStrings2()
{
    // Assume we have an array of strings.
    string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };
    IEnumerable<string> res = currentVideoGames
        .Where(g => g.Contains(" "))
        .OrderBy(g => g)
        .Select(g => g);

    foreach (var s in res)
    {
        Console.WriteLine(s);
    }
}