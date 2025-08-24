namespace ch2;

public class interface_demo
{
    static void Main(string[] args)
    {

        SubClass sc = new SubClass();
        sc.undo();
        ((IUndoable)sc).undo();
        ((BaseClass)sc).undo();
    }
}

 class BaseClass : IRedoable
{
    //public void undo() => Console.WriteLine("InterfaceDemo.Undo()");
    public virtual void undo()=> Console.WriteLine($"{nameof(BaseClass)}.Undo()");
}

class SubClass :BaseClass,  IUndoable
{
    public void undo() => Console.WriteLine("SubClass.Undo()");
}