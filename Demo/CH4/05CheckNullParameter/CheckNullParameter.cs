namespace CheckNullParameter
{
    class Fun1
    {
        public static void MyFun(string message, string owner = "Programmer")
        {
            //if (message == null)
            //{
            //    throw new ArgumentNullException("參數不能為null");
            //}
            ArgumentNullException.ThrowIfNull("參數不能為null");

            Console.WriteLine("Error{0}", message);
            Console.WriteLine("Owner of Error: {0}", owner);
        }
    }
}