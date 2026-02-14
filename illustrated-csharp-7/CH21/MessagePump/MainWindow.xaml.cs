using System.Windows;

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

        private async void btnDoStuff_Click(object sender, RoutedEventArgs e)
        {
            btnDoStuff.IsEnabled = false;   //禁用按鈕
            lblStatus.Content = "Doing Stuff";

            //Thread.Sleep(4000);   //以上所有消息在隊列中等待，然後在4000ms後全部執行
            await Task.Delay(4000); //利用線程延遲，消息隊列可以異步執行

            lblStatus.Content = "Not Doing Anything";
            btnDoStuff.IsEnabled = true;
        }
    }
}