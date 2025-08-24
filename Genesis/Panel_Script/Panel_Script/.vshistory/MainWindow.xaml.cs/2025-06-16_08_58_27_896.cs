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

            // TextBox 初始化
            InitializeTextBoxes();

            // 設定載入中的提示
            stpSlect.ItemsSource = new List<string> { "載入中..." };
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
        }

        private void LoadGenesisDataAsync()
        {
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Gen.INFO($" -t job -e {JOB} -m script -d STEPS_LIST");
            var steps = new List<string>(Gen.GetInfo("gSTEPS_LIST"));
            //stpSlect.ItemsSource = steps;
            // 避免直接使用 ItemsSource，改用 Items 集合
            stpSlect.ItemsSource = null;
            stpSlect.Items.Clear();
            foreach (string step in steps)
            {
                stpSlect.Items.Add(step);
            }
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