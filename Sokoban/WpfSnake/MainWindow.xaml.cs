using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfSnake
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CanvasMap_Loaded(object sender, RoutedEventArgs e)
        {
            Ellipse apple = CreateEllipce(new Point(150, 150), Brushes.Red);

            CanvasMap.Children.Insert(0, apple);
        }

        private static Ellipse CreateEllipce(Point point, Brush brush)
        {
            Ellipse apple = new Ellipse();
            apple.Width = 16;
            apple.Height = 16;
            apple.Fill = Brushes.Red;
            Canvas.SetLeft(apple, 150);
            Canvas.SetTop(apple, 150);
            return apple;
        }
    }
}
