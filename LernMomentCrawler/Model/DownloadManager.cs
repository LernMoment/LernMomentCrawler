using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Text;

namespace LernMomentCrawlerUI.Model
{
    class DownloadManager
    {
        public long DurationOfLastDownloadInMs { get; private set; }

        public string DownloadPage(string url)
        {
            var watch = Stopwatch.StartNew();

            using var client = new WebClient();
            var result = client.DownloadString(url);

            watch.Stop();
            DurationOfLastDownloadInMs = watch.ElapsedMilliseconds;

            return result;
        }

    }
}
