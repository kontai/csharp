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

namespace DataGridDemo
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<DrillInfo> drillInfos = new List<DrillInfo>
            {
                new DrillInfo { TOOLS = 1, Finish_size = 0.5, Type = "Type1", Shape = "Shape1", Count = 10 },
                new DrillInfo { TOOLS = 2, Finish_size = 0.75, Type = "Type2", Shape = "Shape2", Count = 20 },
                new DrillInfo { TOOLS = 3, Finish_size = 1.0, Type = "Type3", Shape = "Shape3", Count = 30 }
            };

            dgDrillInfo.ItemsSource = drillInfos;
        }
    }

    public class DrillInfo
    {
        public int TOOLS { get; set; }
        public double Finish_size { get; set; }
        public string Type { get; set; }
        public string Shape { get; set; }
        public decimal Count { get; set; }
    }
}