using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace XmlParser
{
    class XmlParserPrototype
    {
        static void Main(string[] args)
        {
            string inpit = Console.ReadLine();
            string url = null;
            XmlDocument doc =  new XmlDocument();

            switch (inpit)
            {
                case "detik":
                    {
                        url = "http://rss.detik.com/index.php/detikcom";
                    }
                    break;
                case "tempo":
                    {
                        url = "https://www.tempo.co/rss/terkini";
                    }
                    break;

                case "antaranews":
                    {
                        url = "http://www.antaranews.com/rss/terkini";
                    }
                    break;

                case "vivanews":
                    {
                        url = "http://rss.viva.co.id/get/all";
                    }
                    break;
                default:
                    {
                        url = "url NULL";
                    }
                    break;
            }

            if (url != "url NULL")
            {
                doc.Load(url);
                XmlNodeList crawlResult = doc.GetElementsByTagName("item");
                foreach (XmlNode item in crawlResult)
                {
                    Console.WriteLine(item.SelectSingleNode("title").InnerText);
                    Console.WriteLine(item.SelectSingleNode("link").InnerText);
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine(url);
            }

            Console.ReadKey();
        }
    }
}
