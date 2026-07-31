using SimpleMath;

BinaryOps op = new BinaryOps(SimpleMath.SimpleMath.Add);
op += SimpleMath.SimpleMath.Sub;
DisplayDelegateInfo(op);

//BinaryOps op2=new BinaryOps(SimpleMath.SimpleMath.SquareNumber);

static void DisplayDelegateInfo(Delegate delobj)
{
    foreach (Delegate d in delobj.GetInvocationList())
    {
        Console.WriteLine("Method Name: {0}", d.Method);
        Console.WriteLine("Type Name: {0}", d.Target);
    }
}