namespace DelegetExample
{
    internal class Program
    {
        static void Main_exp1(string[] args)
        {
            Calculator calculator = new Calculator();
            Action action = new Action(calculator.Report);
            action.Invoke();    //調用靜態方法
            action();           //簡便方法(模仿函數指針)


            Func<int, int, int> func1 = new Func<int, int, int>(calculator.Add);
            Func<int, int, int> func2 = new Func<int, int, int>(calculator.Sub);
            int x = 10;
            int y = 20;
            var res1 = func1(20, 40);
            var res2 = func2(20, 40);
            Console.WriteLine(res1);
            Console.WriteLine(res2);
        }
    }

    class Calculator
    {
        public void Report()
        {
            Console.WriteLine("I have 3 methods.");
        }

        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Sub(int a, int b)
        {
            return a - b;
        }
    }
}
