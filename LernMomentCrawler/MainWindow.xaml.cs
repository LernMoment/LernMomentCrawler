using LernMomentCrawlerUI;
using LernMomentCrawlerUI.Model;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace LernMomentCrawler
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private readonly DispatcherTimer _timer;
        private TimeSpan _secondsSinceStart;

        private readonly TagSearchEngine _searchEngine;
        private CancellationTokenSource _cts;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<ISearchPageResult> TagSearchResults { get; private set; } = new ObservableCollection<ISearchPageResult>();
        
        private bool _isResultViewHidden = true;
        public bool IsResultViewHidden 
        {
            get { return _isResultViewHidden; } 
            private set
            {
                if (value != _isResultViewHidden)
                {
                    _isResultViewHidden = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private bool _isInfoDialog = true;
        public bool IsInfoDialog
        {
            get { return _isInfoDialog; }
            private set
            {
                if (value != _isInfoDialog)
                {
                    _isInfoDialog = value;
                    NotifyPropertyChanged();
                }
            }
        }


        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

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
            ShowLoadingState();
            TagSearchResults.Clear();

            try
            {
                var searchResult = _searchEngine.FindTagRecursive("task", 3);
                foreach (var item in searchResult)
                {
                    TagSearchResults.Add(item);
                }
                resultDataGrid.Items.SortDescriptions.Clear();
                resultDataGrid.Items.SortDescriptions.Add(new SortDescription("TagCount", ListSortDirection.Descending));
                resultDataGrid.Items.Refresh();
                completeProcessingTimeTB.Text = $"{_searchEngine.DurationOfLastSearchInMs}ms";
                downloadTimeTB.Text = $"{_searchEngine.DurationOfDownloadInLastSearchInMs}ms";
                searchLinkTimeTB.Text = $"{_searchEngine.DurationOfLinkSearchInLastSearchInMs}ms";
                searchTagTimeTB.Text = $"{_searchEngine.DurationOfTagSearchInLastSearchInMs}ms";
                IsResultViewHidden = false;
            }
            catch (TaskCanceledException)
            {
                //resultHtmlView.Text = "Download von Index-Seite abgebrochen.";
            }
            finally
            {
                loadWebSiteButton.IsEnabled = true;
                cancelLoadWebSiteButton.IsEnabled = false;
            }

            Debug.WriteLine("LoadLernMomentDe Methode wird verlassen!");
        }

        private void ShowLoadingState()
        {
            loadWebSiteButton.IsEnabled = false;
            cancelLoadWebSiteButton.IsEnabled = true;
            IsResultViewHidden = true;
            IsInfoDialog = false;
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
                foreach (var occurence in item.TagOccurencesInContext)
                {
                    result += $"    {occurence}" + Environment.NewLine;
                }
            }

            return result;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //resultHtmlView.Text = "Hier werden die geladenen Daten angezeigt!";
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

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
