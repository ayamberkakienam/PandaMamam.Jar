using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;

namespace HtmlParserPrototype
{
    class HtmlParserPrototype
    {
        static void Main(string[] args)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument htmlDoc = web.Load("https://otomotif.tempo.co/read/news/2017/04/27/295870127/beli-honda-cr-v-turbo-berapa-harganya");
            if (htmlDoc == null)
            {
                Console.WriteLine("htmlDoc NULL");
            }
            else
            {
                htmlDoc.OptionFixNestedTags = true;
                HtmlNode artikel = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='artikel']");

                if (artikel == null)
                {
                    Console.WriteLine("artikel NULL");
                }
                else
                {
                    HtmlNodeCollection kontenBerita = artikel.SelectNodes("//p");
                    foreach (HtmlNode para in kontenBerita) {
                        Console.WriteLine(para.InnerText);
                    }
                }
            }

            Console.ReadKey();
        }
    }
}
