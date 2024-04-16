namespace WindowsFormExampl
{
    public partial class MyForm : Form
    {
        public MyForm()
        {
            InitializeComponent();
            button1.Click += ButtonClickEvent;
            button2.Click += ButtonClickEvent;
        }

        private void Button2_Click(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ButtonClickEvent(object? sender, EventArgs e)
        {
            textBox1.Text = "hello world.";
            //throw new NotImplementedException();
        }

    }
}
