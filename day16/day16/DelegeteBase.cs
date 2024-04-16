namespace DelegateExample
{
    internal class DelegateBase
    {
        public delegate int Calc(int a, int b);
        static void Main_(string[] args)
        {
            Calculator calculator = new Calculator();
            Calc calc1 = new Calc(calculator.Add);
            int x = 10;
            int y = 20;
            int z = 0;
            z = calc1.Invoke(x, y);
            Console.WriteLine(z);




        }
    }

    class Calculator
    {

        public int Add(int x, int y) { return x + y; }
        public int Sub(int x, int y) { return x - y; }
        public int Mul(int x, int y) { return x * y; }
        public int Div(int x, int y) { return x / y; }
    }
}
