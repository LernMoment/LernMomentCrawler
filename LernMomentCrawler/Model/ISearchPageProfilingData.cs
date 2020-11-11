using System;
using System.Collections.Generic;
using System.Text;

namespace LernMomentCrawlerUI.Model
{
    public interface ISearchPageProfilingData
    {
        public long PageDownloadTimeInMs { get; }
        public long LinkSearchTimeInMs { get; }
        public long TagCountSearchTimeInMs { get; }
        public long CompleteProcessingTimInMs { get; }
    }
}
