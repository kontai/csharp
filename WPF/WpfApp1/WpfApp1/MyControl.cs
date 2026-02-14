using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfApp1
{
    public class MyControl:Control
    {

        private static DependencyProperty HightlightDependencyProperty =
            DependencyProperty.Register("Hightlight",
                typeof(bool),
                typeof(AboutDialog),
                new FrameworkPropertyMetadata(false,OnHightlightColorChanged));

        private static void OnHightlightColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as MyControl;
            control.InvalidateVisual();
        }

        public Brush HightlightColor {
            get => (Brush)GetValue(HightlightDependencyProperty);
            set => SetValue(HightlightDependencyProperty, value);


        }
}