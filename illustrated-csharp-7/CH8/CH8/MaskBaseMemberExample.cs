namespace CH8
{
    internal class MaskBaseMemberExample
    {

        static void Main()
        {
            OtherClass oc = new OtherClass();   //使用屏蔽成员
            oc.Method1(oc.Field1);              //使用屏蔽成员
        }

    }
    class SomeClass
    //基类
    {
        public string Field1 = "SomeClass Field1";
        public void Method1(string value)
        {
            Console.WriteLine($"SomeClass.Method1: {value}");
        }
    }
    class OtherClass : SomeClass //派生类
    {
        public new string Field1 = "OtherClass Field1";      //屏蔽基类成员 
        public new void Method1(string value)   //屏蔽基类成员
        {
            Console.WriteLine($"OtherClass.Method1: {value}");
            base.Method1(base.Field1);      //訪問被遮蔽的成员與方法
        }
    }

}
