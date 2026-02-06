//SwitchOnEnumExample();
//ExecutePatternMatchingSwitch();
//ExecutePatternMatchingSwitchWithWhen();
string Color=FromRainbow("Red");
Console.WriteLine(Color);

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
      Console.WriteLine("Your choice is an integer.{0}",i);
      break;
    case string s:
      Console.WriteLine("Your choice is a string.{0}",s);
      break;
    case decimal d:
      Console.WriteLine("Your choice is a decimal.{0}",d);
      break;
    default:
      Console.WriteLine("Your choice is something else");
      break;
  }
  Console.WriteLine();
}

static void ExecutePatternMatchingSwitchWithWhen()
{
  Console.WriteLine("1 [C#], 2 [VB]");
  Console.Write("Please pick your language preference: ");
  object langChoice = Console.ReadLine();
  var choice = int.TryParse(langChoice.ToString(), out int c) ? c : langChoice;
  switch (choice)
  {
    case int i when i == 2:
    case string s when s.Equals("VB", StringComparison.OrdinalIgnoreCase):
      Console.WriteLine("VB: OOP, multithreading, and more!");
      break;
    case int i when i == 1:
    case string s when s.Equals("C#", StringComparison.OrdinalIgnoreCase):
      Console.WriteLine("Good choice, C# is a fine language.");
      break;
    default:
      Console.WriteLine("Well...good luck with that!");
      break;
  }
  Console.WriteLine();
}

static string FromRainbow(string colorBand)
{
  return colorBand switch
  {
    "Red" => "#FF0000",
    "Orange" => "#FF7F00",
    "Yellow" => "#FFFF00",
    "Green" => "#00FF00",
    "Blue" => "#0000FF",
    "Indigo" => "#4B0082",
    "Violet" => "#9400D3",
    _ => "#FFFFFF",
  };
}

//Switch expression with Tuples
static string RockPaperScissors(string first, string second)
{
  return (first, second) switch
  {
    ("rock", "paper") => "Paper wins.",
    ("rock", "scissors") => "Rock wins.",
    ("paper", "rock") => "Paper wins.",
    ("paper", "scissors") => "Scissors wins.",
    ("scissors", "rock") => "Rock wins.",
    ("scissors", "paper") => "Scissors wins.",
    (_, _) => "Tie.",
  };
}