using System;
using System.Collections.Generic;
using System.Text;

namespace _06enumDemo
{
    internal class bitWiseOperator
    {
        public void FunWithBitwise() //bitwise 位元運算
        {
            Console.WriteLine("===== Fun wih Bitwise Operations");
            //AND
            Console.WriteLine("4 & 6={0}|{1}", 4 & 6, Convert.ToString(4 & 6, 2));

            //OR
            Console.WriteLine("4 | 6={0}|{1}", 4 | 6, Convert.ToString(4 | 6, 2));

            //XOR
            Console.WriteLine("4 ^ 6={0}|{1}", 4 ^ 6, Convert.ToString(4 ^ 6, 2));

            //Flip
            Console.WriteLine("~4={0}|{1}", ~4, Convert.ToString(~4, 2));

            //Left shift
            Console.WriteLine("4 << 1={0}|{1}", 4 << 1, Convert.ToString(4 << 1, 2));

            //Right shift
            Console.WriteLine("4 >> 1={0}|{1}", 4 >> 1, Convert.ToString(4 >> 1, 2));

            //Int MaxValue
            Console.WriteLine("Int.MaxValue={0}|{1}", int.MaxValue, Convert.ToString(int.MaxValue, 2));
        }
    }
}

namespace FunWithBitwiseOperations
{
    [Flags]
    public enum ContactPreferenceEnum
    {
        None = 1,
        Email = 2,
        Phone = 4,
        Ponyexpress = 8
    }
}