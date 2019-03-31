using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crawler_shopping.src.Crawler
{
    /// <summary>
    /// 
    /// </summary>
    public class CrawlList
    {
        public readonly Queue<string> urlsToCrawl;
        public readonly List<string> urlsCompleted;
        /// <summary>
        /// Constructor
        /// </summary>
        public CrawlList()
        {
            urlsToCrawl = new Queue<string>();
            urlsCompleted = new List<string>();
        }
        /// <summary>
        /// queue is empty ?
        /// </summary>
        /// <returns>bool</returns>
        public bool HasNext()
        {
            return urlsToCrawl.Any();
        }
        /// <summary>
        /// Return next url into queue
        /// </summary>
        /// <returns>string</returns>
        public string GetNext()
        {
            urlsCompleted.Add(urlsToCrawl.Last());                  
            return urlsToCrawl.Dequeue();
        }
        /// <summary>
        /// Add urls to the queue
        /// </summary>
        /// <param name="urls"></param>
        public void AddUrls(List<string> urls)
        {
            foreach (var url in urls)
            {
                AddUrl(url);
            }
        }
        /// <summary>
        /// Add just one url to the queue
        /// </summary>
        /// <param name="url"></param>
        public void AddUrl(string url)
        {
            if (UrlAlreadyAdded(url)) return;

            urlsToCrawl.Enqueue(url);
        }
        /// <summary>
        /// Detect if url already exist into queue
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public bool UrlAlreadyAdded(string url)
        {
            return urlsToCrawl.Contains(url) || urlsCompleted.Contains(url);
        }
    }
}
