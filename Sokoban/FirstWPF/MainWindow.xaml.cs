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
        /// name @ domain
        /// RuleZ: 
        /// 1. @ char must be exists and it must be only one
        /// 2. name start with letter "a..z" and can contains 0..9 _ . (all other chars is error)
        /// 3. domain like name 
        /// 4. and name and domain can contains the . chars more the one "..." "name@domain...org"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int count = 0;

            for(int i=0; i < myText.Text.Length; i++)
            {
                if (myText.Text[i] == '@')
                {
                    count++;
                }
            }

            if ((count == 0) || (count > 1))
            {
                aCountingResult.Text = "not valid '@' char";
                return; 
            }
            //at this stage we know the '@' exists and it is only one
            //myText.Text.IndexOf('@') - return index of '@' 
            //the cycle for name section
            //ruleZ 2
            //for (int i = 0; i < myText.Text.IndexOf('@'); i++)
            for (int i = 0; i < myText.Text.Length; i++)
            {
                if (myText.Text[i] == '@')
                {
                    break;
                }
                if ((myText.Text[i] >= 'a') || (myText.Text[i] <= 'z'))
                {
                    continue;
                }
                else
                if ((myText.Text[i] >= '0') || (myText.Text[i] <= '9'))
                {
                    continue;
                }
                else
                    if ((myText.Text[i] == '.') || (myText.Text[i] <= '_'))
                {
                    continue;
                }
                else
                {
                    aCountingResult.Text = "not valid, wrong char for name";
                    return;
                }

            }


            aCountingResult.Text = count.ToString();
            //aCountingResult.Text = "valid";
        }
    }
}
