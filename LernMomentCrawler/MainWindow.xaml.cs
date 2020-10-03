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
        }

        private async void LoadWebSiteButton_Click(object sender, RoutedEventArgs e)
        {
            loadWebSiteButton.IsEnabled = false;
            resultHtmlView.Text = "Hole Daten vom Server!";

            try
            {
                await LoadLernMomentDe();
                Debug.WriteLine("UI: Wir haben KEINE Exception gefangen!");
            }
            catch(NotImplementedException ex)
            {
                Debug.WriteLine($"UI: Wir haben eine Exception gefangen: {ex}");
            }
            finally
            {
                loadWebSiteButton.IsEnabled = true;
            }
        }

        private async Task LoadLernMomentDe()
        {
            throw new NotImplementedException("Exception aus async void Method!");
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
