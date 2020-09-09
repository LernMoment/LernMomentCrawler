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
using System.Windows.Threading;

namespace LernMomentCrawler
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer _timer;
        private TimeSpan _time;

        public MainWindow()
        {
            InitializeComponent();

            _timer = new DispatcherTimer(TimeSpan.FromSeconds(1), DispatcherPriority.Normal, delegate
            {
                timerView.Text = _time.ToString("c");
                _time = _time.Add(TimeSpan.FromSeconds(1));
            }, Application.Current.Dispatcher);
        }

        private void LoadWebSiteButton_Click(object sender, RoutedEventArgs e)
        {
            using var client = new HttpClient();
            using var result = client.GetAsync("http://localhost:63093/lernmoment/10").Result;
            resultHtmlView.Text = result.Content.ReadAsStringAsync().Result;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _time = new TimeSpan(0);
            _timer.Start();
        }
    }
}
