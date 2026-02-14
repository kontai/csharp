using System.ComponentModel;
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

namespace SimpleWorker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BackgroundWorker bgWorker = new BackgroundWorker();

        public MainWindow()
        {
            InitializeComponent();

            //設置BackgeroudWorker屬性
            bgWorker.WorkerReportsProgress = true;
            bgWorker.WorkerSupportsCancellation = true;

            //連接BackgeroundWorker對象的處理程序
            bgWorker.DoWork += DoWork_Handler;
            bgWorker.ProgressChanged += ProgressChanged_Handler;
            bgWorker.RunWorkerCompleted += RunWorkerCompleted_Handler;
        }


        private void ProgressChanged_Handler(object? sender, ProgressChangedEventArgs args)
        {
            progressBar.Value = args.ProgressPercentage;
        }

        private void DoWork_Handler(object? sender, DoWorkEventArgs args)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            for (int i = 0; i < 10; i++)
            {
                if (worker.CancellationPending)
                {
                    args.Cancel = true;
                    break;
                }
                else
                {
                    worker.ReportProgress(i * 10);
                    Thread.Sleep(500);
                }
            }
        }

        private void btnProcess_Click(object sender, RoutedEventArgs e)
        {
            if (!bgWorker.IsBusy)
            {
                bgWorker.RunWorkerAsync();
            }
        }

        private void RunWorkerCompleted_Handler(object? sender, RunWorkerCompletedEventArgs args)
        {
            progressBar.Value = 0;
            if (args.Cancelled)
                MessageBox.Show("Process was cancelled", "Process Cancelled");
            else
                MessageBox.Show("Process completed", "Process Completed");
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            bgWorker.CancelAsync();
        }
    }
}