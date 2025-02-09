using System.Runtime.InteropServices;

namespace TestProject;

class X
{
    private string name;
    private int age;


    //命名參數
    public void calc(int x = 2)
    {
        int number = x * 2;
        Console.WriteLine(number);
    }

    public int getAge()
    {
        return age;
    }

    public int Age
    {
        set
        {
            age = value;
        }
        get { return age; }
    }
}
public class Demo01
{
    static void Main(string[] args)
    {
        X x1 = new X();
        //x1.calc(20);
        //x1.calc();
        x1.Age = 20;
        Console.WriteLine(x1.Age);
        Console.WriteLine(x1.getAge());
    }
}