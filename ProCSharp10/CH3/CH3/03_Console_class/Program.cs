//console color example
// Apply background color to whole console

using System;
using System.Collections.Specialized;

Console.BackgroundColor=ConsoleColor.DarkBlue;
Console.ForegroundColor=ConsoleColor.White;

Console.WriteLine("Before clear Console..");
Thread.Sleep(2000);

// Clear the console to apply background color to entire window
Console.Clear();

Console.Title= "Console Color Example";
Console.WriteLine("This is a console with a dark blue background and white text.");
GetUserData();


static void GetUserData()
{
  // Get name and age.
  Console.Write("Please enter your name: ");
  string userName = Console.ReadLine();
  Console.Write("Please enter your age: ");
  string userAge = Console.ReadLine();
  // Change echo color, just for fun.
  ConsoleColor prevColor = Console.ForegroundColor;
  Console.ForegroundColor = ConsoleColor.Yellow;
  // Echo to the console.
  Console.WriteLine("Hello {0}! You are {1} years old.",
  userName, userAge);
  // Restore previous color.
  Console.ForegroundColor = prevColor;
}