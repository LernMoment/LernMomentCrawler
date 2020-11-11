using System;
using System.Collections.Generic;
using System.Text;

namespace LernMomentCrawlerUI.Model
{
    public interface ISearchPageResult
    {
        public string Url { get; }
        public string TagName { get; }

        /// <summary>
        /// The amount of occurences of the specified tag on this page
        /// </summary>
        public int TagCount { get; }

        /// <summary>
        /// Provides a phrase of 8 words around the Tag.
        /// </summary>
        /// <remarks>
        /// This gives a little context of each occurence of the Tag on this page.
        /// </remarks>
        public IEnumerable<string> TagOccurencesInContext { get; }

        /// <summary>
        /// Gets all urls on this page that link into the same domain.
        /// </summary>
        /// <remarks>
        /// Only direct childs of this page are provided here. For more details
        /// on the search results for children and their children use
        /// <c>ISearchPageCompositeResult</c>.
        /// </remarks>
        public IEnumerable<string> GetChildUrls { get; }

        /// <summary>
        /// Provides inside into the timing of this search
        /// </summary>
        public ISearchPageProfilingData ProfilingData { get; }
    }
}
