using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace LernMomentCrawlerUI.Model
{
    class TagFinder
    {
        private string _tag;

        public long DurationOfLastSearchInMs { get; private set; }

        public int CountTagsOnPage(string page, string tag)
        {
            int result = 0;
            var watch = Stopwatch.StartNew();

            int pos = 0;
            var lowerPage = page.ToLower();
            while ((pos < lowerPage.Length) && (pos = lowerPage.IndexOf(tag.ToLower(), pos)) != -1)
            {
                result += 1;
                pos += tag.Length;
            }

            watch.Stop();
            DurationOfLastSearchInMs = watch.ElapsedMilliseconds;

            return result;
        }
    }
}
