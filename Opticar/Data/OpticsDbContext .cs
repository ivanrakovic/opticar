using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Opticar.Models.Optics;

namespace Opticar.Data
{
    public class OpticsDbContext : DbContext
    {
        public OpticsDbContext()
            : base("name=DefaultConnection")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Diameter> Diameters { get; set; }

        public static OpticsDbContext Create()
        {
            return new OpticsDbContext();
        }
    }
}