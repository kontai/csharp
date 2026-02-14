namespace CH11
{
    internal struct Point
    {
        public int x;
        public int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        //~Point()      //結構體不能有析構函數，但是可以有析構函數的參考
        //{
        //    Console.WriteLine("析構函數被調用");
        //}
    }

    internal class SimpleConstactorExample
    {
        public static void Main()
        {
            Point p1 = new Point();
            Point p2 = new Point(5, 6);
            Console.WriteLine(p1.x);
            Console.WriteLine($"{p2.x}, {p2.y}");

            Point p3;
            Point p4;
            //Console.WriteLine({p3.x});  未初始化的结构体不能访问成员
            p4.x = 12;
            p4.y = 13;
            Console.WriteLine($"{p4.x}, {p4.y}");
        }
    }
}