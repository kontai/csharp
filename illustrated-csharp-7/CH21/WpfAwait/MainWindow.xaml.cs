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

namespace WpfAwait
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CancellationTokenSource cancellationTokenSource;
        private CancellationToken cancellationToken;

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void btnProcess_Click(object sender, RoutedEventArgs e)
        {
            btnProcess.IsEnabled = false;

            cancellationTokenSource = new CancellationTokenSource();
            cancellationToken = cancellationTokenSource.Token;

            int completedPercent = 0;
            for (int i = 0; i < 10; i++)
            {
                if (cancellationToken.IsCancellationRequested)  //判斷是否已經取消
                {
                    break;
                }

                try
                {
                    await Task.Delay(500, cancellationToken);   //(可取消)模擬進度條,20% per 500ms
                    completedPercent = (i + 1) * 10;
                    progressValues.Content = $"{completedPercent}%";
                }
                catch (TaskCanceledException ex)
                {
                    completedPercent = i * 10;
                }

                progressBar.Value = completedPercent;
            }

            string message = cancellationToken.IsCancellationRequested ?
                string.Format($"Process was cancelled at {completedPercent}%") :
                "Process completed normally";
            MessageBox.Show(message, "Completion Status");
            progressBar.Value = 0;
            btnProcess.IsCancel = true;
            btnCancel.IsCancel = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (!btnProcess.IsEnabled)
            {
                btnCancel.IsEnabled = false;
                cancellationTokenSource.Cancel();
                btnCancel.IsEnabled = true;
                progressBar.IsEnabled = true;
            }
        }
    }
}