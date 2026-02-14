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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace wpf_unleashed_demo
{
    /// <summary>
    /// AboutDialog.xaml 的互動邏輯
    /// </summary>
    public partial class AboutDialog : Window
    {
        public AboutDialog() // 建構子
        {
            InitializeComponent(); // 初始化 XAML 定義的介面元素
            PrintLogicalTree(0, this); // 在這裡就遍歷並印出邏輯樹
        }

        protected override void OnContentRendered(EventArgs e) // 當視窗內容被渲染出來後呼叫
        {
            base.OnContentRendered(e);
            PrintVisualTree(0, this); // 在這裡才遍歷並印出視覺樹
        }

        // 遞歸函數：印出邏輯樹
        void PrintLogicalTree(int depth, object obj)
        {
            // 印出當前物件，前面加上代表深度的空格
            Debug.WriteLine(new string(' ', depth) + obj);

            // 有時候葉節點不是 DependencyObject (例如字串)，就直接返回
            if (!(obj is DependencyObject)) return;

            // 遞歸呼叫：遍歷每個邏輯子元素
            foreach (object child in LogicalTreeHelper.GetChildren(obj as DependencyObject))
                PrintLogicalTree(depth + 1, child);
        }

        // 遞歸函數：印出視覺樹
        void PrintVisualTree(int depth, DependencyObject obj)
        {
            // 印出當前物件，前面加上代表深度的空格
            Debug.WriteLine(new string(' ', depth) + obj);

            // 遞歸呼叫：遍歷每個視覺子元素
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
                PrintVisualTree(depth + 1, VisualTreeHelper.GetChild(obj, i));
        }

        public static readonly DependencyProperty propertyNameProperty = DependencyProperty.Register(
            "IsDefalut", typeof(bool), typeof(AboutDialog), new PropertyMetadata(default(bool),new PropertyChangedCallback(OnIsDefaultChanged)));

        private static void OnIsDefaultChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AboutDialog dialog = d as AboutDialog;
            dialog.btn_help.Background= Brushes.Red; // 當屬性變更時，改變按鈕背景色
        }

        public bool propertyName
        {
            get { return (bool)GetValue(propertyNameProperty); }
            set { SetValue(propertyNameProperty, value); }
        }
    }
}