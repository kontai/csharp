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

 class BaseClass :IUndoable 
{
    //public void undo() => Console.WriteLine("InterfaceDemo.Undo()");
      void IUndoable.undo()=> Console.WriteLine($"{nameof(BaseClass)}.Undo()");
}

class SubClass :BaseClass
{
    public  void undo() => Console.WriteLine($"{nameof(SubClass)}.Undo()");
}