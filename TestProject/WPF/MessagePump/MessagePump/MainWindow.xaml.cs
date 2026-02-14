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

namespace MessagePump
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private async void BtnDoStuff_Click(object sender, RoutedEventArgs e)
        {
            btnDoStuff.IsEnabled = false;   // disable the button
            lblStatus.Content="Doing Stuff..."; // change the label
            //Thread.Sleep(4000); // simulate some work
            await Task.Delay(4000);
            lblStatus.Content = "Not Doing Anything";   // change the label
            btnDoStuff.IsEnabled = true;    // enable the button
        }
    }
}