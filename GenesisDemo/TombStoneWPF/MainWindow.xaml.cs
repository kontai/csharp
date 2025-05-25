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

namespace TombStoneWPF
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        private TombStone p;

        public MainWindow()
        {
            InitializeComponent();
            this.Trim_Size.Text = "0.0";
            this.Keep_Clearance.Text = "0.0";
        }

        private void Button_Exit(object sender, RoutedEventArgs e)
        {
            //關閉視窗
            Close();
        }

        private void Button_Run(object sender, RoutedEventArgs e)
        {
            p = new TombStone();
            string item1 = this.Trim_Size.GetLineText(0);
            string item2 = this.Keep_Clearance.GetLineText(0);
            double trim_size = 0.0;
            double ts_size = 0.0;
            while (true)
            {
                if (double.TryParse(item1, out trim_size) && (double.TryParse(item2, out ts_size)))
                {
                    p.tomb_stone(trim_size, ts_size);
                    break;
                }
                else
                {
                    this.msg.Text = "請輸入正確的數字";
                }
            }

            MessageBox.Show("已完成,請再核對.");
        }
    }
}