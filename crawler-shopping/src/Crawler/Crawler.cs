﻿using crawler_shopping.src.Crawler.Parser;
using crawler_shopping.src.DbConnection;
using crawler_shopping.src.Entities;
using crawler_shopping.src.Repository;
using crawler_shopping.src.Scraper.SuperU;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace crawler_shopping.src.Crawler
{
    public class Crawler
    {
        public readonly CrawlList CrawlList;
        private readonly List<Task<string>> runningTasks = new List<Task<string>>();
        private readonly HttpClient client;
        private readonly int maxConcurrentDownload;

        static readonly List<string> urlsQueue = new List<string>();

        public Crawler(int maxConcurrentDownload)
        {
            CrawlList = new CrawlList();
            client = new HttpClient();
            this.maxConcurrentDownload = maxConcurrentDownload;
            ServicePointManager.DefaultConnectionLimit = maxConcurrentDownload;
        }

        public async Task<bool>Crawl(string startUrl)
        {
            runningTasks.Add(ProcessUrl(startUrl));

            // while list task is not empty
            while (runningTasks.Any())
            {
                Task<string> completedTask = await Task.WhenAny(runningTasks);
                Console.WriteLine("Task completed");
                Console.WriteLine($"Crawlist {CrawlList.urlsToCrawl.Count}");
                Console.WriteLine($"urlsCompleted {CrawlList.urlsCompleted.Count}");

                string pageHtml = await completedTask;
                runningTasks.Remove(completedTask);
                
                while (CrawlList.HasNext() && runningTasks.Count < maxConcurrentDownload)
                {
                    string url = CrawlList.GetNext();
                    runningTasks.Add(ProcessUrl(url));
                }
            }
            return true;
        }
        private async Task<string> ProcessUrl(string url)
        {
            Console.WriteLine("url " + url);
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                string content = await response.Content.ReadAsStringAsync();
                // Convert to htmlDoc
                ParserCrawl parserHtml = new ParserCrawl();
                HtmlDocument htmlDoc = parserHtml.LoadContent(content);
                // ExtracAllLinks
                CrawlList.AddUrls(parserHtml.ExtractAllLinks(htmlDoc));

                //// TODO if is a product add to bdd
                ScraperSuperU scraperSuperU = new ScraperSuperU();
                ProductRepository productRepository = new ProductRepository(new ConnectionFactory());
                if (scraperSuperU.IsProductsHtml(htmlDoc))
                {
                    Console.WriteLine("Is a products");
                    productRepository.AddProducts(scraperSuperU.ParseProducts(htmlDoc));
                }
                return content;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error process {ex}");
                return String.Empty;
            }
           
           
        }
    }
}
