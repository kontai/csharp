//SwitchOnEnumExample();
ExecutePatternMatchingSwitch();
static void SwitchOnEnumExample()
{
  Console.Write("Enter your favorite day of the week: ");
  DayOfWeek favDay;
  try
  {
    favDay = (DayOfWeek) Enum.Parse(typeof(DayOfWeek), Console.ReadLine());
  }
  catch (Exception)
  {
    Console.WriteLine("Bad input!");
    return;
  }
  switch (favDay)
  {
    case DayOfWeek.Sunday:
      Console.WriteLine("Football!!");
      break;
    case DayOfWeek.Monday:
      Console.WriteLine("Another day, another dollar");
      break;
    case DayOfWeek.Tuesday:
      Console.WriteLine("At least it is not Monday");
      break;
    case DayOfWeek.Wednesday:
      Console.WriteLine("A fine day.");
      break;
    case DayOfWeek.Thursday:
      Console.WriteLine("Almost Friday...");
      break;
    case DayOfWeek.Friday:
      Console.WriteLine("Yes, Friday rules!");
      break;
    case DayOfWeek.Saturday:
      Console.WriteLine("Great day indeed.");
      break;
  }
  Console.WriteLine();
}

static void ExecutePatternMatchingSwitch()
{
  Console.WriteLine("1 [Integer (5)], 2 [String (\"Hi\")], 3 [Decimal (2.5)]");
  Console.Write("Please choose an option: ");
  string userChoice = Console.ReadLine();
  object choice;
  //This is a standard constant pattern switch statement to set up the example
  switch (userChoice)
  {
    case "1":
      choice = 5;
      break;
    case "2":
      choice = "Hi";
      break;
    case "3":
      choice = 2.5M;
      break;
    default:
      choice = 5;
      break;
  }
  //This is new the pattern matching switch statement
  switch (choice)
  {
    case int i:
      Console.WriteLine("Your choice is an integer.");
      break;
    case string s:
      Console.WriteLine("Your choice is a string.");
      break;
    case decimal d:
      Console.WriteLine("Your choice is a decimal.");
      break;
    default:
      Console.WriteLine("Your choice is something else");
      break;
  }
  Console.WriteLine();
}