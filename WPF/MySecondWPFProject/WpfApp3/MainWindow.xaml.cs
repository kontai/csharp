using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfApp3
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // 准备数据源
            ObservableCollection<Student> stuList = new ObservableCollection<Student>()
            {
                new Student() { Id = 0, Name = "Tim", Age = 29 },
                new Student() { Id = 1, Name = "Tom", Age = 28 },
                new Student() { Id = 2, Name = "Kyle", Age = 27 },
                new Student() { Id = 3, Name = "Tony", Age = 26 },
                new Student() { Id = 4, Name = "Vina", Age = 25 },
                new Student() { Id = 5, Name = "Mike", Age = 24 },
            };

            // 为 ListBox 设置 Binding
            this.listBoxStudents.ItemsSource = stuList;
            //this.listBoxStudents.DisplayMemberPath = "Name";

            // 为 TextBox 设置 Binding
            //Binding binding = new Binding("SelectedItem.Id") { Source = this.listBoxStudents };
            //this.textBoxId.SetBinding(TextBox.TextProperty, binding);
            this.textBoxId.SetBinding(TextBox.TextProperty,
                new Binding("SelectedItem.Id") { Source = this.listBoxStudents });
        }
    }
}