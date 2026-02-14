using GenesisLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Panel_Script
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        private static string job;
        private static string step;

        public static string JOB
        {
            get
            {
                if (job == null)
                {
                    job = Gen.JOB;
                }

                return job;
            }
        }

        public static string STEP
        {
            get
            {
                if (step == null)
                {
                    step = Gen.STEP;
                }

                return step;
            }
        }

        private BackgroundWorker genesisWorker;
        private string currentJob;

        public MainWindow()
        {
            InitializeComponent();

            // 初始化下拉選單
            InitializeComboBox();

            // 取得 JOB 值
            InitializeJob();
        }

        private void InitializeComboBox()
        {
            try
            {
                // 設定初始狀態
                stpSlect.ItemsSource = new List<string> { "載入中..." };
                stpSlect.IsEnabled = false;
                refreshBtn.IsEnabled = false;

                UpdateStatus("初始化下拉選單完成");
            }
            catch (Exception ex)
            {
                UpdateStatus($"初始化下拉選單失敗: {ex.Message}");
            }
        }

        private void InitializeJob()
        {
            try
            {
                // 取得 JOB 值（根據你的實際實作調整）
                currentJob = JOB;

                if (string.IsNullOrEmpty(currentJob))
                {
                    UpdateStatus("錯誤: JOB 值未設定");
                    stpSlect.ItemsSource = new List<string> { "JOB 未設定" };
                    return;
                }

                UpdateStatus($"JOB 設定: {currentJob}");
            }
            catch (Exception ex)
            {
                UpdateStatus($"取得 JOB 值失敗: {ex.Message}");
                stpSlect.ItemsSource = new List<string> { "JOB 取得失敗" };
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // 視窗載入完成後，開始載入 Genesis 資料
            if (!string.IsNullOrEmpty(currentJob))
            {
                LoadGenesisSteps();
            }
        }

        private void LoadGenesisSteps()
        {
            // 如果已經有背景工作在執行，先取消
            if (genesisWorker != null && genesisWorker.IsBusy)
            {
                genesisWorker.CancelAsync();
                return;
            }

            UpdateStatus("開始載入 Genesis 步驟資料...");
            stpSlect.ItemsSource = new List<string> { "載入中..." };
            stpSlect.IsEnabled = false;
            refreshBtn.IsEnabled = false;

            // 建立背景工作
            genesisWorker = new BackgroundWorker();
            genesisWorker.WorkerSupportsCancellation = true;
            genesisWorker.WorkerReportsProgress = true;

            genesisWorker.DoWork += GenesisWorker_DoWork;
            genesisWorker.ProgressChanged += GenesisWorker_ProgressChanged;
            genesisWorker.RunWorkerCompleted += GenesisWorker_RunWorkerCompleted;

            genesisWorker.RunWorkerAsync();
        }

        private void GenesisWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var worker = sender as BackgroundWorker;

                // 檢查取消
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                worker.ReportProgress(10, "正在執行 Gen.INFO...");

                // 執行 Genesis API
                Gen.INFO($" -t job -e {currentJob} -m script -d STEPS_LIST");

                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                worker.ReportProgress(70, "正在取得步驟列表...");

                // 取得步驟列表
                var steps = new List<string>(Gen.GetInfo("gSTEPS_LIST"));

                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                worker.ReportProgress(100, "載入完成");

                // 驗證資料
                if (steps == null || steps.Count == 0)
                {
                    throw new InvalidOperationException("未取得任何步驟資料");
                }

                e.Result = steps;
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
        }

        private void GenesisWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // 更新進度訊息
            if (e.UserState != null)
            {
                UpdateStatus($"進度 {e.ProgressPercentage}%: {e.UserState}");
            }
        }

        private void GenesisWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Cancelled)
                {
                    UpdateStatus("載入已取消");
                    stpSlect.ItemsSource = new List<string> { "載入已取消" };
                }
                else if (e.Result is Exception ex)
                {
                    UpdateStatus($"載入失敗: {ex.Message}");
                    stpSlect.ItemsSource = new List<string> { $"錯誤: {ex.Message}" };
                }
                else if (e.Result is List<string> steps)
                {
                    // 成功載入
                    stpSlect.ItemsSource = steps;
                    stpSlect.IsEnabled = true;

                    UpdateStatus($"載入成功，共 {steps.Count} 個步驟");

                    // 自動選擇第一個項目（可選）
                    if (steps.Count > 0)
                    {
                        stpSlect.SelectedIndex = 0;
                    }
                }
                else
                {
                    UpdateStatus("載入失敗: 未知錯誤");
                    stpSlect.ItemsSource = new List<string> { "未知錯誤" };
                }
            }
            catch (Exception ex)
            {
                UpdateStatus($"更新介面時發生錯誤: {ex.Message}");
            }
            finally
            {
                // 重新啟用重新載入按鈕
                refreshBtn.IsEnabled = true;
            }
        }

        private void StpSlect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (stpSlect.SelectedItem != null)
            {
                string selectedStep = stpSlect.SelectedItem.ToString();
                UpdateStatus($"已選擇步驟: {selectedStep}");

                // 在這裡可以加入選擇步驟後的處理邏輯
                ProcessSelectedStep(selectedStep);
            }
        }

        private void RefreshBtn_Click(object sender, RoutedEventArgs e)
        {
            // 重新載入步驟資料
            LoadGenesisSteps();
        }

        private void ProcessSelectedStep(string stepName)
        {
            try
            {
                // 處理選擇的步驟
                // 根據你的需求實作相關邏輯
                UpdateStatus($"處理步驟: {stepName}");

                // 例如：可以執行特定步驟的操作
                // Gen.INFO($" -t step -e {currentJob} -m script -d {stepName}");
            }
            catch (Exception ex)
            {
                UpdateStatus($"處理步驟時發生錯誤: {ex.Message}");
            }
        }

        private void UpdateStatus(string message)
        {
            try
            {
                // 確保在 UI 執行緒上更新
                if (statusText.Dispatcher.CheckAccess())
                {
                    string timestamp = DateTime.Now.ToString("HH:mm:ss");
                    statusText.Text += $"\n[{timestamp}] {message}";

                    // 自動捲動到最後
                    var scrollViewer = statusText.Parent as ScrollViewer;
                    scrollViewer?.ScrollToEnd();
                }
                else
                {
                    statusText.Dispatcher.BeginInvoke(new Action(() => UpdateStatus(message)));
                }
            }
            catch (Exception ex)
            {
                // 如果更新狀態失敗，至少輸出到 Console
                Console.WriteLine($"更新狀態失敗: {ex.Message}");
                Console.WriteLine($"原始訊息: {message}");
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            // 視窗關閉時清理資源
            if (genesisWorker != null && genesisWorker.IsBusy)
            {
                genesisWorker.CancelAsync();
            }

            base.OnClosed(e);
        }

    }
}