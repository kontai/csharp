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
using System.Windows.Shapes;

namespace Chapter_6__Input_Events
{
    /// <summary>
    /// MouseEvenet.xaml 的互動邏輯
    /// </summary>
    public partial class MouseEvenet : Window
    {
        public MouseEvenet()
        {
            InitializeComponent();
        }

        private bool _isDragging;
        private Point _startPosition;

        private void Rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _isDragging = true;
            _startPosition = e.GetPosition(null); // 屏幕坐标
            ((UIElement)sender).CaptureMouse(); // 捕获鼠标
        }

        private void Rectangle_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDragging)
            {
                Point currentPosition = e.GetPosition(null);
                double offsetX = currentPosition.X - _startPosition.X;
                double offsetY = currentPosition.Y - _startPosition.Y;
                // 更新控件位置
                Canvas.SetLeft((UIElement)sender, offsetX);
                Canvas.SetTop((UIElement)sender, offsetY);
            }
        }

        private void Rectangle_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _isDragging = false;
            ((UIElement)sender).ReleaseMouseCapture(); // 释放鼠标捕获
        }
    }
}