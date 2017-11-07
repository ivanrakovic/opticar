using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Opticar.Models.Optics
{
    public class Layer
    {
        public int LayerId { get; set; }
        [StringLength(100)]
        [MaxLength(50), MinLength(2)]
        [Index("IX_LayerName", IsUnique = true)]
        public string Name { get; set; }
        public int ManufacturerId { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
    }
}