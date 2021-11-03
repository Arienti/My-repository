using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfSnake
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int xPosition = 40;
        private int yPosition = 40;

        private int sizePoint = 16;

        



        public MainWindow()
        {
            InitializeComponent();
        }

        private void CanvasMap_Loaded(object sender, RoutedEventArgs e)
        {
            // Create point "snake"
            Ellipse snake = CreateEllipce(new Point(xPosition, yPosition), Brushes.Green);
            // Add "snake" to Canvas
            CanvasMap.Children.Insert(0, snake);

            // Create point "apple"
            Ellipse apple = CreateEllipce(new Point(150, 150), Brushes.Red);
            // Add "apple" to Canvas
            CanvasMap.Children.Insert(1, apple);

            


        }

        //static list<>

        private static Ellipse CreateEllipce(Point point, Brush brush)
        {
            Ellipse apple = new Ellipse();
            apple.Width = 16;
            apple.Height = 16;
            bool ImEating = false;

            apple.Fill = brush;
            Canvas.SetLeft(apple, point.X);
            Canvas.SetTop(apple, point.Y);
            return apple;
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Up)
            {
                yPosition -= sizePoint;
            }
            if (e.Key == Key.Down)
            {
                yPosition += sizePoint;
            }
            if (e.Key == Key.Left)
            {
                xPosition -= sizePoint;
            }
            if (e.Key == Key.Right)
            {
                xPosition += sizePoint;
            }

            if(yPosition < (0+sizePoint) || yPosition > (450-sizePoint) || xPosition < (0+sizePoint) || xPosition > (800 - sizePoint))
            {
                return;  
            }
        }
    }
}
