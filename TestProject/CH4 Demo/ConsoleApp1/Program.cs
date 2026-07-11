// 
string? s = testFun()??"empty";
Console.WriteLine("s: {0}",s);


int? nullableInt = null;
nullableInt ??= 20; 
nullableInt ??= 40;
Console.WriteLine(nullableInt);
string? testFun()
{
    return null;
}

// === Demo 2: Null Conditional Operator (?. and ?[]) ===
Console.WriteLine("\n=== Demo 2: Null Conditional Operator (?. and ?[]) ===");

// 1. Property and Member Access using ?.
Customer? customerNull = null;
Customer customerWithAddress = new Customer("Alice", new Address("Taipei", null));
Customer customerFull = new Customer("Bob", new Address("Kaohsiung", "Zhongshan Road"));

// Safely access properties without throwing a NullReferenceException
Console.WriteLine($"Null customer city: {customerNull?.Address?.City ?? "No City"}");
Console.WriteLine($"Alice's city: {customerWithAddress?.Address?.City ?? "No City"}");
Console.WriteLine($"Alice's street: {customerWithAddress?.Address?.Street ?? "No Street"}");
Console.WriteLine($"Bob's street: {customerFull?.Address?.Street ?? "No Street"}");

// 2. Element/Array/Indexer Access using ?[]
string[]? namesArrayNull = null;
string[] namesArray = { "John", "Jane" };

Console.WriteLine($"Null array first element: {namesArrayNull?[0] ?? "Array is null"}");
Console.WriteLine($"Valid array first element: {namesArray?[0] ?? "Array is null"}");

// 3. Method/Delegate/Event Invocation using ?.
Action? sampleAction = null;
Console.Write("Invoking null action: ");
sampleAction?.Invoke(); // Safe: does nothing
Console.WriteLine("Safe!");

sampleAction = () => Console.WriteLine("Action executed successfully!");
Console.Write("Invoking non-null action: ");
sampleAction?.Invoke(); // Executes the delegate

Address? addressNull = null;    


// --- Support Models ---
public record Address(string City, string? Street);
public record Customer(string Name, Address? Address);
