Console.WriteLine("***** Simple I/O with the File Type *****\n");
string[] myTasks = { "Fix bathroom sink", "Call Dave", "Call Mom and Dad", "Play Xbox One" };
string myPath = Path.Combine(AppContext.BaseDirectory, "book.text");

//寫入檔案
await File.WriteAllLinesAsync(myPath, myTasks);

//IEnumerable<string> tasks = File.ReadLines(@"books.txt");

var rLines = await File.ReadAllLinesAsync(myPath);
foreach (var item in rLines)
{
    Console.WriteLine(item);
}
