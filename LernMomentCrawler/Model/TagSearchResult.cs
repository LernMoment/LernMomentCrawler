using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Navigation;

namespace LernMomentCrawlerUI.Model
{
    class TagSearchResult : ISearchPageResult, ISearchPageProfilingData
    {
        public string Url { get; private set; }
        public string Domain { get; private set; }
        public string TagName { get; private set; }
        public string Page { get; private set; }
        public IEnumerable<string> LinksOnPage { get; private set; }
        public int TagCount { get; private set; }

        public IEnumerable<string> TagOccurencesInContext => throw new NotImplementedException();

        public IEnumerable<string> GetChildUrls => throw new NotImplementedException();

        #region ProfilingData
        public ISearchPageProfilingData ProfilingData => this;
        public long PageDownloadTimeInMs { get; private set; }
        public long LinkSearchTimeInMs { get; private set; }
        public long TagCountSearchTimeInMs { get; private set; }
        public long CompleteProcessingTimInMs => throw new NotImplementedException();

        #endregion

        public TagSearchResult(string url, string domain, string tagName)
        {
            this.Url = url;
            this.Domain = domain;
            this.TagName = tagName;
        }

        public void AddPage(string page, long downloadTimeInMs)
        {
            this.Page = page;
            PageDownloadTimeInMs = downloadTimeInMs;
        }

        public void AddLinks(IEnumerable<string> links, long searchTimeInMs)
        {
            LinksOnPage = new List<string>(links);
            LinkSearchTimeInMs = searchTimeInMs;
        }

        public void AddTagCount(int count, long searchTimeInMs)
        {
            TagCount = count;
            TagCountSearchTimeInMs = searchTimeInMs;
        }
    }
}
