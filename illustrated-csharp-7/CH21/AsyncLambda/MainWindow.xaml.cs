using System.Globalization;
using System.Runtime.InteropServices.JavaScript;
using System.Windows;

namespace AsyncLambda
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //異步Lambda表達式，將DoSomeWork()方法委派給一個Task，然後等待Task完成後，再更新GUI元件，以此來表示工作開始或工作完成
            startWorkButton.Click += async (sender, e) =>
            {
                SetGuiValues(false, "Work Started");
                await DoSomeWork();
                SetGuiValues(true, "Work Finished");
            };
        }

        private void SetGuiValues(bool buttonEnabled, string status)
        {
            startWorkButton.IsEnabled = buttonEnabled;
            workStartedTextBlock.Text = status;
        }

        private Task DoSomeWork()
        {
            return Task.Delay(2500);
        }
    }
}