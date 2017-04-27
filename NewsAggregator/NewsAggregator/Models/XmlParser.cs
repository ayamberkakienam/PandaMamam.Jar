using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Xml.Linq;
using System.Net.Http;

namespace NewsAggregator.Models
{
    public class XmlParser
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new NewsAggregatorContext(
                serviceProvider.GetRequiredService<DbContextOptions<NewsAggregatorContext>>()))
            {
                string url = "http://tempo.co/rss/terkini";
                var client = new HttpClient();
                string xml = client.GetStringAsync(url).Result;

                var result = XDocument.Parse(xml).Descendants("item");
                foreach (var entity in context.Berita)
                {
                    context.Berita.Remove(entity);
                }
                context.SaveChanges();
                foreach (var lv1 in result)
                {
                    context.Berita.Add(
                        new Berita
                        {
                            title = (string)lv1.Element("title"),
                            link = (string)lv1.Element("url"),
                            content = "coba coba"
                        });
                    context.SaveChanges();
                }
            }
        }
    }
}
