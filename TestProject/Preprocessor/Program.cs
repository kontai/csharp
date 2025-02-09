#define RightHand
#define LeftHand

#pragma warning disable 1030 
#if RightHand && LeftHand
//指定程式碼的原始檔案名稱和行號。它通常用於編譯器或IDE中
//表示下一行程式碼的原始檔案是"abc.cs"，行號是55。
#line 55 "abc.cs"  
#error Both LeftHand and RightHand are defined
#endif

#warning Rember to come back and clean up this code!
namespace Preprocessor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("hello");
        }
    }
}
