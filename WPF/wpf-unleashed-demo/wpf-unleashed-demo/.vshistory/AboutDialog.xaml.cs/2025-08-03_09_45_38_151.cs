using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    public class Button : ButtonBase
{
    // (1) 依賴屬性本身：一個靜態的只讀欄位
    public static readonly DependencyProperty IsDefaultProperty;

    // (2) 靜態建構子：註冊依賴屬性
    static Button()
    {
        // 註冊屬性，並將結果賦值給 IsDefaultProperty 欄位
        Button.IsDefaultProperty =
            DependencyProperty.Register(
                "IsDefault",            // 依賴屬性的名字 (字串)
                typeof(bool),           // 依賴屬性的型別 (這裡是要儲存布林值)
                typeof(Button),         // 擁有這個依賴屬性的類別 (Button 類別)
                new FrameworkPropertyMetadata(
                    false,                      // 預設值 (如果沒有其他地方設定，就是 false)
                    new PropertyChangedCallback(OnIsDefaultChanged) // 當屬性值改變時，會呼叫這個回呼方法
                )
            );
        // ... (其他靜態屬性或初始化)
    }

    // (3) .NET 屬性包裝器 (可選的，但強烈建議)：讓它看起來像個普通屬性
    public bool IsDefault
    {
        get { return (bool)GetValue(Button.IsDefaultProperty); }  // 讀取值時，呼叫 GetValue
        set { SetValue(Button.IsDefaultProperty, value); }         // 設定值時，呼叫 SetValue
    }

    // (4) 屬性改變回呼方法 (可選的)：當 IsDefault 屬性值改變時會被呼叫
    private static void OnIsDefaultChanged(
        DependencyObject o,                   // 觸發改變的物件實例
        DependencyPropertyChangedEventArgs e) // 改變的詳細資訊 (舊值、新值等)
    {
        // ... (在這裡處理屬性值改變後的邏輯，例如更新 UI)
    }
    // ... (其他 Button 類別成員)
}
}