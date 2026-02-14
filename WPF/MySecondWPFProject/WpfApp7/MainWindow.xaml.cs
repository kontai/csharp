using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp7
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //RelativeSource rs=new RelativeSource(RelativeSourceMode.FindAncestor);
            //rs.AncestorLevel = 2;
            //rs.AncestorType = typeof(Grid);

            RelativeSource rs = new RelativeSource();
            rs.Mode= RelativeSourceMode.Self;

            Binding binding=new Binding("Name"){RelativeSource = rs};
            this.textBox1.SetBinding(TextBox.TextProperty, binding);
        }
    }
}
