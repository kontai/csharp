namespace ch2;

public class interface_demo
{
    static void Main(string[] args)
    {
        //IUndoable iundo = new InterfaceDemo();
        //iundo.undo();

        SubClass sc = new SubClass();
        sc.undo();
        ((IUndoable)sc).undo();
    }
}

 class InterfaceDemo : IRedoable
{
    //public void undo() => Console.WriteLine("InterfaceDemo.Undo()");
    public virtual void undo()=> Console.WriteLine("InterfaceDemo.Undo()");
}

class SubClass :  IUndoable
{
    public void undo() => Console.WriteLine("SubClass.Undo()");
}