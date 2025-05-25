using System;
using System.Collections.Generic;
using System.Data;
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

namespace WpfApp5
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
/*            List<Student> stuList = new List<Student>()
            {
                new Student() { Id = 0, Name = "Tim", Age = 29 },
                new Student() { Id = 1, Name = "Tom", Age = 28 },
                new Student() { Id = 2, Name = "Kyle", Age = 27 },
                new Student() { Id = 3, Name = "Tony", Age = 26 },
                new Student() { Id = 4, Name = "Vina", Age = 25 },
                new Student() { Id = 5, Name = "Mike", Age = 24 },
            };

            this.listViewStudents.ItemsSource = from stu in stuList
                where stu.Name.StartsWith("T")
                select stu;
*/
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Age", typeof(int));

            dt.Rows.Add(0, "Tim", 29);
            dt.Rows.Add(1, "Tom", 28);
            dt.Rows.Add(2, "Kyle", 27);
            dt.Rows.Add(3, "Tony", 26);
            dt.Rows.Add(4, "Vina", 25);
            dt.Rows.Add(5, "Mike", 24);

            this.listViewStudents.ItemsSource = from DataRow row in dt.Rows
                where row["Name"].ToString().StartsWith("T")
                select new Student()
                {
                    Id = (int)row["Id"],
                    Name = row["Name"].ToString(),
                    Age = (int)row["Age"]
                };
        }
    }
}