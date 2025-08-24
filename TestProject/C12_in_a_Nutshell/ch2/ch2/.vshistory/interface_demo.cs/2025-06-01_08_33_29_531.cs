namespace ch2;

public class interface_demo
{
    static void Main(string[] args)
    {
        IUndoable iundo = new InterfaceDemo();
        iundo.undo();

        SubClass sc = new SubClass();
        sc.undo();
    }
}

class InterfaceDemo : IRedoable
{
    void IUndoable.undo() => Console.WriteLine("InterfaceDemo.Undo()");
}

class SubClass : InterfaceDemo, IUndoable
{
    public void undo() => Console.WriteLine("SubClass.Undo()");
}