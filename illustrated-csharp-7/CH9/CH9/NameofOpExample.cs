/*
 *
 * nameof 運算式會將變數、型別或成員名稱產生為字串常數。
 * nameof 運算式會在編譯時間評估，在執行階段則不會有作用。
 * 當運算元是型別或命名空間時，產生的名稱不完整
 */

namespace CH9
{
    internal static class MyClass
    {
        public static void Method1()
        { }

        public static int Property1 { get; set; }
        public static int Field1;
    }

    public struct MyStruct
    {
        public int Value;
    }

    internal class NameofOpExample
    {
        public static void Main()
        {
            int parameter1 = 0;
            string var1 = "Local Variable";
            Console.WriteLine(nameof(var1));                //局部变量("var1")
            Console.WriteLine(nameof(MyClass));             //类("MyClass")
            Console.WriteLine(nameof(MyClass.Method1));     //公有方法("Method1")
            Console.WriteLine(nameof(parameter1));          //方法参数("parameter1")
            Console.WriteLine(nameof(MyClass.Property1));   //公有属性("Property1")
            Console.WriteLine(nameof(MyClass.Field1));      //公有字段("Field1")
            Console.WriteLine(nameof(MyStruct));            //结构体("MyStruct")
            Console.WriteLine(nameof(System.Math));         //打卬"Math"
            Console.WriteLine(nameof(Console.WriteLine));   //打卬"WriteLine"
        }
    }
}