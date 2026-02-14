namespace FunWithMethodOverloading
{
    // C# code.
    // Overloaded Add() method.
    public static class AddOperations
    {
        // Overloaded Add() method.
        public static int Add(int x, int y)
        {
            return x + y;
        }

        public static double Add(double x, double y)
        {
            return x + y;
        }

        public static long Add(long x, long y)
        {
            return x + y;
        }

        //與 int Add(int x, int y)重罍;Add(1,2)會優先匹配int Add(int x,int y),因為完全匹配
        public static int Add(int x, int y, int z = 0)
        {
            return x + (y * z);
        }

        //public static int Add(ref int x)
        //{
        //    return x;
        //}
            //不能只以in,out,ref等引用重載
        //public static int Add(out int x)
        //{
        //    x = 1;
        //    return x;
        //}

    }
}