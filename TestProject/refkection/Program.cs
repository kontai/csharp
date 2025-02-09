using System.Collections.Specialized;
using System.Data;

namespace reflection
{
    internal class Program
    {
        class BaseClass
        {
            public int BaseField = 0;
        }

        class DerivedClass : BaseClass
        {
            public int DerivedField = 0;
        }
        static void Main(string[] args)
        {

            var bf = new BaseClass();
            var df = new DerivedClass();

            BaseClass[] bcs = new BaseClass[] { bf, df };

            foreach (var baseClass in bcs)
            {
                //Type type = baseClass.GetType();
                Type type = typeof(BaseClass);
                Console.WriteLine($"Object type: {type.Name}");

                var fi = type.GetFields();
                foreach (var f in fi)
                {
                    Console.WriteLine($"    Field:{f.Name}");
                }
            }

            Console.WriteLine("Hello, World!");
        }
    }
}
