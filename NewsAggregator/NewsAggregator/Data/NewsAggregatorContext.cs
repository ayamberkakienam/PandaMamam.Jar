using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NewsAggregator.Models
{
    public class NewsAggregatorContext : DbContext
    {
        public NewsAggregatorContext (DbContextOptions<NewsAggregatorContext> options)
            : base(options)
        {
        }

        public DbSet<NewsAggregator.Models.Berita> Berita { get; set; }
    }
}
