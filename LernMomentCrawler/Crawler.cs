using System;
using System.Collections.Generic;
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
            using var client = new WebClient();
            var result = await client.DownloadStringTaskAsync(_rootUrl);

            return result;
        }
    }
}
