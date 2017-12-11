using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
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
        public DbSet<MaterialType> MaterialTypes { get; set; }
        public DbSet<Material> Materials { get; set; }

        public static OpticsDbContext Create()
        {
            return new OpticsDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }

        public DbSet<DeliveryTime> DeliveryTimes { get; set; }

        public DbSet<Layer> Layers { get; set; }

        public DbSet<LenseType> LenseTypes { get; set; }

        public DbSet<LenseDesign> LenseDesigns { get; set; }

        public System.Data.Entity.DbSet<Opticar.Models.Optics.Lense> Lenses { get; set; }
    }
}