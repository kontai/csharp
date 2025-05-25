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

namespace WpfApp6
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.SetBinding();
        }

        private void SetBinding()
        {
            ObjectDataProvider odp = new ObjectDataProvider();

            odp.ObjectType = typeof(Calculator);
            //odp.ObjectInstance = typeof(Calculator);
            odp.MethodName = "Add";

            odp.MethodParameters.Add("0");
            odp.MethodParameters.Add("0");

            Binding bindingToArg1 = new Binding("MethodParameters[0]")
            {
                Source = odp,
                BindsDirectlyToSource = true,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            };

            Binding bindingToArg2 = new Binding("MethodParameters[1]")
            {
                Source = odp,
                BindsDirectlyToSource = true,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            };

            Binding bindingToResult = new Binding(".") { Source = odp };

            this.textBoxArg1.SetBinding(TextBox.TextProperty, bindingToArg1);
            this.textBoxArg2.SetBinding(TextBox.TextProperty, bindingToArg2);
            this.textBoxResult.SetBinding(TextBox.TextProperty, bindingToResult);
        }
        // private void Button_Click(object sender, RoutedEventArgs e)
        // {
        //     ObjectDataProvider odp=new ObjectDataProvider();
        //     odp.ObjectInstance = new Calculator();
        //     odp.MethodName = "Add";
        //     odp.MethodParameters.Add("100");
        //     odp.MethodParameters.Add("200");
        //     MessageBox.Show(odp.Data.ToString());
        // }
    }
}