using crawler_shopping.src.Entities;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crawler_shopping.src.Scraper.SuperU
{
    public class ScraperSuperU : IScraper
    {
        public bool IsProductHtml(HtmlDocument htmlDoc)
        {
            throw new NotImplementedException();
        }

        public bool IsProductsHtml(HtmlDocument htmlDoc)
        {
            // contain this id search-result-items <ul id="search-result-items">
            HtmlNodeCollection htmlProducts = htmlDoc.DocumentNode.SelectNodes("//ul[contains(@id,'search-result-items')]");
            if (htmlProducts.Count() == 0)
                return false;

            return true;
        }

        public Product ParseProduct(HtmlDocument htmlDoc)
        {
            throw new NotImplementedException();
        }

        public List<Product> ParseProducts(HtmlDocument htmlDoc)
        {
            HtmlNodeCollection htmlProducts = htmlDoc.DocumentNode.SelectNodes("//ul[contains(@id,'search-result-items')]");
            
            throw new NotImplementedException();
        }
    }
}
