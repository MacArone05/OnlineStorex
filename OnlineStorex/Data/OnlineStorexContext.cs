#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineStorex.Pages;

namespace OnlineStorex.Data
{
    public class OnlineStorexContext : DbContext
    {
        public OnlineStorexContext (DbContextOptions<OnlineStorexContext> options)
            : base(options)
        {
        }

        public DbSet<OnlineStorex.Pages.Store> Store { get; set; }
    }
}
