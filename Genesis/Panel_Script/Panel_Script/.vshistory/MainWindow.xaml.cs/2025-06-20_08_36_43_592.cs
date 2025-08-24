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

        private string shipOriginalX = ""; // 用於存儲成型尺寸原始的 X 坐標值
        private string shipOriginalY = ""; // 用於存儲成型尺寸原始的 X 坐標值
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

            isInitialized = true; // 確保只初始化一次
        }

        private void InitializeTextBoxes()
        {
            // 所有 TextBox 初始化
            ((TextBox)FindName("six")).Text = "0.0";
            ((TextBox)FindName("siy")).Text = "0.0";
            ((TextBox)FindName("wix")).Text = "0.0";
            ((TextBox)FindName("wiy")).Text = "0.0";
            ((TextBox)FindName("xstep_num")).Text = "1";
            ((TextBox)FindName("ystep_num")).Text = "1";
            ((TextBox)FindName("xstep_spec")).Text = "2.0";
            ((TextBox)FindName("ystep_spec")).Text = "2.0";
            ((ComboBox)FindName("shipRotate")).ItemsSource = new List<string> { "0", "90" };
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


        private void onclick_run_btn(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
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
            shipOriginalX = shipXSize; // 用於存儲成型尺寸原始的 X 坐標值
            shipOriginalY = shipYSize; // 用於存儲成型尺寸原始的 y 坐標值
            shipRotate.SelectedIndex = 0; // 重置旋轉選項為 0 度

            //如果work step,不自動排板,隱藏step num;
            if (stp == "work")
            {
                xstep_num.Visibility=Visibility.Hidden;
                ystep_num.Visibility=Visibility.Hidden;
            }
        }

        /// <summary>
        /// 當選擇旋轉角度 ，更換ship angle。
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private void shipRotate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!isInitialized) return;

            string angle=shipRotate.SelectedItem as string;

            if (angle != null)
            {
                switch (angle)
                {
                    case "0":
                        six.Text = shipOriginalX;
                        siy.Text = shipOriginalY;
                        break;

                    case "90":
                        six.Text = shipOriginalY;
                        siy.Text = shipOriginalX;
                        break;
                }
            }
        }
    }
}