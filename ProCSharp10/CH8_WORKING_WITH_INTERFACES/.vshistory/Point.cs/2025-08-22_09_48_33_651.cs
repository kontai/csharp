namespace SimpleInterfaces;
public class Point : ICloneable
{
    public int X { get; set; }
    public int Y { get; set; }

    public Point(int xPos, int yPos) { X = xPos; Y = yPos; }
    public Point() { }

    public override string ToString() => $"X = {X}; Y = {Y}";

    // 這裡實作 Clone()
    public object Clone() => new Point(this.X, this.Y);

    // 簡化版：用 MemberwiseClone()--SUSN
    //public object Clone() => this.MemberwiseClone();

}

