using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebsiteMama.Models;

namespace WebsiteMama.Data
{
    public class WebsiteMamaContext : DbContext
    {
        public WebsiteMamaContext (DbContextOptions<WebsiteMamaContext> options)
            : base(options)
        {
        }

        public DbSet<WebsiteMama.Models.BlogEntry> BlogEntry { get; set; }
    }
}
