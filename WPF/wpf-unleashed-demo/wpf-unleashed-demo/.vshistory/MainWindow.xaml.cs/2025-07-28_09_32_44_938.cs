using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace wpf_unleashed_demo
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            XamlReader reader=new XamlReader();
            reader.LoadCompleted += (s, e) => { Console.WriteLine("Loaded!"); };
            using (FileStream fs = new FileStream("MyWindow.xaml", FileMode.Open, FileAccess.Read))
            {
                reader.LoadAsync(fs);
            }
        }
    }
}
