using CheckNullParameter;

try
{
    Fun1.MyFun(null);
}
catch (ArgumentNullException e)
{
    Console.WriteLine("ArgumentNullException caught!");

    //storage original console color
    var originalColor = Console.ForegroundColor;
    var originalBackground = Console.BackgroundColor;

    //change console color
    Console.BackgroundColor = ConsoleColor.DarkRed;
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($"{e.Message}");
    Console.WriteLine($"{e.StackTrace}");

    //restore original console color
    Console.ForegroundColor = originalColor;
    Console.BackgroundColor = originalBackground;
}