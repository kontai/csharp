using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace Panel_Script
{
    /// <summary>
    /// App.xaml 的互動邏輯
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
{
    try
    {
        // 檢查 Genesis 環境
        if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable("GENESIS_TMP")))
        {
            MessageBox.Show("GENESIS_TMP 環境變數未設定！", "錯誤", MessageBoxButton.OK, MessageBoxImage.Error);
            this.Shutdown(1);
            return;
        }
        
        Console.WriteLine("Genesis 環境檢查通過，應用程式啟動");
    }
    catch (Exception ex)
    {
        MessageBox.Show($"應用程式啟動失敗: {ex.Message}", "錯誤", MessageBoxButton.OK, MessageBoxImage.Error);
        this.Shutdown(1);
    }
}
    }
}
