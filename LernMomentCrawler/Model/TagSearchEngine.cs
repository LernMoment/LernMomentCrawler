using Accessibility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

        public TagSearchResult FindTagRecursive(string tag, int recursionDepth)
        {
            Queue<SearchJob> jobsToProcess = new Queue<SearchJob>();
            List<TagSearchResult> allResults = new List<TagSearchResult>();

            jobsToProcess.Enqueue(new SearchJob(_rootUrl, tag, recursionDepth));
            while (jobsToProcess.Count > 0)
            {
                var currentJob = jobsToProcess.Dequeue();
                var currentResult = ProcessSingleUrl(currentJob.Url, tag);
                allResults.Add(currentResult);

                if (currentJob.AllowedRecursionsFromHere > 1)
                {
                    foreach (var link in currentResult.LinksOnPage)
                    {
                        jobsToProcess.Enqueue(new SearchJob(link, tag, currentJob.AllowedRecursionsFromHere - 1));
                    }
                }
            }

            var result = new TagSearchResult(_rootUrl, _domain, tag);
            var resultsWithoutDuplicates = allResults.Distinct().ToList();
            foreach (var searchResult in resultsWithoutDuplicates)
            {
                List<string> allLinks;
                if (result.LinksOnPage == null)
                {
                    allLinks = new List<string>();
                }
                else
                {
                    allLinks = new List<string>(result.LinksOnPage);

                }
                allLinks.AddRange(searchResult.LinksOnPage);
                result.AddLinks(allLinks, result.LinkSearchTimeInMs + searchResult.LinkSearchTimeInMs);
                result.AddTagCount(result.TagCount + searchResult.TagCount, result.TagCountSearchTimeInMs + searchResult.TagCountSearchTimeInMs);
            }

            return result;
        }

        private TagSearchResult ProcessSingleUrl(string url, string tag)
        {
            var watch = Stopwatch.StartNew();

            var result = new TagSearchResult(url, _domain, tag);

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
