ImmediateExecution();

static void ImmediateExecution()
{
    Console.WriteLine();
    Console.WriteLine("Immediate Execution");
    int[] numbers = { 10, 20, 30, 40, 1, 2, 3, 8 };
    //get the first element in sequence order
    int number = (from i in numbers select i).First();
    Console.WriteLine("First is {0}", number);
    //get the first in query order
    number = (from i in numbers orderby i select i).First();
    Console.WriteLine("First is {0}", number);
    //get the one element  that matches the query
    number = (from i in numbers where i > 30 select i).Single();
    Console.WriteLine("Single is {0}", number);
    //Return null if nothing is returned
    number = (from i in numbers where i > 99 select i).FirstOrDefault();
    number = (from i in numbers where i > 99 select i).SingleOrDefault();
    try
    {
        //Throw an exception if no records returned
        number = (from i in numbers where i > 99 select i).First();
    }
    catch (Exception ex)
    {
        Console.WriteLine("An exception occurred: {0}", ex.Message);
    }
    try
    {
        //Throw an exception if no records returned
        number = (from i in numbers where i > 99 select i).Single();
    }
    catch (Exception ex)
    {
        Console.WriteLine("An exception occurred: {0}", ex.Message);
    }
    try
    {
        //Throw an exception if more than one element passes the query
        number = (from i in numbers where i > 10 select i).Single();
    }
    catch (Exception ex)
    {
        Console.WriteLine("An exception occurred: {0}", ex.Message);
    }
    // Get data RIGHT NOW as int[].
    int[] subsetAsIntArray =
      (from i in numbers where i < 10 select i).ToArray<int>();
    // Get data RIGHT NOW as List<int>.
    List<int> subsetAsListOfInts =
      (from i in numbers where i < 10 select i).ToList<int>();
}