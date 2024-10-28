using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_OOP._02read_only
{
    internal class TestClass
    {
        static void Main2(string[] args)
        {
            Person person = new Person();
            Console.WriteLine("Name:{0} Age:{1}",person.Name, person.Age);

            //read only peroperty
            //person.Name = "jason";
            //person.Age = 10;
        }
    }
}
