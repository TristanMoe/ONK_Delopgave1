using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CraftsmanApp.Models;

namespace CraftsmanApp.Data
{
    public class CraftsmanAppContext : DbContext
    {
        public CraftsmanAppContext (DbContextOptions<CraftsmanAppContext> options)
            : base(options)
        {
        }

        public DbSet<CraftsmanApp.Models.Craftsman> Craftsman { get; set; }
        public DbSet<CraftsmanApp.Models.Toolbox> Toolbox { get; set; }
        public DbSet<CraftsmanApp.Models.Tool> Tool { get; set; }

    }
}
