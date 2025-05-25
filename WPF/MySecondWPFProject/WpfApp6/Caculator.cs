using System;
using System.Windows.Navigation;

namespace WpfApp6
{
    public class Calculator
    {
        public string Add(string a, string b)
        {
            double x = 0;
            double y = 0;
            double z = 0;
            if (double.TryParse(a, out x) && double.TryParse(b, out y))
            {
                z = x + y;
                return z.ToString();
            }

            return "input error";
        }
    }
}