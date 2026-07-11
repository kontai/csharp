using System;
using System.Collections.Generic;
using System.Text;

namespace Employees
{
    //sealed 修AVN
    sealed class ptSalesPerson : SalesPerson
    {
        public ptSalesPerson()
        {
        }

        public ptSalesPerson(string name, int id, float pay, int age, int salesNumber) :
            base(name, id, pay, age, salesNumber)
        {
            Console.WriteLine("ptSalesPerson constructor called.");
        }
    }
}
