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
        private static string lastUnit = "Inch"; //last selected unit, default is Inch

        private string OrigShipX = ""; // 用於存儲成型尺寸原始的 X 坐標值
        private string OrigShipY = ""; // 用於存儲成型尺寸原始的 X 坐標值
        private bool isInitialized = false;

        public static string JOB
        {
            get
            {
                job = Gen.JOB;
                if (job == null)
                {
                    Gen.PAUSE("need select a job.");
                    throw new Exception("cant get job variable");
                }

                return job;
            }
        }

        public static string STEP
        {
            get
            {
                step = Gen.STEP;
                if (step == null)
                {
                    Gen.PAUSE("need select a step.");
                    throw new Exception("cant get step variable");
                }

                return step;
            }
        }


        public MainWindow()
        {
            InitializeComponent();

            // TextBox 初始化
            InitializeTextBoxes();

            //GetAllLayer();

            isInitialized = true; // 確保只初始化一次
        }

        private void InitializeTextBoxes()
        {
            // 所有 TextBox 初始化
            ((TextBox)FindName("six")).Text = "1.0";
            ((TextBox)FindName("siy")).Text = "1.0";
            ((TextBox)FindName("wix")).Text = "1.0";
            ((TextBox)FindName("wiy")).Text = "1.0";
            ((TextBox)FindName("xstep_num")).Text = "1";
            ((TextBox)FindName("ystep_num")).Text = "1";
            ((TextBox)FindName("xstep_spec")).Text = "0.0787";
            ((TextBox)FindName("ystep_spec")).Text = "0.0787";
            ((ComboBox)FindName("shipRotate")).ItemsSource = new List<string> { "0", "90" };
            ((ComboBox)FindName("shipRotate")).SelectedIndex = 0;
            ((ComboBox)FindName("unit_mminch")).ItemsSource = new List<string> { "Inch", "MM" };
            ((ComboBox)FindName("unit_mminch")).SelectedIndex = 0;
        }

        private void LoadGenesisDataAsync()
        {
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            #region get steps list

            Gen.INFO($" -t job -e {JOB} -m script -d STEPS_LIST");
            List<string> steps = new List<string>(Gen.GetInfo("gSTEPS_LIST"));

            stpSlect.ItemsSource = steps;

            #endregion
        }


        /// <summary>
        /// 下拉選擇STEP時，獲取成型尺寸並更新相關 TextBox。
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private void stpSlect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string stp = stpSlect.SelectedItem as string;
            Gen.INFO($"-t step -e {JOB}/{stp} -m script -d PROF_LIMITS");
            double xmin = double.Parse(Gen.GetInfo("gPROF_LIMITSxmin")[0]);
            double ymin = double.Parse(Gen.GetInfo("gPROF_LIMITSymin")[0]);
            double xmax = double.Parse(Gen.GetInfo("gPROF_LIMITSxmax")[0]);
            double ymax = double.Parse(Gen.GetInfo("gPROF_LIMITSymax")[0]);
            string shipXSize = (xmax - xmin).ToString(); // 計算成型尺寸的 X 坐標值
            string shipYSize = (ymax - ymin).ToString(); // 計算成型尺寸的 y 坐標值
            six.Text = shipXSize; // 設置成型尺寸的 X 坐標值到對應的 TextBox
            siy.Text = shipYSize; // 設置成型尺寸的 y 坐標值到對應的 TextBox
            OrigShipX = shipXSize; // 用於存儲成型尺寸原始的 X 坐標值
            OrigShipY = shipYSize; // 用於存儲成型尺寸原始的 y 坐標值
            shipRotate.SelectedIndex = 0; // 重置旋轉選項為 0 度
            unit_mminch.IsEnabled = !(OrigShipX == "" || OrigShipY == "");

            //如果work step,不自動排板,隱藏排板間距、排板數量;
            if (stp == "work")
            {
                //xtep_spec不可編輯，ytep_spec不可編輯
                xstep_num.IsReadOnly = true;
                ystep_num.IsReadOnly = true;
                shipRotate.IsReadOnly = true;
                //xstep_spec.IsReadOnly = true;
                //ystep_spec.IsReadOnly=true;
            }


            UpdateData();
        }

        /// <summary>
        /// 當選擇旋轉角度 ，更換ship angle。
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private void shipRotate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!isInitialized) return;
            UpdateData();
        }

        private void UpdateData()
        {
            string angle = shipRotate.SelectedItem as string;

            if (unit_mminch.Text == "MM")
            {
                if (angle == "0")
                {
                    six.Text = (double.Parse(OrigShipX) * 25.4).ToString("F4");
                    siy.Text = (double.Parse(OrigShipY) * 25.4).ToString("F4");
                }
                else if (angle == "90")
                {
                    six.Text = (double.Parse(OrigShipY) * 25.4).ToString("F4");
                    siy.Text = (double.Parse(OrigShipX) * 25.4).ToString("F4");
                }
            }
            else if (unit_mminch.Text == "Inch")
            {
                if (angle == "0")
                {
                    six.Text = OrigShipX;
                    siy.Text = OrigShipY;
                }
                else if (angle == "90")
                {
                    six.Text = OrigShipY;
                    siy.Text = OrigShipX;
                }
            }
        }

        private void unit_mminch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!isInitialized) return;

            string angle = shipRotate.SelectedItem as string;


            string selectedUnit = unit_mminch.SelectedItem as string;


            if (selectedUnit == "MM" && lastUnit == "Inch")
            {
                if (angle == "0")
                {
                    six.Text = (double.Parse(OrigShipX) * 25.4).ToString("F4");
                    siy.Text = (double.Parse(OrigShipY) * 25.4).ToString("F4");
                }
                else if (angle == "90")
                {
                    six.Text = (double.Parse(OrigShipY) * 25.4).ToString("F4");
                    siy.Text = (double.Parse(OrigShipX) * 25.4).ToString("F4");
                }

                //inch to mm
                wix.Text = (double.Parse(wix.Text) * 25.4).ToString("F4");
                wiy.Text = (double.Parse(wiy.Text) * 25.4).ToString("F4");
                xstep_spec.Text = Math.Round((double.Parse(xstep_spec.Text) * 25.4), 2).ToString("F2");
                ystep_spec.Text = Math.Round((double.Parse(ystep_spec.Text) * 25.4), 2).ToString("F2");
                lastUnit = "MM";
            }
            else if (selectedUnit == "Inch" && lastUnit == "MM")
            {
                if (angle == "0")
                {
                    six.Text = OrigShipX;
                    siy.Text = OrigShipY;
                }
                else if (angle == "90")
                {
                    six.Text = OrigShipY;
                    siy.Text = OrigShipX;
                }

                //mm to inch
                wix.Text = (double.Parse(wix.Text) / 25.4).ToString("F4");
                wiy.Text = (double.Parse(wiy.Text) / 25.4).ToString("F4");
                xstep_spec.Text = (double.Parse(xstep_spec.Text) / 25.4).ToString("F4");
                ystep_spec.Text = (double.Parse(ystep_spec.Text) / 25.4).ToString("F4");
                lastUnit = "Inch";
            }
        }

        private void onclick_exit_btn(object sender, RoutedEventArgs e)
        {
            //exit the application
            Application.Current.Shutdown();
        }

        private void onclick_run_btn(object sender, RoutedEventArgs e)
        {
            //先簡單判斷輸入的值是否為0.0，如果是則彈出提示信息
            if (six.Text == "0.0" || siy.Text == "0.0")
            {
                //彈出提示信息，要求輸入成型尺寸
                Gen.PAUSE("Please input the ship size.");
                return;
            }

            if (wix.Text == "0.0" || wiy.Text == "0.0")
            {
                Gen.PAUSE("Please input the WPNL size.");
                return;
            }

            //Run the panel script
            try
            {
                MyPanelScript.RunPanelScript();
            }
            catch (Exception ex)
            {
                Gen.PAUSE($"Error: {ex.Message}");
            }
        }


        private void wix_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void wiy_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void six_TextChanged(object sender, TextChangedEventArgs e)
        {
            //OrigShipX = six.Text;
        }

        private void siy_TextChanged(object sender, TextChangedEventArgs e)
        {
            //OrigShipY = siy.Text;
        }
    }
}