using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;

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

        private async Task<string> Get(string id, string APIName)
        {
            // Call asynchronous network methods in a try/catch block to handle exceptions.
            try
            {
                //http://46.219.35.245/getdriverproperty?id=dht22&property=temperature
                //http://46.219.35.245/getdriverproperty?id=bmp280&property=pressure
                HttpResponseMessage response = await client.GetAsync("http://46.219.35.245/getdriverproperty?id=" + id + "&property=" + APIName);
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
            TemperatureText.Text = await Get("dht22", "temperature");
        }

        private async void GetHumButton_Click(object sender, RoutedEventArgs e)
        {
            HumText.Text = await Get("dht22", "humidity");
        }

        private async void GetHeatButton_Click(object sender, RoutedEventArgs e)
        {
            HeatText.Text = await Get("dht22", "heatindex");
        }
        private async void GetPressureButton_Click(object sender, RoutedEventArgs e)
        {
            PressureText.Text = await Get("bmp280", "pressure");
        }
        private async void GetAltitudeButton_Click(object sender, RoutedEventArgs e)
        {
            AltitudeText.Text = await Get("bmp280", "altitude");
        }
        private async void Getbmp280TemperatureButton_Click(object sender, RoutedEventArgs e)
        {
            bmp280TemperatureText.Text = await Get("bmp280", "temperature");
        }

        //
    }
}
