namespace ch2;

public class interface_demo
{
    static void Main(string[] args)
    {
        //BaseClass bc = new BaseClass();
        //((IUndoable)bc).undo();

        SubClass sc = new SubClass();
        sc.undo();
        ((IUndoable)sc).undo();
        ((BaseClass)sc).undo();
    }
}

class BaseClass : IUndoable
{
    private static int hisCount=0;
    public BaseClass()
    {
        hisCount++; // Increment History count on instantiation
    }
    //public void undo() => Console.WriteLine("InterfaceDemo.Undo()");
    public void undo() => Console.WriteLine($"{nameof(BaseClass)}.Undo()");
    public static string num => "10";
    public static string History => $"{hisCount} History of BaseClass"; // Static property to get History count

    class SubClass : BaseClass, IUndoable
{
    public new void undo() => Console.WriteLine($"{nameof(SubClass)}.Undo()");
}