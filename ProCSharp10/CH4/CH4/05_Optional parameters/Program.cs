using System;

static void EnterLogData(string message, string owner = "Programmer")   //optional parameter must at last position
{
  Console.WriteLine("Error: {0}", message);
  Console.WriteLine("Owner of Error: {0}", owner);
}

Console.WriteLine("***** Fun with Methods *****");
EnterLogData("Oh no! Grid can't find data");
EnterLogData("Oh no! I can't find the payroll data", "CFO");