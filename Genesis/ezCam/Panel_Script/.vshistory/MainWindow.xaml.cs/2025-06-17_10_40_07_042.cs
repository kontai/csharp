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
                job = Gen.JOB;
                if (job == null)
                {
                    Gen.PAUSE("need select a job.");
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
                }

                return step;
            }
        }


        public MainWindow()
        {
            InitializeComponent();

            // TextBox 初始化
            InitializeTextBoxes();
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
            #region get steps list

            Gen.INFO($" -t job -e {JOB} -m script -d STEPS_LIST");
            List<string> steps = new List<string>(Gen.GetInfo("gSTEPS_LIST"));

            stpSlect.ItemsSource = steps;

            #endregion

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



        private void onclick_run_btn(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void stpSlect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Gen.INFO($"-t step -e {JOB}/{STEP} -m script -d PROF_LIMITS");
           double xmin= double.Parse(Gen.GetInfo("gPROF_LIMITSxmin")[0]);
           double ymin= double.Parse(Gen.GetInfo("gPROF_LIMITSymin")[0]);
           double xmax= double.Parse(Gen.GetInfo("gPROF_LIMITSxmax")[0]);
           double ymax= double.Parse(Gen.GetInfo("gPROF_LIMITSymax")[0]);
           ((TextBox)FindName("s_ix")).Text=(xmax-xmin).ToString();
           ((TextBox)FindName("s_iy")).Text=(ymax-ymin).ToString();
        }
    }
}