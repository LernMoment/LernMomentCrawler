using System;
using System.Collections.Generic;
using System.Text;

namespace LernMomentCrawlerUI.Model
{
    class SearchJob
    {
        public string Url { get; private set; }
        public string TagName { get; private set; }
        public int AllowedRecursionsFromHere { get; private set; }

        public SearchJob(string url, string tag, int recursionLevel)
        {
            this.Url = url;
            TagName = tag;
            AllowedRecursionsFromHere = recursionLevel;
        }
    }
}
