namespace CH6
{
    internal class LocalFunctionExample
    {
        static void Main(string[] args)
        {
            //Program program = new Program();
            //program.MethodWithLocalFunction();
            MethodWithLocalFunction();
        }
        static public void MethodWithLocalFunction()
        {
            int MyLocalFunction(int zi)
            {
                return zi * 5;
            }

            int results = MyLocalFunction(5);     //調用局部函數
            Console.WriteLine($"Results of local function call: {results}");

        }

    }


}
