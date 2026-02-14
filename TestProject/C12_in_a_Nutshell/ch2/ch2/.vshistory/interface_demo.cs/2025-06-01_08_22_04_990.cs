namespace ch2;

public class interface_demo
{
    static void Main(string[] args)
    {
        IUndoable iundo = new InterfaceDemo();
        iundo.undo();
    }
}

class InterfaceDemo :IRedoable
{
    public void undo()
    {
        Console.WriteLine("InterfaceDemo.Undo()");
    }
}

class SubClass:InterfaceDemo
{
    public  void undo()
    {
        Console.WriteLine("SubClass.Undo()");
    }
}
