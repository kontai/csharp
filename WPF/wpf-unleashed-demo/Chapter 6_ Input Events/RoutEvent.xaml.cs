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
    /// RoutEvent.xaml 的互動邏輯
    /// </summary>
    public partial class RoutEvent : Window
    {
        public RoutEvent()
        {
            InitializeComponent();
            this.AddHandler(Window.MouseRightButtonDownEvent,
                new MouseButtonEventHandler(AboutDialog_OnMouseRightButtonDown), true);
        }

        private void AboutDialog_OnMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {

            this.Title = "Source = " + e.Source.GetType().Name +
                         ", OrignalSource = " + e.OriginalSource.GetType().Name + " @ " + new DateTime().Day;
            Control source = e.Source as Control;
            if (source.BorderThickness != new Thickness(5))
            {
                source.BorderThickness = new Thickness(5);
                source.BorderBrush = Brushes.Black;
            }
            else
            {
                source.BorderThickness = new Thickness(0);
            }
        }

        void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You just clicked " + (e.Source as FrameworkElement).Name);
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
        MessageBox.Show("You just selected " + e.AddedItems[0]);
        }
    }
}
