using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventExample
{
    internal class Method2
    {
        public static void Main(string[] args)
        {
            MyForm form = new MyForm();
            form.Click += form.FormClicked;
            form.ShowDialog();
        }
    }

    class MyForm : Form
    {
        public void FormClicked(object? sender, EventArgs e)
        {
            this.Text = DateTime.Now.ToString();
        }
    }
}
