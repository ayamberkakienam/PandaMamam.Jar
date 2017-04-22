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
            XmlDocument doc =  new XmlDocument();
            doc.Load("http://rss.detik.com/index.php/detikcom");
            XmlNode node = doc.DocumentElement.SelectSingleNode("/rss/channel");

            foreach (XmlNode item in node)
            {
                XmlNode titleNode = item.SelectSingleNode("title");
                XmlNode urlNode = item.SelectSingleNode("link");

                if (titleNode != null && urlNode != null && item.Name == "item")
                {
                    string title = titleNode.InnerText;
                    string url = urlNode.InnerText;
                    Console.WriteLine(title);
                    Console.WriteLine(url);
                }
                else
                {
                    Console.WriteLine("node: null");
                }

                Console.WriteLine();
                // node = node.NextSibling;
            }

            string str = Console.ReadLine();
            Console.WriteLine(str);
        }
    }
}
