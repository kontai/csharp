using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    public class MyButton : Button
    {
        public Type UserWindowType { get; set; }
        protected override void OnClick()
        {
            base.OnClick();
            Window win = Activator.CreateInstance(this.UserWindowType) as Window;
            if (win != null)
            {
                win.ShowDialog();
            }
        }
    }
}