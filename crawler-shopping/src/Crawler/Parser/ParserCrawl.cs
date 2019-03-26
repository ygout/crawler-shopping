using System;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crawler_shopping.src.Crawler.Parser
{
    public class ParserCrawl
    {
        /// <summary>
        /// Return an array string url about a html document
        /// </summary>
        /// <param name="htmlDoc"></param>
        /// <returns>List<string></returns>
        public List<string> ExtractAllLinks(HtmlDocument htmlDoc)
        {
            List<string> urls = new List<string>();

            HtmlNodeCollection linksNode = htmlDoc.DocumentNode.SelectNodes("//a");

            foreach (HtmlNode link in linksNode)
            {
                string linkHref = link.Attributes["href"].Value;
                // don't add link's doublon
                if (!urls.Contains(linkHref))
                {
                    urls.Add(linkHref);
                }
            }
            return urls;
        }

        /// <summary>
        /// Return Html about an string content html
        /// </summary>
        /// <param name="content"></param>
        /// <returns>HtmlDocument</returns>
        public HtmlDocument LoadContent(string content)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument htmlDoc = new HtmlDocument();
            try
            {
                htmlDoc.LoadHtml(content);
            }
            catch(Exception exception)
            {
                Console.WriteLine($"Error parsing html {exception}");
            }
            return htmlDoc;
        }
    }
}
