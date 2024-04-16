namespace MethodParam2
{
    internal class OutDemo1
    {
        static void Main_outdemo1(string[] args)
        {
            Console.Write("Please input first number=>");
            string arg1 = Console.ReadLine();
            double x = 0;
            bool b1 = double.TryParse(arg1, out x);
            if (!b1)
            {
                Console.WriteLine("Input error!");
                return;
            }

            Console.Write("Please input second number=>");
            string arg2 = Console.ReadLine();
            double y = 0;
            bool b2 = double.TryParse(arg2, out y);
            if (!b2)
            {
                Console.WriteLine("Input error!");
                return;
            }

            Console.WriteLine("{0} + {1} = {2}", x, y, x + y);

        }
    }
}
