using _07SturctorDemo;

Point p = new Point(10, 20);
p.Display();

ReadOnlyPoint rp = new ReadOnlyPoint(1, 2);
rp.Display();
//rp.X = 10; //Error, because it is read-only

using var dp = new disposePoint(22, 33); //using statement

ValueTypeContainingRefType();

static void ValueTypeContainingRefType()
{
    // Create the first Rectangle.
    Console.WriteLine("-> Creating r1");
    Rectangle r1 = new Rectangle("First Rect", 10, 10, 50, 50);
    // Now assign a new Rectangle to r1.
    Console.WriteLine("-> Assigning r2 to r1");
    Rectangle r2 = r1;
    // Change some values of r2.
    Console.WriteLine("-> Changing values of r2");
    r2.RectInfo.InfoString = "This is new info!";
    r2.RectBottom = 4444;
    // Print values of both rectangles.
    r1.Display();
    r2.Display();
}