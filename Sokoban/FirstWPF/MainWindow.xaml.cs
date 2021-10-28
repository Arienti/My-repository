using System.Windows;

namespace FirstWPF
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
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            myText.Text = myText.Text.ToUpper();
        }
        /// <summary>
        /// the home task - is check valid email address inputs "name@domain"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int count = 0;

            for(int i=0; i < myText.Text.Length; i++)
            {
                if (myText.Text[i] == 'a')
                {
                    count++;
                }
            }

            aCountingResult.Text = count.ToString();
            //aCountingResult.Text = "valid";
        }
    }
}
