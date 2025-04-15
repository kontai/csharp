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

namespace WpfApp3
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Employee> empList = new List<Employee>()
        {
            new Employee() { id = 1, Name = "Tim", Age = 30 },
            new Employee() { id = 2, Name = "Tom", Age = 20 },
            new Employee() { id = 3, Name = "Guo", Age = 26 },
            new Employee() { id = 4, Name = "Yan", Age = 25 },
            new Employee() { id = 5, Name = "Owen", Age = 30 },
            new Employee() { id = 6, Name = "Victor", Age = 30 },
        };

        public MainWindow()
        {
            InitializeComponent();
            this.listBoxEmplyee.DisplayMemberPath = "Name";
            this.listBoxEmplyee.SelectedValuePath = "id";
            this.listBoxEmplyee.ItemsSource = empList;
        }
    }
}