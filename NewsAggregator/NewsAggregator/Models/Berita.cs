using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsAggregator.Models
{
    public class Berita
    {
        public int ID { get; set; }
        public string link { get; set; }
        public string title { get; set; }
        public string content { get; set; }
    }
}
