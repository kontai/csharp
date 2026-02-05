Display(Nut.Macadamia); // Nut.Macadamia
Display(Size.Large); // Size.Large
string[] nutNames = Enum.GetNames(typeof(Nut));
Console.WriteLine("------------------------");
foreach (var nutName in nutNames)
{
    Console.WriteLine(nutName);
}

void Display(Enum value)
{
    Console.WriteLine(value.GetType().Name + "." + value.ToString());
}

enum Nut { Walnut, Hazelnut, Macadamia }
enum Size { Small, Medium, Large }