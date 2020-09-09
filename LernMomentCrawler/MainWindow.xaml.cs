using System;
using System.Net;
using System.Windows;
using System.Windows.Threading;

namespace LernMomentCrawler
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer _timer;
        private TimeSpan _secondsSinceStart;

        public MainWindow()
        {
            InitializeComponent();
            var handler = new EventHandler((sender, args) =>
            {
                timerView.Text = _secondsSinceStart.ToString("c");
                _secondsSinceStart = _secondsSinceStart.Add(TimeSpan.FromSeconds(1));
            });

            _timer = new DispatcherTimer(TimeSpan.FromSeconds(1), DispatcherPriority.Normal, handler, Application.Current.Dispatcher);
        }

        private void LoadWebSiteButton_Click(object sender, RoutedEventArgs e)
        {
            using var client = new WebClient();
            var result = client.DownloadString("http://localhost:63093/lernmoment/10");
            resultHtmlView.Text = result;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _secondsSinceStart = new TimeSpan(0);
            _timer.Start();
        }
    }
}
