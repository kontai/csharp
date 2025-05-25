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

namespace MySecondWPFProject
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        private Student stu;

        public MainWindow()
        {
            InitializeComponent();

            this.textBoxName.SetBinding(TextBox.TextProperty, new Binding("Name") { Source = stu = new Student() });
            //stu = new Student();


            ////準備Binding
            //Binding binding = new Binding();
            //binding.Source = stu;
            //binding.Path = new PropertyPath("Name");

            ////設定Binding的Mode
            //BindingOperations.SetBinding(this.textBoxName, TextBox.TextProperty, binding);
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            stu.Name += "Name";
        }
    }
}