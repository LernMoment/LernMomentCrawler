using LernMomentCrawlerUI;
using System;
using System.Diagnostics;
using System.Net;
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
            resultHtmlView.Text = "Hole Daten vom Server!";

            Task<string> downloadTask;
            try
            {
                downloadTask = _crawler.GetIndexPage();
                resultHtmlView.Text = await downloadTask;
                Debug.WriteLine("await downloadTask ist erfolgreich abgeschlossen!");
            }
            catch (TimeoutException ex)
            {
                resultHtmlView.Text = "Zeitüberschreitung beim Download der Index-Seite.";
                Debug.WriteLine($"TimeoutException beim async Aufruf von Crawler.GetIndexPage: {ex}");
            }
            finally
            {
                loadWebSiteButton.IsEnabled = true;
            }
            Debug.WriteLine("LoadLernMomentDe() ist jetzt beendet.");
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
