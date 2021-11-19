using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
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

namespace HTTP_WPF_RESAPICLIENT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {

        // HttpClient is intended to be instantiated once per application, rather than per-use. See Remarks.
        private HttpClient client = new HttpClient();

        public MainWindow()
        {
            InitializeComponent();
        }

        private async Task<string> Get()
        {

            // http://airquality.owlos.org/Things/GetAllThingsWrappers

            try
            {
                HttpResponseMessage res = await client.GetAsync("http://airquality.owlos.org/Things/GetAllThingsWrappers");
                res.EnsureSuccessStatusCode();
                string responseBody = await res.Content.ReadAsStringAsync();
                //string json = JsonSerializer.Deserialize(responseBody, string, );
                return responseBody;
            }
            catch
            {
                return "Error";
            }


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tbJSON.AppendText(Get().Result);
        }
    }
}
