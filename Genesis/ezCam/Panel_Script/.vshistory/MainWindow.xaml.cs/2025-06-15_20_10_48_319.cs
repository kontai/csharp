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
        public MainWindow()
        {
            InitializeComponent();
            InitializeTextBoxes();

            // 設定載入中提示
            stpSlect.ItemsSource = new List<string> { "載入中..." };

            // 使用 BackgroundWorker 載入資料
            LoadGenesisDataWithBackgroundWorker();
        }

        private void InitializeTextBoxes()
        {
            ((TextBox)FindName("six")).Text = "0.0";
            ((TextBox)FindName("siy")).Text = "0.0";
            ((TextBox)FindName("wix")).Text = "0.0";
            ((TextBox)FindName("wiy")).Text = "0.0";
            ((TextBox)FindName("xstep_num")).Text = "1";
            ((TextBox)FindName("ystep_num")).Text = "1";
            ((TextBox)FindName("xstep_spec")).Text = "2.0";
            ((TextBox)FindName("ystep_spec")).Text = "2.0";
        }

        private void LoadGenesisDataWithBackgroundWorker()
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (sender, e) =>
            {
                try
                {
                    Console.WriteLine("開始載入 Genesis 資料...");

                    Gen.INFO($" -t job -e {JOB} -m script -d STEPS_LIST");
                    Console.WriteLine("Gen.INFO 執行完成");

                    var steps = new List<string>(Gen.GetInfo("gSTEPS_LIST"));
                    Console.WriteLine($"取得 {steps.Count} 個步驟");

                    Gen.PAUSE("test");
                    Console.WriteLine("Gen.PAUSE 執行完成");

                    e.Result = steps;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"載入錯誤: {ex.Message}");
                    e.Result = ex;
                }
            };

            worker.RunWorkerCompleted += (sender, e) =>
            {
                if (e.Result is Exception ex)
                {
                    Console.WriteLine($"背景工作發生錯誤: {ex.Message}");
                    stpSlect.ItemsSource = new List<string> { $"載入失敗: {ex.Message}" };
                }
                else if (e.Result is List<string> steps)
                {
                    Console.WriteLine("更新 ComboBox");
                    stpSlect.ItemsSource = steps;
                }
            };

            worker.RunWorkerAsync();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void s_ix(object sender, TextChangedEventArgs e)
        {
                    }

        private void s_iy(object sender, TextChangedEventArgs e)
        {

        }

        private void w_ix(object sender, TextChangedEventArgs e)
        {

        }

        private void w_iy(object sender, TextChangedEventArgs e)
        {

        }

        private void x_step_num(object sender, TextChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void y_step_num(object sender, TextChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void x_step_spec(object sender, TextChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void y_step_spec(object sender, TextChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Layer_List(object sender, SelectionChangedEventArgs e)
        {
        }


        private void onclick_run_btn(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
