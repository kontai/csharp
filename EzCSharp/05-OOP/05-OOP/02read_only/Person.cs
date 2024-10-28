using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_OOP._02read_only
{
    internal class Person
    {
        //唯讀屬性(無法修改)
        public string Name { get;  }="tai";
        public int Age { get; }=20;
    }
}
