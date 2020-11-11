using System;
using System.Collections.Generic;
using System.Linq;
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
        public int TagCount 
        { 
            get
            {
                if (TagOccurencesInContext == null)
                {
                    return 0;
                }
                else
                {
                    return TagOccurencesInContext.Count();
                }
            }
        }

        public IEnumerable<string> TagOccurencesInContext { get; private set; } = null;

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

        public void AddTagOccurences(IEnumerable<string> occurences, long searchTimeInMs)
        {
            TagOccurencesInContext = occurences;
            TagCountSearchTimeInMs = searchTimeInMs;
        }
    }
}
