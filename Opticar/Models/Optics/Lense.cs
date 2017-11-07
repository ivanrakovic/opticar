using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Opticar.Models.Optics
{
    public class Lense
    {
        public int LenseId { get; set; }
        [Required]
        [StringLength(20)]
        [Index("IX_ManufacturerLenseId", IsUnique = true)]
        public string ManufacturerLenseId { get; set; }
        [Required]
        [StringLength(20)]
        [Index("IX_InternalLenseId", IsUnique = true)]
        public string InternalLenseId { get; set; }

        [Required]
        [StringLength(100)]
        [Index("IX_LenseFullName", IsUnique = true)]
        public string FullName { get; set; }
        [Required]
        public bool Lager { get; set; }
        [Required]
        public bool LocalLager { get; set; }
        [Required]
        public bool Special { get; set; }

        [Required]
        public bool Transition { get; set; }
        [Required]
        public bool Sunglass { get; set; }
        [Required]
        public bool Polarisation { get; set; }

        [Required]
        public int BrandId { get; set; }
        [Required]
        public int LayerId { get; set; }
        [Required]
        public int LenseTypeId { get; set; }
        [Required]
        public int DeliveryTimeId { get; set; }
        [Required]
        public int LenseDesignId { get; set; }



       // public virtual Manufacturer Manufacturer { get; set; }
        public virtual Layer Layer { get; set; }
        public virtual LenseType LenseType { get; set; }
        public virtual DeliveryTime DeliveryTime { get; set; }
        public virtual LenseDesign LenseDesign { get; set; }


    }
}