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

namespace WpfApp2
{
    public class AppleCoord //scheme 
    {
        public Ellipse apple = new Ellipse();
        public bool ImEating = false;
        public int x;
        public int y;
    }


    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int xPosition = 400;
        private int yPosition = 400;

        static int appleSize = 10;

        static List<AppleCoord> apples = new List<AppleCoord>();
        public MainWindow()
        {
            InitializeComponent();
            snakeHead.Margin = new Thickness(xPosition, yPosition, 0, 0); //Left Top             

            Random r = new Random();
            for (int i = 0; i < appleSize; i++)
            {
                //float a = 55.723;
                //a / 10 = 5
                //a / 10.0f = 5.5723
                //80x40
                //
                // 10px 20px 1px // 10-450x+10 10-560y+10

                AppleCoord a = new AppleCoord();
                a.x = r.Next((int)(this.Width / 10.0f));
                a.y = r.Next((int)(this.Height / 10.0f));
                apples.Add(a);

                a.apple.Width = 10;
                a.apple.Height = 10;
                a.apple.Fill = new SolidColorBrush(Colors.Red);
                a.apple.HorizontalAlignment = HorizontalAlignment.Left;
                a.apple.VerticalAlignment = VerticalAlignment.Top;
                a.apple.Margin = new Thickness(a.x * 10, a.y * 10, 0, 0);
                MainGrid.Children.Add(a.apple);

            }
        }
        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up)
            {
                yPosition-=10; 
            }
            else
            if (e.Key == Key.Down)
            {
                yPosition += 10;
            }
            if (e.Key == Key.Left)
            {
                xPosition -= 10;
            }
            else
            if (e.Key == Key.Right)
            {
                xPosition += 10;
            }
             if (xPosition > 800 || xPosition < 0 || yPosition > 450 || yPosition < 0)
            {
                gameover.Visibility = Visibility.Visible;
                close.Visibility = Visibility.Visible;
                return;
            }
            snakeHead.Margin = new Thickness(xPosition, yPosition, 0, 0);
            //home task is snake is kill self by the window wall
            //TextBlock with Text - Game Over must be show 
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
