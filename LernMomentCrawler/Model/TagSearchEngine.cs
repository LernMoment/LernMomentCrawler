using Accessibility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace LernMomentCrawlerUI.Model
{
    class TagSearchEngine
    {
        private string _rootUrl;
        private string _domain;

        private DownloadManager _downloadManager;
        private LinkFinder _linkFinder;
        private TagFinder _tagFinder;

        public long DurationOfLastSearchInMs { get; private set; }

        public TagSearchEngine(string rootUrl, string domain)
        {
            _rootUrl = rootUrl;
            _domain = domain;

            _downloadManager = new DownloadManager();
            _linkFinder = new LinkFinder(_domain);
            _tagFinder = new TagFinder();
        }

        public TagSearchResult FindTag(string tag)
        {
            var watch = Stopwatch.StartNew();

            var result = new TagSearchResult(_rootUrl, _domain, tag);

            // download Page
            var page = _downloadManager.DownloadPage(_rootUrl);
            result.AddPage(page, _downloadManager.DurationOfLastDownloadInMs);

            // find links to other pages
            var links = _linkFinder.FindLinksOnPage(page);
            result.AddLinks(links, _linkFinder.DurationOfLastLinkSearchInMs);

            // find tags
            var tagCount = _tagFinder.CountTagsOnPage(page, tag);
            result.AddTagCount(tagCount, _tagFinder.DurationOfLastSearchInMs);

            watch.Stop();
            DurationOfLastSearchInMs = watch.ElapsedMilliseconds;

            return result;
        }

    }
}
