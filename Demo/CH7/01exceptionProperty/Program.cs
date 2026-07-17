Console.WriteLine("*** fun with exception ***");
try
{
    cntFun();
}
catch (DivideByZeroException e)
{
    //為oncole上色
    Console.WriteLine("Exception caught: {0}", e);
    Console.WriteLine(nameof(e));   // 顯示變量名稱
    Console.WriteLine("Method: {0}", e.TargetSite);
    Console.WriteLine("TargetSite.DeclearedType: {0}",e.TargetSite.DeclaringType);
    Console.WriteLine("TargetSite.MemberType: {0}",e.TargetSite.MemberType);
    Console.WriteLine("Message: {0}", e.Message);
    Console.WriteLine("Source: {0}", e.Source);
    Console.WriteLine("求救網址: {0}",e.HelpLink);
}

static void cntFun()
{
    int i = 0;
    int j = 1;
    int k = j / i;
}


[Serializable]
public class MyException : ApplicationException
{
    public MyException() { }
    public MyException(string message) : base(message) { }
    public MyException(string message, Exception inner) : base(message, inner) { }
    protected MyException(
      System.Runtime.Serialization.SerializationInfo info,
      System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}
