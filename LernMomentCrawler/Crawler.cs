using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
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

        public async Task<string> GetIndexPage(CancellationToken ct)
        {
            string result;

            // TODO: verwende den übergebenden CancellationToken an der passenden Stelle!
            
            using var client = new HttpClient();
            using (var response = await client.GetAsync(_rootUrl))
            {
                result = await response.Content.ReadAsStringAsync();
            }

            return result;
        }
    }
}
