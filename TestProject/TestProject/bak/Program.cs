internal abstract class MyBase
{
    public int val = 20;

    public virtual void Method()
    {
        Console.WriteLine("This is my base class");
    }

    abstract public void Func();
}

internal class ClassA : MyBase
{
    public int val = 30;

    public void show()
    {
        Console.WriteLine("Mybase val: {0}", base.val);
        Console.WriteLine("ClassA val: {0}", val);
    }

    public override void Method()
    {
        Console.WriteLine("This is my class A");
    }

    public override void Func()
    {
        Console.WriteLine("Class A abstract override method.");
    }
}

internal class ClassB : ClassA
{
    public int val = 30;

    public void show()
    {
        Console.WriteLine("Mybase val: {0}", base.val);
        Console.WriteLine("ClassA val: {0}", val);
    }

    public void Method()
    {
        Console.WriteLine("This is my  class B");
    }
    public void Func()
    {
        Console.WriteLine("Class B abstract override method.");
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        var oc = new ClassB();
        MyBase mb = oc;
        //oc.Method();

        //MyBase amb=new MyBase();  //抽象類別不能實例化

        //引用类型调用虚方法时，会调用子类的重写方法
        //多繼承的情怳下，將調用最後一個使用override闗鍵字的子類方法
        //mb.Method();
        mb.Func();

    }
}