namespace CH5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //創建兩個實例
            DayTemp t1 = new DayTemp();
            DayTemp t2 = new DayTemp();

            //給字段賦值
            t1.High = 76;
            t1.Low = 57;
            t2.High = 75;
            t2.Low = 53;

            //讀取字段值
            //調用實例的方法
            Console.WriteLine("t1: {0}, {1}, {2}", t1.High, t1.Low, t1.Average());
            Console.WriteLine("t2: {0}, {1}, {2}", t2.High, t2.Low, t2.Average());



        }

        class DayTemp
        {

            public int High, Low;
            public int Average()
            {
                return (High + Low) / 2;
            }
        }
    }
}
