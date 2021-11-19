using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace Thread
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Random r = new Random();

        
        public MainWindow()
        {
            InitializeComponent();
        }


        private void NetTextBlock_Click(object sender, RoutedEventArgs e)
        {


            TextBlock text = new TextBlock
            {
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(r.Next(400), r.Next(400), 0, 0)
            };
            MainGrid.Children.Add(text);

            System.Threading.Thread thread = new System.Threading.Thread(OurThread);

            thread.Start(text);
        }

        [STAThread]
        private void OurThread(object text1)
        {


            int count = r.Next(1000);

            while (count > 0)
            {
                count--;
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    (text1 as TextBlock).Text = count.ToString();
                }));
                System.Threading.Thread.Sleep(20);
                
            }

            Dispatcher.BeginInvoke(new Action(() =>
            {
                MainGrid.Children.Remove(text1 as TextBlock);
                text1 = null;

            }));
        }
    }
}
