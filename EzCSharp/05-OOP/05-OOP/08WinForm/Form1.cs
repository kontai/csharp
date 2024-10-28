using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _05_OOP._08WinForm
{
    public partial class Form1 : Form
    {

        private int counter = 0;
        static void Main(string[] args)
        {
            Application.Run(new Form1());
            //Application.Run(new From1Extends());
        }
        /// <summary>
        /// 初始化所有控件
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();  //
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"counter = {counter++}");
            this.button1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.counter = 0;
            System.Console.Clear();
            this.button1.Enabled = true;
        }

        //Form1_Load 窗体所有的控件都被加载后触发的事件(通常不会用到)
        private void Form1_Load(object sender, EventArgs e)
        {
            //通常在構造函數中初始化所有控件
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("hello , world !");
        }

        private int mouse_enter_count = 0;
        private void button3_MouseEnter(object sender, EventArgs e)
        {
            if (mouse_enter_count > 10)
            {
                Application.Exit();
            }
            mouse_enter_count++;
            Console.WriteLine("偵測到滑鼠移入:{0}",mouse_enter_count);
        }
    }
}
