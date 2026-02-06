DefaultDeclarations();
NewingDataTypes();
NewingDataTypesWith9();
static void DefaultDeclarations()
{
    Console.WriteLine("=> Default Declarations:");
    int myInt = default;    // 預設值為 0
    Console.WriteLine(myInt);
}

// 傳統寫法
static void NewingDataTypes()
{
    Console.WriteLine("=> Using new to create variables:");
    bool b = new bool();              // Set to false.
    int i = new int();                // Set to 0.
    double d = new double();          // Set to 0.
    DateTime dt = new DateTime();     // Set to 1/1/0001 12:00:00 AM
    Console.WriteLine("{0}, {1}, {2}, {3}", b, i, d, dt);
    Console.WriteLine();
}

// C# 9.0 以後支援的語法
static void NewingDataTypesWith9()
{
    Console.WriteLine("=> Using new to create variables:");
    bool b = new();              // Set to false.
    int i = new();               // Set to 0.
    double d = new();            // Set to 0.
    DateTime dt = new();         // Set to 1/1/0001 12:00:00 AM
    Console.WriteLine("{0}, {1}, {2}, {3}", b, i, d, dt);
    Console.WriteLine();
}