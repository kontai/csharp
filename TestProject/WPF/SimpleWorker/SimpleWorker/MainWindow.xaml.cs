using System.ComponentModel;
using System.Runtime.InteropServices.Marshalling;
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
        //宣告BackgroundWorker物件
        private BackgroundWorker bgWorker = new BackgroundWorker();

        public MainWindow()
        {
            InitializeComponent();

            //設置BackgroundWorker屬性
            //允許BackgroundWorker回報進度
            bgWorker.WorkerReportsProgress = true;
            //允許BackgroundWorker取消作業
            bgWorker.WorkerSupportsCancellation = true;

            //連接BackgroundWorker對象的處理程式
            //DoWork事件：BackgroundWorker執行的作業
            bgWorker.DoWork += DoWork_Handler;
            //ProgressChanged事件：BackgroundWorker回報進度
            bgWorker.ProgressChanged += ProgreeeChanged_Handler;
            //RunWorkerCompleted事件：BackgroundWorker完成作業
            bgWorker.RunWorkerCompleted += RunWorkCompleted_Handler;
        }

        //BackgroundWorker完成作業事件處理程式
        private void RunWorkCompleted_Handler(object? sender, RunWorkerCompletedEventArgs e)
        {
            //重設進度條
            progressBar.Value = 0;
            //如果作業被取消
            if (e.Cancelled)
                //顯示取消訊息
                MessageBox.Show("工作已取消", "Process Cancelled");
            else
                //顯示完成訊息
                MessageBox.Show("處理完成", "Process Completed");
        }

        //BackgroundWorker執行作業事件處理程式
        private void DoWork_Handler(object? sender, DoWorkEventArgs e)
        {
            //取得BackgroundWorker物件
            BackgroundWorker worker = sender as BackgroundWorker;
            //執行作業
            for (int i = 1; i < 10; i++)
            {
                //如果取消作業
                if (worker.CancellationPending)
                {
                    //設定取消旗標
                    e.Cancel = true;
                    //中斷作業
                    break;
                }
                else
                {
                    //回報進度
                    worker.ReportProgress(i * 10);
                    //暫停執行
                    Thread.Sleep(500);
                }
            }
        }

        //按鈕點擊事件處理程式
        private void btnProcess_Click(object sender, RoutedEventArgs e)
        {
            //如果BackgroundWorker未執行中
            if (!bgWorker.IsBusy)
                //啟動BackgroundWorker
                bgWorker.RunWorkerAsync();
        }

        //BackgroundWorker進度變更事件處理程式
        private void ProgreeeChanged_Handler(object? sender, ProgressChangedEventArgs e)
        {
            //設定進度條值
            progressBar.Value = e.ProgressPercentage;
        }

        //取消按鈕點擊事件處理程式
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            //取消BackgroundWorker作業
            bgWorker.CancelAsync();
        }
    }
}