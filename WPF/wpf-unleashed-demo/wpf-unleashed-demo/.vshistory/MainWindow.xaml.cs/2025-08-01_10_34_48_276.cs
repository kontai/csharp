using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media;

public partial class AboutDialog : Window
{
    public AboutDialog()
    {
        InitializeComponent();
        PrintLogicalTree(0, this); // 在构造函数中打印逻辑树
    }

    protected override void OnContentRendered(EventArgs e)
    {
        base.OnContentRendered(e);
        PrintVisualTree(0, this); // 在布局完成后打印视觉树
    }

    void PrintLogicalTree(int depth, object obj)
    {
        Debug.WriteLine(new string(' ', depth) + obj); // 打印当前对象
        if (!(obj is DependencyObject)) return; // 非 DependencyObject 跳出
        foreach (object child in LogicalTreeHelper.GetChildren(obj as DependencyObject))
            PrintLogicalTree(depth + 1, child); // 递归遍历逻辑子节点
    }

    void PrintVisualTree(int depth, DependencyObject obj)
    {
        Debug.WriteLine(new string(' ', depth) + obj); // 打印当前对象
        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            PrintVisualTree(depth + 1, VisualTreeHelper.GetChild(obj, i)); // 递归遍历视觉子节点
    }
}
