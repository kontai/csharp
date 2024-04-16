
using System.Security.Cryptography.X509Certificates;

namespace EventExample
{
    internal class Method1
    {
        static void Main(string[] args)
        {
            Form form= new Form();
            Controller controller = new Controller(form);
            form.ShowDialog();
            
        }
    }

    class Controller
    {
        private Form form;
        public Controller(Form form) {
            if (form != null)
            {
                this.form = form;
               this.form.Click += this.ClickEvent;
            }
        }

        private void ClickEvent(object? sender, EventArgs e)
        {
            //throw new NotImplementedException();
            this.form.Text = DateTime.Now.ToString();
            
        }
    }
}
