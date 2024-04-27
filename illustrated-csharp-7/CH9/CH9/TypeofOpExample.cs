using System.Reflection;

namespace CH9
{
    internal class SomeClass
    {
        public int Field1;
        public int Field2;

        public void Method1()
        { }

        public int Method2()
        { return 1; }
    }

    internal class TypeofOpExample
    {
        public static void Main()
        {
            Type t = typeof(SomeClass);
            FieldInfo[] fi = t.GetFields();
            MethodInfo[] mi = t.GetMethods();

            foreach (FieldInfo f in fi)
            {
                Console.WriteLine($"Field: {f.Name}, {typeof(f.Name)}");
            }

            foreach (MethodInfo m in mi)
            {
                Console.WriteLine($"Method: {m.Name}");
            }
        }
    }
}