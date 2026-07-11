Shape c = new Circle();
Shape r = new Rectangle();
c.Show();

Console.WriteLine(c is Shape);
Console.WriteLine(c as Shape);

Console.WriteLine(r is Shape);
Console.WriteLine(r as Shape);

Console.WriteLine(c.GetType());
Console.WriteLine(r.GetType());

Console.WriteLine(c.num);

Console.WriteLine(c.GetHashCode());

abstract class Shape
{
    public int num = 20;

    //抽象方法只能定义在抽象类中
    abstract public void Show();
    virtual public void Foo()
    {
        Console.WriteLine("Shape foo");
    }

}

class Circle : Shape
{
    public int num = 30;

    //抽象方法必须被重写
    public override void Show()
    {
        Console.WriteLine("Circle");
    }

    public new void Foo()
    {
        Console.WriteLine("Circle foo");
    }

}

class Rectangle : Shape
{
    public override void Show()
    {
        Console.WriteLine("Rectangle");
    }
}