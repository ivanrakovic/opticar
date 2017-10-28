using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Opticar.Data
{
    public class OpticsDbContext : DbContext
    {
        public OpticsDbContext()
            : base("OpticsDb")
        {
            Configuration.LazyLoadingEnabled = false;
        }
    }
}