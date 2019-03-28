using crawler_shopping.src.DbConnection;
using crawler_shopping.src.Entities;
using crawler_shopping.src.Repository;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            HtmlNodeCollection htmlProducts = htmlDoc.DocumentNode.SelectNodes("//ul[contains(@class,'search-result-items')]");
            if (htmlProducts.Count() == 0)
                return false;

            Console.WriteLine("It's a Product page");
            return true;
        }

        public Product ParseProduct(HtmlDocument htmlDoc)
        {
            throw new NotImplementedException();
        }

        public List<Product> ParseProducts(HtmlDocument htmlDoc)
        {
            List<Product> products = new List<Product>();
            string categoryName = htmlDoc.DocumentNode
                                    .SelectSingleNode("//h1[contains(@class,'banner-title banner-title--category')]")
                                    .InnerText;

            CategoryRepository categoryRepository = new CategoryRepository(new ConnectionFactory());
            
            Category categoryObj = categoryRepository.GetByName(categoryName);
            
            if (categoryObj == null)
            {
                categoryObj = new Category()
                {
                    Uid = Guid.NewGuid().ToString(),
                    Name = categoryName
                };

                categoryRepository.Add(categoryObj);

                Console.WriteLine($"Category {categoryName} is added ");
            }
         
            

            var htmlProducts = htmlDoc.DocumentNode.SelectNodes("//ul[contains(@class,'search-result-items')]//li");

            foreach (HtmlNode htmlProduct in htmlProducts)
            {
                var name = htmlProduct.SelectSingleNode(".//h3[contains(@class,'product-name')]//a")
                                        .InnerText;

                var price = htmlProduct.SelectSingleNode(".//span[contains(@class,'sale-price')]")
                                        .ChildAttributes("data-item-price")
                                        .FirstOrDefault()
                                        .Value;

                var unitInfo = htmlProduct.SelectSingleNode(".//span[contains(@class,'unit-info')]")
                                        .InnerText;
                var imageUrl = htmlProduct.SelectSingleNode(".//div[contains(@class,'product-image')]")
                                        .Descendants("picture")
                                        .FirstOrDefault()
                                        .Descendants("img")
                                        .FirstOrDefault()
                                        .ChildAttributes("src")
                                        .FirstOrDefault()
                                        .Value;

                Product product = new Product()
                {
                    Uid = Guid.NewGuid().ToString(),
                    Name = name,
                    Price = Convert.ToDecimal(price.Replace(".", ",")),
                    ImageUrl = imageUrl,
                    UnitInfo = unitInfo,
                    Category = categoryObj.Uid
                };

                //Don't add doublon about name product
                if ((products.FindIndex(item => item.Name == product.Name)) < 0)
                {
                    products.Add(product);
                }

            }
            return products;
        }
    }
}
