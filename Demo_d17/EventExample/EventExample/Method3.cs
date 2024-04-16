using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventExample
{
    internal class Method3
    {
        public static void Main(string[] args)
        {
            MyForm form = new MyForm();
            form.ShowDialog();
        }

    }

    class MyForm : Form
    {
        private TextBox textBox;
        private Button button;

        public MyForm()
        {
            Button button2 = new Button();
            this.textBox = new TextBox();
            this.button = new Button();
            this.Controls.Add(this.button);
            this.Controls.Add(this.textBox);
            this.button.Click += this.ButtonClicked;
            this.button.Text = "say hello";
            this.button.Top = 100;
        }

        private void ButtonClicked(object? sender, EventArgs e)
        {
            this.textBox.Text = "Hello,world~~~~~~~~~~~~~~~~";
            Console.WriteLine($"sender = {sender}");
            Console.WriteLine($"EventArgs = {e}");

        }
    }
}
