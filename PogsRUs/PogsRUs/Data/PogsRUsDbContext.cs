using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PogsRUs.Data
{
    public class PogsRUsDbContext : DbContext
    {
        public PogsRUsDbContext(DbContextOptions<PogsRUsDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO: Add Seeds here
        }

        //TODO: Add table references here.

    }
}
