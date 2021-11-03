using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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

        private int xD = 0;
        private int yD = 0;


        static int appleSize = 20;

        static List<AppleCoord> apples = new List<AppleCoord>();

        public DateTime startTime = DateTime.Now;
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
                // X,Y-----X+10
                // |  
                // |    H Apple here 
                // | 
                // Y+10----X+10 Y+10

            }

            Timer timer = new Timer(10); //1000ms = 1 second, 100 = 1/10 second 
            timer.AutoReset = true;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();

        }

        //to be called each 100ms 
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            base.Dispatcher.Invoke(() =>
            {
                ScoreText.Text = (DateTime.Now - startTime).ToString();

                xPosition += xD;
            yPosition += yD;

                /*
            if (xPosition > 800 || xPosition < 0 || yPosition > 450 || yPosition < 0)
            {
                gameover.Visibility = Visibility.Visible;
                close.Visibility = Visibility.Visible;
                return;
            }
                */

            for (int i = 0; i < appleSize; i++)
            {//120 370
                if (
                   ((apples[i].x * 10 <= xPosition) && (apples[i].x * 10 + 10 >= xPosition)
                   &&
                   (apples[i].y * 10 <= yPosition) && (apples[i].y * 10 + 10 >= yPosition))
                   ||
                   ((apples[i].x * 10 <= xPosition + 20) && (apples[i].x * 10 + 10 >= xPosition + 20)
                   &&
                   (apples[i].y * 10 <= yPosition) && (apples[i].y * 10 + 10 >= yPosition))
                   ||
                   ((apples[i].x * 10 <= xPosition) && (apples[i].x * 10 + 10 >= xPosition)
                   &&
                   (apples[i].y * 10 <= yPosition + 20) && (apples[i].y * 10 + 10 >= yPosition + 20))
                   ||
                   ((apples[i].x * 10 <= xPosition + 20) && (apples[i].x * 10 + 10 >= xPosition + 20)
                   &&
                   (apples[i].y * 10 <= yPosition + 20) && (apples[i].y * 10 + 10 >= yPosition + 20))
                   )


                {
                    apples[i].ImEating = true;
                    apples[i].apple.Visibility = Visibility.Hidden;
                }
            }



                snakeHead.Margin = new Thickness(xPosition, yPosition, 0, 0);
            });
            //home task is snake is kill self by the window wall
            //TextBlock with Text - Game Over must be show             
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up)
            {
                xD = 0;
                yD =-3; 
            }
            else
            if (e.Key == Key.Down)
            {
                xD = 0;
                yD = 3;
            }
            if (e.Key == Key.Left)
            {
                yD = 0;
                xD = -3;
            }
            else
            if (e.Key == Key.Right)
            {
                yD = 0;
                xD = 3;
            }


        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            while (true) //forever before the conditional is true
            {

            }
        }
    }
}
