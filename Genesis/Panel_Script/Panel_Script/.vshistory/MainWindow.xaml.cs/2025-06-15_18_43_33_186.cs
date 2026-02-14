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
            s_ix.Text= "0.0";

            TextBox s_iy = this.FindName("siy") as TextBox;
            s_iy.Text = "0.0";

            TextBox w_ix = this.FindName("wix") as TextBox;
            w_ix.Text = "0.0";

            TextBox w_iy = this.FindName("wiy") as TextBox;
            w_iy.Text = "0.0";

            TextBox x_step_num = this.FindName("xstep_num") as TextBox;
            x_step_num.Text="1";

            TextBox y_step_num = this.FindName("ystep_num") as TextBox;
            y_step_num.Text= "1";

            TextBox x_step_spec = this.FindName("xstep_spec") as TextBox;
            x_step_spec.Text = "2.0";

            TextBox y_step_spec = this.FindName("ystep_spec") as TextBox;
            y_step_spec.Text= "2.0";


            Gen.INFO($" -t job -e {PanelScript.JOB} -m script -d STEPS_LIST");
            //List<string>steps=new List<string>();
            string[] steps=new string[10];
            Gen.GetInfo("gSTEPS_LIST").CopyTo(steps, 0);
            //for (int i = 0; i < Gen.GetInfo("gSTEPS_LIST").Length; i++)
            //{
            //    steps[i]= Gen.GetInfo("gSTEPS_LIST")[i];
            //}

            //List<string> layer_list = new List<string>();
            //layer_list=GenTools.getSteps(PanelScript.JOB, PanelScript.STEP);
            stpSlect.ItemsSource= new List<string>{"aa","bb","cc"};

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
