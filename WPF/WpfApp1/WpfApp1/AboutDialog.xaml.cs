using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// AboutDialog.xaml 的互動邏輯
    /// </summary>
    public partial class AboutDialog : Window
    {
        /// 這個屬性是用來測試 DependencyProperty 的

        public AboutDialog()
        {
            InitializeComponent();
            PrintLogicalTree(0, this);
        }

        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);
            PrintVisualTree(0, this);
        }

        void PrintLogicalTree(int depth, object obj)
        {
            // 列印物件，用空格表示深度
            Debug.WriteLine(new string(' ', depth) + obj);
            // 有時葉節點不是 DependencyObject（像字串）
            if (!(obj is DependencyObject)) return;
            // 遞迴處理每個邏輯子節點
            foreach (object child in LogicalTreeHelper.GetChildren(obj as DependencyObject))
                PrintLogicalTree(depth + 1, child);
        }

        void PrintVisualTree(int depth, DependencyObject obj)
        {
            // 列印物件，用空格表示深度
            Debug.WriteLine(new string(' ', depth) + obj);
            // 遞迴處理每個視覺子節點
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
                PrintVisualTree(depth + 1, VisualTreeHelper.GetChild(obj, i));
        }
    }
}