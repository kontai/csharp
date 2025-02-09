using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _02_BasicType
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Method1();
            //Method2();
            //Method3();
            //Method4();
            //Method5();
            //Method6();
        }

        #region 變量的定義基本規則
        static void Method1()
        {
            int courseId;   //聲明變量
            int age = 30;
            courseId = 50221;

            //通過字符串拼接輸出
            Console.WriteLine("Course Id=" + courseId + " Age=" + age);

            //通過佔位符格式化瑜出
            Console.WriteLine("Course Id={0} Age={1}", courseId, age);

            //使用4.6版本的語法糖 (前面加上$)   
            Console.WriteLine($"Course Id={courseId} Age={age}");

            //Console.Write - 不換行
            Console.Write("1");
            Console.Write("2 \r\n");
            Console.WriteLine("*******************************************");

            //從控制台輸入信息
            string name = Console.ReadLine();
            Console.WriteLine($"name={name}");

            //左值是字符串，則字符串與整數相加會自動轉換為字符串
            //左值是整數，則需要手動轉換
            age = int.Parse(Console.ReadLine());
            Console.WriteLine($"age={age}");

        }
        #endregion

        #region 變量義常見錯誤
        static void Method2()
        {
            //string 關鍵字是 String 的別名
            //因此，String 和 string 是相等的。

            //string teacher;  //預設值為null
            string teacher = null;
            //變量使用前，必須初始化(即使是null,也要明確賦值null)
            //Console.WriteLine($"Teacher name={teacher}");

            string student1;
            string student2 = null;
            //bool result1 = student1.Equals(student2);
            string student3 = string.Empty;
            string student4 = "";
            bool result2 = student2.Equals(student3);
            Console.WriteLine(result2);
        }


        #endregion

        #region 枚舉類型

        private enum Gender
        {
            Man = 0,
            Woman = 1
        }

        static void Method3()
        {
            Gender john = Gender.Man;
            Console.WriteLine(john);
            Console.WriteLine((int)john);
        }

        #endregion

        #region 強制類型篿換1:值類型之間

        static void Method4()
        {
            //static void Method7()
            //{
            //    double a = 10.25;
            //    int b = 20;
            //    int result = a + b;  //如果將result改為int類型，這樣就會出錯
            //    Console.WriteLine($"result={result}");
            //}

            Console.WriteLine(" \r\n【強制轉換1】：(類型名) 表達式  \r\n");
            double a = 10.25;
            int b = 20;
            int result = (int)a + b;  //實現強制類型轉換，但是精度會丟失
            Console.WriteLine($"【dobule-->目標int】10.25+20={result} 【精度會丟失】");

            a = 10.50;
            result = (int)a + b;       //實現強制類型轉換，但是精度會丟失
            Console.WriteLine($"【dobule-->目標int】10.50+20={result} 【精度會丟失】");

            a = 10.55;
            result = (int)a + b;         //實現強制類型轉換，但是精度會丟失
            Console.WriteLine($"【dobule-->目標int】10.55+20={result} 【精度會丟失】");

            Console.WriteLine("--------------------------------------------------");

            //特別的，object類型轉換成值類型也可以這樣「適當的」使用！
            object obj = 10.25; //這樣不行，應該是 object a = 10；也就是object類型轉換的時候，必須保證後面的類型和要轉換的「形式上」一致。
                                //  object a = 10;
            int num = 20;
            //int res= (int)obj + num;
            int red = (int)(double)obj + num;
            Console.WriteLine($"result={result}");
            Console.WriteLine("--------------------------------------------------");

        }

        #endregion

        #region 強制類型轉換2:字符串和值類型之間

        static void Method5()
        {
            Console.WriteLine(" \r\n【強制轉換2】：類型.Parse('字符串')  \r\n");
            //有效類型的【字符串】轉成【值類型】要求：字符串的格式必須符合目標類型的有效形式
            double a = double.Parse("20.5");
            float b = float.Parse("20.25");
            int c = int.Parse("20");

            //非有效形式：張三李四   20.2==>int


            //將值類型轉成字符串類型，直接使用ToString()方法
            string aa = a.ToString();
            string bb = b.ToString();
            string cc = c.ToString();
            string dd = c + "";

            Console.WriteLine($"a={aa},b={bb},c={cc},d={dd}");
            Console.WriteLine("--------------------------------------------------");
        }

        #endregion

        #region 強制類型轉換3:萬能轉換器

        static void Method6()
        {
            Console.WriteLine(" \r\n【強制轉換3】：Convert  \r\n");

            //字符類型的浮點數，轉換成正式的浮點數（完全符合我們正常的邏輯）
            double a = Convert.ToDouble("20.4");
            Console.WriteLine($"【字符串（string）-->值類型（double）】20.40=>{a} ");
            float b = Convert.ToSingle("19.55");
            Console.WriteLine($"【字符串（string）-->值類型（double）】19.55=>{b}");
            int c = Convert.ToInt32("20");
            Console.WriteLine($"【字符串（string）-->值類型（int）】20=>{c}");
            Console.WriteLine("--------------------------------------------------\r\n");

            //值類型之間（有一個特殊情況）
            int d = Convert.ToInt32(20.49);
            Console.WriteLine($"【值類型（double）-->值類型（int）】d=20.49=>轉為整數 {d} 捨掉");
            d = Convert.ToInt32(19.49);
            Console.WriteLine($"【值類型（double）-->值類型（int）】d=19.49=>轉為整數 {d} 捨掉");
            d = Convert.ToInt32(20.55);
            Console.WriteLine($"【值類型（double）-->值類型（int）】d=20.55=>轉為整數 {d} 進位");
            d = Convert.ToInt32(19.55);
            Console.WriteLine($"【值類型（double）-->值類型（int）】d=19.55=>轉為整數 {d} 進位");

            Console.WriteLine("\r\n----------------------【小數部分等於0.5的時候是特殊情況】----------------------\r\n");
            d = Convert.ToInt32(20.50);
            Console.WriteLine($"【值類型（double）-->值類型（int）】d=20.50=>轉為整數 {d} 捨掉");
            d = Convert.ToInt32(19.50);
            Console.WriteLine($"【值類型（double）-->值類型（int）】d=19.50=>轉為整數 {d} 進位  【特殊】：小數部分等於0.5的時候，看整數部分：奇進、偶不進");
            Console.WriteLine("--------------------------------------------------");


            //時間轉換
            DateTime dateTime = Convert.ToDateTime("2025-01-11");
            Console.WriteLine(" 【時間轉換】" + dateTime);
            Console.WriteLine("--------------------------------------------------");

            double f = Convert.ToDouble(20);
            Console.WriteLine($"【值類型（int）-->值類型（double）】f=20=>{f} 正常");
            Console.WriteLine("--------------------------------------------------");
        }

        #endregion

        #region 強制類型轉換中的特殊問題

        static void Method7()
        {
            //以下方法不行！
            //int a = int.Parse("35.8");
            //int b = Convert.ToInt32("35.8");

            Console.WriteLine("強制類型轉換中特殊問題的解決：");
            //通過中間轉換
            int a = (int)double.Parse("35.8");
            int b = (int)Convert.ToDouble("35.8");
            Console.WriteLine($"a=>35.8=>{a} b=>35.8=>{b}");
        }


        #endregion
    }

}
