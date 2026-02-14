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

namespace WpfApp4
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Add 4 columns
            for (int i = 0; i < 4; i++)
            {
                this.gridMain.ColumnDefinitions.Add(new ColumnDefinition());
            }

            //Add 3 Rows
            for (int i = 0; i < 3; i++)
            {
                this.gridMain.RowDefinitions.Add(new RowDefinition());
            }

            //Show grid line in runtime
            this.gridMain.ShowGridLines = true;
        }


    }
}
