namespace CH21.並行循環;

public class ParalleForeachExample
{
    public static void Main(string[] args)
    {
        string[] squares = new string[]
        {
            "We", "hold", "these", "truths", "to", "be", "self-evident", "that", "all", "men", "are", "created",
            "equal."
        };

        //with Parallel.ForEach
        //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
        Parallel.ForEach(squares, (s) => Console.WriteLine(
            string.Format($"\"{s}\" has {s.Length} letters")
        ));

        //with Parallel.For
        //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
        //Parallel.For(0, squares.Length, i => Console.WriteLine(
        //    string.Format($"\"{squares[i]} has {squares[i].Length} letters.\"")
        //));

    }
}