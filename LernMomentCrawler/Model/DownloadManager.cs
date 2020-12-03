using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LernMomentCrawlerUI.Model
{
    class DownloadManager
    {
        // HttpClient sollte nicht für jeden Request neu erzeugt werden!!!
        private readonly HttpClient _client = new HttpClient();

        public long DurationOfLastDownloadInMs { get; private set; }

        public async Task<string> DownloadPage(string url)
        {
            var watch = Stopwatch.StartNew();

            string result = string.Empty;

            using (var response = await _client.GetAsync(url))
            {
                result = await response.Content.ReadAsStringAsync();
            }

            watch.Stop();
            DurationOfLastDownloadInMs = watch.ElapsedMilliseconds;

            return result;
        }

    }
}
