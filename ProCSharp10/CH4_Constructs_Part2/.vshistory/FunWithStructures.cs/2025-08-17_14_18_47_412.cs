namespace CH4_Constructs_Part2;

public class FunWithStructures
{
    static void Main(string[] args)
    {
        Point p1 = new Point();
        p1.Increment();
        Console.WriteLine(p1);
    }

    struct Point
    {
        // Fields of the structure.
        public int X;

        public int Y;

        // Add 1 to the (X, Y) position.
        public void Increment()
        {
            X++;
            Y++;
        }

        // Subtract 1 from the (X, Y) position.
        public void Decrement()
        {
            X--;
            Y--;
        }

        // Display the current position.
        public void Display()
        {
            Console.WriteLine("X = {0}, Y = {1}", X, Y);
        }
    }
}