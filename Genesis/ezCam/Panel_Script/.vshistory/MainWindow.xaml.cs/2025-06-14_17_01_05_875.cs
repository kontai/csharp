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

namespace Panel_Script
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

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        private void s_ix(object sender, TextChangedEventArgs e)
        {
            var textChanges = e.Changes.Where(c => c.AddedLength > 0).ToList();
            Console.WriteLine(textChanges);
        }

        private void s_iy(object sender, TextChangedEventArgs e)
        {

        }

        private void w_ix(object sender, TextChangedEventArgs e)
        {

        }

        private void w_iy(object sender, TextChangedEventArgs e)
        {

        }

        private void x_step_num(object sender, TextChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void y_step_num(object sender, TextChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void x_step_spec(object sender, TextChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void y_step_spec(object sender, TextChangedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
