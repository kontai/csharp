using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH7
{
    internal class SetterAndGetter
    {
        public static void Main()
        {
            Person p = new Person("Capt. Ernest Evans");
            Console.WriteLine($"Person name is {p.Name}");
        }


    }

    class Person
    {
        public Person(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}
