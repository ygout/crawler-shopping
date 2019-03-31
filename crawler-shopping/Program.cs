using crawler_shopping.src.Crawler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crawler_shopping
{
    class Program
    {
        static void Main(string[] args)
        {
            Crawler crawler = new Crawler(5);

            try
            {

                crawler.Crawl("https://www.coursesu.com/drive-coursesulyon").Wait();
            }
            catch (AggregateException e)
            {
                foreach (Exception ex in e.InnerExceptions)
                {
                    Console.WriteLine(ex.InnerException);
                }
                Console.ReadLine();
            }
        }
    }
}
