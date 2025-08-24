namespace ch2;

public class interface_demo
{
    static void Main(string[] args)
    {
        IUndoable iundo = new InterfaceDemo();
        iundo.undo();

        SubClass sc = new SubClass();
        sc.undo();
        ((InterfaceDemo)sc).undo();
    }
}

class InterfaceDemo :IRedoable
{
    public virtual void  undo()=>Console.WriteLine("InterfaceDemo.Undo()");
}

class SubClass:InterfaceDemo
{
    public override void undo()=>Console.WriteLine("SubClass.Undo()");
}
