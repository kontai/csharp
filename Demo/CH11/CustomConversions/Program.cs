using CustomConversions;
Console.WriteLine("***** Fun with Conversions *****\n");
// Make a Rectangle.
Rectangle r = new Rectangle(15, 4);
Console.WriteLine(r.ToString());
r.Draw();
Console.WriteLine();
// Convert r into a Square,
// based on the height of the Rectangle.
Square s = (Square)r;
Console.WriteLine(s.ToString());
s.Draw();

//Convert Rectangle to Square to invoke method
DrawSquare((Square)r);

Square s2 = (Square)10;
int SquareLen = s2.Length;

// Convert Square to Rectangle
Rectangle r2 = s2;
Rectangle r3 = (Rectangle)s2;



// This method requires a Square type.
static void DrawSquare(Square sq)
{
    Console.WriteLine(sq.ToString());
    sq.Draw();
}