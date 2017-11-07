using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Opticar.Models.Optics;
using System.Data.Entity.ModelConfiguration.Conventions;

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
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();           
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }

        public System.Data.Entity.DbSet<Opticar.Models.Optics.DeliveryTime> DeliveryTimes { get; set; }

        public System.Data.Entity.DbSet<Opticar.Models.Optics.Layer> Layers { get; set; }

        public System.Data.Entity.DbSet<Opticar.Models.Optics.LenseType> LenseTypes { get; set; }

        public System.Data.Entity.DbSet<Opticar.Models.Optics.LenseDesign> LenseDesigns { get; set; }

        public System.Data.Entity.DbSet<Opticar.Models.Optics.Lense> Lenses { get; set; }
    }
}