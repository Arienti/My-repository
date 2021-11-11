using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace HTTP_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // HttpClient is intended to be instantiated once per application, rather than per-use. See Remarks.
        private HttpClient client = new HttpClient();

        public MainWindow()
        {
            InitializeComponent();
        }

        private async Task<string> Get(string APIName)
        {
            // Call asynchronous network methods in a try/catch block to handle exceptions.
            try
            {
                HttpResponseMessage response = await client.GetAsync("http://46.219.35.245/getdriverproperty?id=dht22&property=" + APIName);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);

                return responseBody;


            }
            catch
            {
                return "Error";
            }            
        }

        private async void GetTemperatureButton_Click(object sender, RoutedEventArgs e)
        {
            TemperatureText.Text = await Get("temperature");
        }

        private async void GetHumButton_Click(object sender, RoutedEventArgs e)
        {
            HumText.Text = await Get("humidity");
        }

        private async void GetHeatButton_Click(object sender, RoutedEventArgs e)
        {
            HeatText.Text = await Get("heatindex");
        }

        //
    }
}
