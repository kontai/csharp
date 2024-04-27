using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseClass;

namespace UserBaseClass
{
    class DerivedClass : MyBaseClass
    {
        static void Main(string[] args)
        {
            DerivedClass mdc = new DerivedClass();
            mdc.PrintMe();
        }
    }
}
