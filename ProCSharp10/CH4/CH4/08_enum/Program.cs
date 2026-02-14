using System;
using System.Collections.Generic;

colorEnum myColor = colorEnum.Blue;
showEnum(myColor);
Console.WriteLine(Enum.GetUnderlyingType(typeof(colorEnum)));   //獲取資料類型
Console.WriteLine(Enum.GetUnderlyingType(typeof(EmpTypeEnum)));

Console.WriteLine($"myColor is {myColor}");
Console.WriteLine($"myColor is {myColor.ToString()}");

Console.WriteLine($"myColor values is {(int)myColor}");
Console.WriteLine($"myColor values is {myColor:D}");

EmpTypeEnum e01 = EmpTypeEnum.Contractor;
DayOfWeek dw = DayOfWeek.Monday;
colorEnum c01 = colorEnum.White;

List<Enum> lists = new List<Enum>() { e01, dw, c01 };
foreach (var e in lists)
{
    Console.WriteLine("================================");
    EvaluateEnum(e);
    Console.WriteLine();
}


static void showEnum(colorEnum ce)
{
    switch (ce)
    {
        case colorEnum.Blue:
            Console.WriteLine("color blue");
            break;

        case colorEnum.Red:
            Console.WriteLine("color Red");
            break;

        case colorEnum.Yellow:
            Console.WriteLine("color Yellow");
            break;

        case colorEnum.White:
            Console.WriteLine("color White");
            break;
        defult:
            Console.WriteLine("undefine color.");
            break;
    }

}

static void EvaluateEnum(System.Enum e)
{
  Console.WriteLine("=> Information about {0}", e.GetType().Name);
  Console.WriteLine("GetUnderlineTye: {0}",Enum.GetUnderlyingType(e.GetType()));
    Array enumData= Enum.GetValues(e.GetType());
    Console.WriteLine("Enum has {0} members.",enumData.Length);
    foreach (var color in enumData)
    {
        Console.WriteLine($"{color:D} : {color}");
    }
}

internal enum colorEnum
{
    Red,    //0
    Blue,   //1
    Yellow, //2
    White   //3
}

internal enum carEnum
{
    BMW = 20,
    BENZ = 1,
    TOYOTA = 9,
    VOLVO = 22
}

// This time, EmpTypeEnum maps to an underlying byte.
internal enum EmpTypeEnum : byte
{
    Manager = 10,
    Grunt = 1,
    Contractor = 100,
    VicePresident = 9
}