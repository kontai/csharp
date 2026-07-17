Shape circle = new Shape();
((ICircle)circle).draw();

internal interface ICircle
{
    void draw();
}

internal interface ISquare
{
    void draw();
}

internal interface ITriangle
{
    void draw();
}

internal class Shape : ICircle, ISquare, ITriangle
{
    void ICircle.draw() => Console.WriteLine("draw circle");

    void ISquare.draw() => Console.WriteLine("draw square");

    void ITriangle.draw() => Console.WriteLine("draw triangle");
}