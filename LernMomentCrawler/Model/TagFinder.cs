using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace LernMomentCrawlerUI.Model
{
    class TagFinder
    {
        private static readonly int _sectionLength = 60;

        public long DurationOfLastSearchInMs { get; private set; }

        public IEnumerable<string> FindTagOccurencesOnPage(string page, string tag)
        {
            var results = new List<string>();
            var watch = Stopwatch.StartNew();

            int pos = 0;
            var lowerPage = page.ToLower();
            while ((pos < lowerPage.Length) && (pos = lowerPage.IndexOf(tag.ToLower(), pos)) != -1)
            {
                if ((pos > _sectionLength / 2) && (pos + _sectionLength + tag.Length < page.Length))
                {
                    results.Add(lowerPage.Substring(pos - _sectionLength / 2, _sectionLength + tag.Length));
                }
                else
                {
                    int start = pos - _sectionLength / 2 > 0 ? pos - _sectionLength / 2 : 0;
                    int count = pos + _sectionLength + tag.Length > page.Length ? page.Length - pos : pos + _sectionLength + tag.Length;

                    results.Add(lowerPage.Substring(start, count));
                }
                pos += tag.Length;
            }

            watch.Stop();
            DurationOfLastSearchInMs = watch.ElapsedMilliseconds;

            return results;
        }
    }
}
