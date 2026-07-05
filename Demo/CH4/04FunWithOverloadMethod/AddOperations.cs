using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace _04FunWithOverloadMethod
{
    internal class AddOperations
    {
        //增加四個add重方法，分別處理int, double, string, char型態的參數
        public static int Add(int a, int b) => a + b;
        public static double Add(double a, double b) => a + b;
        public static string Add(string a, string b) => a + b;
        public static char Add(char a, char b) => (char)(a + b);

        //可選參數
        public static int Add(int a, int b, int c = 10) => a + b + c;

        //modifiler 參數
        public static int Add(ref int a) => a + 1;
        //public static int Add(out int a) => a + 1;  //修鉓符不能同時存在 

    }
}