using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace LernMomentCrawlerUI.Model
{
    class LinkFinder
    {
        private static readonly List<string> _blacklist = new List<string>() { "assets", ".png", ".ico", ".xml", "/tags/#" };
        private string _domain;

        public LinkFinder(string domain)
        {
            _domain = domain;
        }

        public long DurationOfLastLinkSearchInMs { get; private set; }

        public IEnumerable<string> FindLinksOnPage(string page)
        {
            var result = new List<string>();
            var watch = Stopwatch.StartNew();

            var linkParser = new Regex("href\\s*=\\s*(?:\"(?<1>[^\"]*)\"|(?<1>\\S+))", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            foreach (Match m in linkParser.Matches(page))
            {
                string aLink = m.Value;
                aLink = aLink.Replace("href=\"", "");
                aLink = aLink.Replace("\"", "");

                if (IsValidNewLink(aLink))
                {
                    result.Add(aLink);
                }
            }

            watch.Stop();
            DurationOfLastLinkSearchInMs = watch.ElapsedMilliseconds;

            return result;
        }

        private bool IsValidNewLink(string potentialNewLink)
        {
            if (!potentialNewLink.ToLower().Contains(_domain))
            {
                return false;
            }
            if (IsOnBlackList(potentialNewLink))
            {
                return false;
            }

            return true;
        }

        private bool IsOnBlackList(string aLink)
        {
            var isBlackListed = false;

            foreach (var item in _blacklist)
            {
                if (aLink.ToLower().Contains(item))
                {
                    isBlackListed = true;
                    break;
                }
            }

            return isBlackListed;
        }
    }
}
