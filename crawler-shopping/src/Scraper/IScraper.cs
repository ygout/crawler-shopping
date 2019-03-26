using crawler_shopping.src.Entities;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crawler_shopping.src.Scraper
{
    internal interface IScraper
    {
        Product ParseProduct(HtmlDocument htmlDoc);
        bool IsProductHtml(HtmlDocument htmlDoc);
    }
}
