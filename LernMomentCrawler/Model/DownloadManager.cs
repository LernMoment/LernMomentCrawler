using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LernMomentCrawlerUI.Model
{
    class DownloadManager
    {
        public long DurationOfLastDownloadInMs { get; private set; }

        public async Task<string> DownloadPage(string url)
        {
            var watch = Stopwatch.StartNew();

            using var client = new WebClient();
            var result = await client.DownloadStringTaskAsync(url);

            watch.Stop();
            DurationOfLastDownloadInMs = watch.ElapsedMilliseconds;

            return result;
        }

    }
}
