using LernMomentCrawlerUI;
using LernMomentCrawlerUI.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

        private readonly TagSearchEngine _searchEngine;
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

            _searchEngine = new TagSearchEngine("http://localhost:63266/", "localhost:63266");
        }

        private void LoadWebSiteButton_Click(object sender, RoutedEventArgs e)
        {
            LoadLernMomentDe();
        }

        private void LoadLernMomentDe()
        {
            loadWebSiteButton.IsEnabled = false;
            cancelLoadWebSiteButton.IsEnabled = true;
            resultHtmlView.Text = "Hole Daten vom Server!";

            try
            {
                var searchResult = _searchEngine.FindTagRecursive("task", 3);
                resultHtmlView.Text = ConvertToStringWithDetails(searchResult, "task");
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

        private string ConvertToStringWithDetails(IEnumerable<ISearchPageResult> searchResults, string tag)
        {
            string result = $"Es wurden {searchResults.Count()} Seiten mit dem Begriff '{tag}' gefunden" + Environment.NewLine;

            foreach (var item in searchResults)
            {
                result += $"{item.Url}, {item.TagCount}" + Environment.NewLine;
            }

            return result;
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
