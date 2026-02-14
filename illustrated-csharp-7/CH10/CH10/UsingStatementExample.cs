namespace CH10
{
    internal class UsingStatementExample
    {
        public static void Main()
        {
            using (TextWriter tw1 = File.CreateText("Lincolin.text"),
                                                tw2 = File.CreateText("Franklin.text"))     //多個資源以逗號隔開
            {
                tw1.WriteLine("Four score and seven years ago....");
                tw2.WriteLine("Early to bed; Early to rise....");
                using (TextWriter tw3 = File.CreateText("Lincolin2.text"))      //資源可以嵌套
                {
                    tw3.WriteLine("eeeeeeee");
                }
            }

            using (TextReader tr1 = File.OpenText("Lincolin.text"),
                                           tr2 = File.OpenText("Franklin.text"))
            {
                string InputString;
                while ((InputString = tr1.ReadLine()) != null)
                {
                    Console.WriteLine(InputString);
                }

                while ((InputString = tr2.ReadLine()) != null)
                {
                    Console.WriteLine(InputString);
                }
            }
            File.Delete("Lincolin.text");        //將Lincolin.text刪除
            File.Delete("Franklin.text");        //將Franklin.text刪除
        }
    }
}