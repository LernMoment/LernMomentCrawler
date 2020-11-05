using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LernMomentCrawlerUI
{
    class Crawler
    {
        private readonly string _rootUrl;

        public Crawler(string rootUrl)
        {
            _rootUrl = rootUrl;
        }

        public async Task<string> GetIndexPage()
        {
            var webClientTask = DownloadAndTrace(_rootUrl);
            var timeoutTask = Task.Delay(TimeSpan.FromSeconds(5));

            var completedTask = await Task.WhenAny(webClientTask, timeoutTask);

            if (completedTask == timeoutTask)
            {
                throw new TimeoutException("LernMoment-Server antwortet nicht.");
            }

            return await webClientTask;
        }

        private async Task<string> DownloadAndTrace(string url)
        {
            using var client = new WebClient();
            var webClientTask = client.DownloadStringTaskAsync(url);
            var result = await webClientTask;
            Debug.WriteLine("DownloadAndTrace ist abgeschlossen!");
            return result;
        }
    }
}
