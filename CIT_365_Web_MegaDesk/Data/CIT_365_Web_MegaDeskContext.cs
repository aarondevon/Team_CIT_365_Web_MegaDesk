using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CIT_365_Web_MegaDesk.Models
{
    public class CIT_365_Web_MegaDeskContext : DbContext
    {
        public CIT_365_Web_MegaDeskContext (DbContextOptions<CIT_365_Web_MegaDeskContext> options)
            : base(options)
        {
        }

        public DbSet<CIT_365_Web_MegaDesk.Models.Quote> Quote { get; set; }
    }
}
