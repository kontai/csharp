using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp2
{
    public class MyButton:Button
    {
        public Type UserWindowType { get; set; }
        protected override void OnClick()
        {
            base.OnClick(); // Call the base class method
            if (Activator.CreateInstance(this.UserWindowType) is Window win)
            {
                win.ShowDialog();
            }
        }
    }
}