using LernMomentCrawlerUI;
using System;
using System.Diagnostics;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace LernMomentCrawler
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DispatcherTimer _timer;
        private TimeSpan _secondsSinceStart;

        private readonly Crawler _crawler;
        private CancellationTokenSource _cts;

        public MainWindow()
        {
            InitializeComponent();
            var timerTickHandler = new EventHandler((sender, args) =>
            {
                timerView.Text = _secondsSinceStart.ToString("c");
                _secondsSinceStart = _secondsSinceStart.Add(TimeSpan.FromSeconds(1));
            });

            _timer = new DispatcherTimer(TimeSpan.FromSeconds(1), 
                DispatcherPriority.Normal, 
                timerTickHandler, 
                Application.Current.Dispatcher);

            _crawler = new Crawler("http://localhost:63093/lernmoment/20");
        }

        private async void LoadWebSiteButton_Click(object sender, RoutedEventArgs e)
        {
            await LoadLernMomentDe();
        }

        private async Task LoadLernMomentDe()
        {
            loadWebSiteButton.IsEnabled = false;
            cancelLoadWebSiteButton.IsEnabled = true;
            resultHtmlView.Text = "Hole Daten vom Server!";

            _cts = new CancellationTokenSource();

            Task<string> downloadTask;
            try
            {
                downloadTask = _crawler.GetIndexPage(_cts.Token);
                resultHtmlView.Text = await downloadTask;
            }
            catch(TaskCanceledException)
            {
                resultHtmlView.Text = "Download von Index-Seite abgebrochen.";
            }
            finally
            {
                loadWebSiteButton.IsEnabled = true;
                cancelLoadWebSiteButton.IsEnabled = false;
            }

            Debug.WriteLine("LoadLernMomentDe Methode wird verlassen!");
        }

        private void CancelLoadWebSiteButton_Click(object sender, RoutedEventArgs e)
        {
            _cts.Cancel();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            resultHtmlView.Text = "Hier werden die geladenen Daten angezeigt!";
            _secondsSinceStart = new TimeSpan(0);
            _timer.Start();
        }

        private void StopTimerButton_Click(object sender, RoutedEventArgs e)
        {
            _timer.Stop();
        }

        private void RestartTimerButton_Click(object sender, RoutedEventArgs e)
        {
            _timer.Stop();
            _secondsSinceStart = new TimeSpan(0);
            _timer.Start();
        }
    }
}
