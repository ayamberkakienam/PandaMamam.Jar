using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using HtmlAgilityPack;
using System.Net.Http; 

namespace NewsAggregator.Models
{
    public class HtmlParser
    {
        public static async void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new NewsAggregatorContext(
                serviceProvider.GetRequiredService<DbContextOptions<NewsAggregatorContext>>()))
            {
                string url1, http1, konten1;
                HtmlDocument doc1= new HtmlDocument();
                var client1 = new HttpClient();
                foreach (Berita berita in context.Berita)
                {
                    //Console.WriteLine(berita.link);
                    //Console.WriteLine(berita.title);
                    berita.content = "gagal coba";
                    
                    url1 = berita.link;
                    http1 = client1.GetStringAsync(url1).Result;
                    doc1.LoadHtml(http1);
                    //doc1.LoadHtml(http1);
                    //await Task.Delay(5000);
                    konten1 = "";
                    foreach (var paragraf in doc1.DocumentNode.Descendants("p"))
                    {
                        konten1 += paragraf.InnerText;
                    }
                    berita.content = konten1;
                }
                context.SaveChanges();
                string url = "https://otomotif.tempo.co/read/news/2017/04/27/295870127/beli-honda-cr-v-turbo-berapa-harganya";
                var client = new HttpClient();
                string http = client.GetStringAsync(url).Result;
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(http);
                string konten = "";
                foreach (var paragraf in doc.DocumentNode.Descendants("p"))
                {
                    konten += paragraf.InnerText;
                }
                Console.WriteLine(konten);
            }
        }
    }
}
