namespace ch2;

public class deconstruct_demo
{
    static void Main(string[] args)
    {
        Rectangle rec = new Rectangle(29, 30);
        (int w, int h) = rec;
        Console.WriteLine($"w:{w},h:{h}");

    }

}

public class Rectangle
{
    public int Width { get; set; }
    public int Height { get; set; }
    public Rectangle(int width, int height)
    {
        Width = width;
        Height = height;
    }
    // Deconstruct method
    public void Deconstruct(out int width, out int height)
    {
        width = Width;
        height = Height;
    }
}