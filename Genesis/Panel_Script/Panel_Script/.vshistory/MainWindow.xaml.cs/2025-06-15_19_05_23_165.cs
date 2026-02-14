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
using GenesisInterfaces;

namespace Panel_Script
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //s_ix , s_iy, w_ix, w_iy, x_step_num, y_step_num, x_step_spec, y_step_spec are TextBox controls in the XAML file
            TextBox s_ix = this.FindName("six") as TextBox;
            s_ix.Text = "0.0";

            TextBox s_iy = this.FindName("siy") as TextBox;
            s_iy.Text = "0.0";

            TextBox w_ix = this.FindName("wix") as TextBox;
            w_ix.Text = "0.0";

            TextBox w_iy = this.FindName("wiy") as TextBox;
            w_iy.Text = "0.0";

            TextBox x_step_num = this.FindName("xstep_num") as TextBox;
            x_step_num.Text = "1";

            TextBox y_step_num = this.FindName("ystep_num") as TextBox;
            y_step_num.Text = "1";

            TextBox x_step_spec = this.FindName("xstep_spec") as TextBox;
            x_step_spec.Text = "2.0";

            TextBox y_step_spec = this.FindName("ystep_spec") as TextBox;
            y_step_spec.Text = "2.0";

                      stpSlect.ItemsSource = new List<string> { "載入中..." };
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
             try
    {
        // 檢查 Genesis 環境變數
        string genesisTmp = Environment.GetEnvironmentVariable("GENESIS_TMP");
        Console.WriteLine($"GENESIS_TMP = '{genesisTmp}'");
        
        string job = Environment.GetEnvironmentVariable("JOB");
        Console.WriteLine($"環境變數 JOB = '{job}'");
        
        Console.WriteLine($"PanelScript.JOB = '{PanelScript.JOB}'");
        
        // 如果環境不正確，使用測試資料
        if (string.IsNullOrEmpty(PanelScript.JOB) || string.IsNullOrEmpty(genesisTmp))
        {
            Console.WriteLine("Genesis 環境未正確設定，使用測試資料");
            stpSlect.ItemsSource = new List<string> { "測試步驟1", "測試步驟2", "測試步驟3" };
            return;
        }
        
        Console.WriteLine("嘗試執行 Gen.INFO...");
        Gen.INFO($" -t job -e {PanelScript.JOB} -m script -d STEPS_LIST");
        
        // 其餘程式碼...
        
    }
    catch (Exception ex)
    {
        Console.WriteLine($"完整錯誤: {ex}");
        stpSlect.ItemsSource = new List<string> { "載入失敗" };
    }
            //try
            //{
            //    // 在這裡執行 Genesis API 呼叫
            //    Gen.INFO($" -t job -e {PanelScript.JOB} -m script -d STEPS_LIST");
            //    List<string> steps = new List<string>(Gen.GetInfo("gSTEPS_LIST"));

            //    stpSlect.ItemsSource = steps;
            //    Gen.PAUSE("test");
            //}
            //catch (Exception ex)
            //{
            //    // 錯誤處理
            //    stpSlect.ItemsSource = new List<string> { "載入失敗: " + ex.Message };
            //}
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