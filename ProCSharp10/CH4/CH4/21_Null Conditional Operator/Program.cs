TesterMethod(null);
static void TesterMethod(string[] args)
{
    // We should check for null before accessing the array data!
    Console.WriteLine($"You sent me {args?.Length ?? 0} arguments.");   
}