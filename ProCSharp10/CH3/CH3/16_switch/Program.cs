using System;

//SwitchOnEnumExample();

//ExecutePatternMatchSwitchWithWhen();

//string? rainbowColor = FromRainbow("Green");
//Console.WriteLine(rainbowColor);

//string? rainbowColor2 = FromRainbow2("Green");
//Console.WriteLine(rainbowColor2);

Console.WriteLine(RockPaperScissors("paper","rock")); 
Console.WriteLine(RockPaperScissors("scissors","rock"));

// switch语句可以使用枚举类型来进行分支判断。下面是一个示例，展示了如何使用switch语句来处理枚举类型的值。
void SwitchOnEnumExample()
{
    Console.WriteLine("Enter your favorite day of the week: ");
    DayOfWeek favDay;
    favDay = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), Console.ReadLine());

    switch (favDay)
    {
        case DayOfWeek.Sunday:
            Console.WriteLine("Football");
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

// C# 9.0引入了模式匹配增强功能，允许在switch语句中使用when子句来添加额外的条件。
// 这使得switch语句更加灵活，可以根据更复杂的条件进行分支判断。下面是一个示例，展示了如何使用模式匹配和when子句来处理用户输入。
static void ExecutePatternMatchSwitchWithWhen()
{
    Console.WriteLine("1 [C#], 2[VB]");
    Console.WriteLine("Please pick your language preference: ");
    string? langChoice = Console.ReadLine();
    object choice = int.TryParse(langChoice, out int c) ? c : langChoice;
    switch (choice)
    {
        case int i when i == 1:
        case string s when s.Equals("C#", StringComparison.OrdinalIgnoreCase):
            Console.WriteLine("Good choice, C$ is fine language.");
            break;

        case int i when i == 2:
        case string s when s.Equals("VB", StringComparison.OrdinalIgnoreCase):
            Console.WriteLine("VB: OOP, multithreading, and more!");
            break;

        default:
            Console.WriteLine("Well...good luck with that!");
            break;
    }

    Console.WriteLine();
}

// 下面是一个示例，展示了如何使用switch表达式来根据输入的颜色名称返回对应的十六进制颜色代码。(C# 8.0引入了switch表达式，使得代码更加简洁和易读。)
static string FromRainbow(string colorBand)
{
    return colorBand switch {
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

static string FromRainbow2(string colorBand) => colorBand switch {
    "Red" => "#FF0000",
    "Orange" => "#FF7F00",
    "Yellow" => "#FFFF00",
    "Green" => "#00FF00",
    "Blue" => "#0000FF",
    "Indigo" => "#4B0082",
    "Violet" => "#9400D3",
    _ => "#FFFFFF",
};

//tuples and pattern matching
// 下面是一个示例，展示了如何使用元组和模式匹配来实现一个简单的石头剪子布游戏。根据玩家的选择，返回游戏结果。
static string RockPaperScissors(string first, string second)
{
    return (first, second) switch {
        ("rock", "paper") => "Paper wins.",
        ("rock", "scissors") => "Rock wins.",
        ("paper", "rock") => "Paper wins.",
        ("paper", "scissors") => "Scissors wins.",
        ("scissors", "rock") => "Rock wins.",
        ("scissors", "paper") => "Scissors wins.",
        (_, _) => "Tie.",
    };
}