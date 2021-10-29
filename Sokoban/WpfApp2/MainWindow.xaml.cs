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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int xPosition = 400;
        private int yPosition = 400;
        public MainWindow()
        {
            InitializeComponent();
            snakeHead.Margin = new Thickness(xPosition, yPosition, 0, 0); //Left Top 
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
