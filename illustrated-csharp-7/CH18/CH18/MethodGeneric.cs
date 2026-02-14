namespace CH18;

class MyClass
{
    public void MyMethod<T>(T myVal) { Console.WriteLine(myVal); }
}

public class MethodGeneric
{

    static void Main(string[] args)
    {

        MyClass myClass = new MyClass();
        myClass.MyMethod<int>(20);
        myClass.MyMethod(20);    //編譯器由方法參數得知參數類型，便不需提供類型參數
    }

}