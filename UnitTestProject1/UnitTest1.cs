using Microsoft.VisualStudio.TestTools.UnitTesting;
using crawler_shopping.src.Entities;
using System.Collections.Generic;
using crawler_shopping.src.Scraper.SuperU;
using System.Diagnostics;
using HtmlAgilityPack;
using System.IO;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestParseProducts()
        {
            ScraperSuperU scraperProduct = new ScraperSuperU();
            var htmlDoc = new HtmlDocument();
            string projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string file = Path.Combine(projectFolder, @"products.html");

            htmlDoc.Load(file);
            List<Product> products = scraperProduct.ParseProducts(htmlDoc);
            Assert.IsTrue(products.Count > 0);

        }

        [TestMethod]
        public void TestIsProductsHtml()
        {
            ScraperSuperU scraperProduct = new ScraperSuperU();
            var htmlDoc = new HtmlDocument();
            string projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string file = Path.Combine(projectFolder, @"products.html");

            htmlDoc.Load(file);
            bool isProductsHtml = scraperProduct.IsProductsHtml(htmlDoc);

            Assert.IsTrue(isProductsHtml, "Html file must be a products html");

        }
    }
}
