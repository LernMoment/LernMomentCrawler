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

namespace LernMomentCrawler
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoadWebSiteButton_Click(object sender, RoutedEventArgs e)
        {
            using var client = new HttpClient();
            using var result = client.GetAsync("http://localhost:63093/lernmoment/10").Result;
            resultHtmlView.Text = result.Content.ReadAsStringAsync().Result;
        }
    }
}
