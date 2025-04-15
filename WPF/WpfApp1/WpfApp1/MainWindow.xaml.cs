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

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AboutDialog aboutDialog = new AboutDialog();
            aboutDialog.Show();
        }

        private void Button_on_click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("你好");
            //this.okButton = FindName("okButton") as Button;
            okButton.Content = "haha";
        }
    }
}
