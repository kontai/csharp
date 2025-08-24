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
using System.Xml;

namespace wpf_unleashed_demo
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            XamlReader reader = new XamlReader();
            reader.LoadCompleted += (s, e) => { Console.WriteLine("Loader"); };
            using (FileStream fs = new FileStream("MainWindow.xaml", FileMode.Open, FileAccess.Read))
            {
                reader.LoadAsync(fs);
            }

            var s1 = reader.ToString();
            Console.WriteLine(s1);


            //InitializeComponent();
        }
    }
}
