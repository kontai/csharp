﻿using System;
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
using System.Xml;

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


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            XmlDataProvider xdp=new XmlDataProvider();
            xdp.Source = new Uri(@"d:\RawData.xml");
            xdp.XPath = @"StudentList/Student";

            xdp.XPath = @"/StudentList/Student";

            this.listViewStudent.DataContext = xdp;
            this.listViewStudent.SetBinding(ListView.ItemsSourceProperty, new Binding());
        }
    }
}
