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
            Console.WriteLine("Extrac all links");
            try
            {
                HtmlNodeCollection linksNode = htmlDoc.DocumentNode.SelectNodes("//a[@href]");
                foreach (HtmlNode link in linksNode)
                {
                    string linkHref = link.GetAttributeValue("href", string.Empty);
                   
                    // don't add link's doublon
                    if (linkHref != string.Empty && !urls.Contains(linkHref))
                    {
                        Console.WriteLine($"Link {linkHref}");
                        urls.Add(linkHref);
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine($"Error => {e}");
            }
            
            
            //Console.WriteLine("Urls: [{0}]", string.Join(", ", urls));
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
            Console.WriteLine("Content html parser");
            return htmlDoc;
        }
    }
}
