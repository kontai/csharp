using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using GenesisLib;

namespace Panel_Script
{
    /// <summary>
    /// App.xaml 的互動邏輯
    /// </summary>
    public partial class App : Application
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

        protected override void OnStartup(StartupEventArgs e)
        {
            // 執行初始化代碼
            InitializeApplication();

            // 手動創建並顯示主視窗
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            base.OnStartup(e);
        }

        private void InitializeApplication()
        {
            // 你的初始化邏輯
            //LoadSettings();
            //SetupDatabase();
            //ConfigureLogging();
            GetStepList();

        }

        public void GetStepList()
        {
            Gen.INFO($" -t job -e {JOB} -m script -d STEPS_LIST");
            //List<string> steps=new List<string>();
            //foreach (var step in Gen.GetInfo("gSTEPS_LIST"))
            //{
            //    steps.Add(step);
            //}
        }
    }
}