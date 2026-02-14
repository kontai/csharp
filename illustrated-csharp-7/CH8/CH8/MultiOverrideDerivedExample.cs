using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace CH8
{
    internal class MultiOverrideDerivedExample
    {
        public static void Main(string[] args)
        {
            SecondDerivedClass derived = new SecondDerivedClass();
            MyBaseClass baseClass = derived;

            derived.Print();
            baseClass.Print();
        }

        class MyBaseClass
        {
            public virtual void Print()
            {
                Console.WriteLine("This is the base class");
            }
        }

        class MyDerivedClass : MyBaseClass
        {
            public override void Print()
            {
                Console.WriteLine("This is the derived class");
            }
        }

        class SecondDerivedClass : MyDerivedClass
        {
            /// <summary>
            /// 情況一:使用override聲明Print
            /// 當 使 用 對 象 基 類 部 分 的 引 用 調 用 一 個 被 覆 寫 的 方 法 時 , 方 法 的 調 用 被 沿 派 生 層 次 上 溯 執行 , 一 直 到 標 記 為 override 的 方 法 的 最 高 派 生(most-derived ) 版 本 。
            /// 如 果 在 更 高 的 派 生 級 別 有 該 方 法 的 其 他 聲 明 , 但 沒 有 被 標 記 為 override, 那 麼 它 們 不 會
            /// 被 調 用 。
            ///
            /// 情克二:使用new聲明Print
            /// new聲明Print 不會沿派生層次上繼承執行,而是直接執行
            /// </summary>
            //public override void Print()
            //{
            //    Console.WriteLine("This is the second derived class");
            //}

            public new void Print()
            {
                Console.WriteLine("This is the second derived class");
            }
        }
    }
}
