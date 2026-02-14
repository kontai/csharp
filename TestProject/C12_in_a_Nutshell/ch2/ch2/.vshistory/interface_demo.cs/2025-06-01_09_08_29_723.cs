namespace ch2;

public class interface_demo
{
    static void Main(string[] args)
    {
        BaseClass bc = new BaseClass();
        ((IUndoable)bc).undo();

        SubClass sc = new SubClass();
        sc.undo();
        ((IUndoable)sc).undo();
    }
}

class BaseClass : IUndoable
{
    //public void undo() => Console.WriteLine("InterfaceDemo.Undo()");
    public void undo() => Console.WriteLine($"{nameof(BaseClass)}.Undo()");
}

class SubClass : BaseClass, IUndoable
{
    public void undo() => Console.WriteLine($"{nameof(SubClass)}.Undo()");
}