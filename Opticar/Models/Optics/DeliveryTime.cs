using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Opticar.Models.Optics
{
    public class DeliveryTime
    {
        public int DeliveryTimeId { get; set; }
        [Required]
        [StringLength(100)]
        [Index("IX_DeliveryTimeDesc", IsUnique = true)]
        public string Description { get; set; }

        public virtual ICollection<Lense> Lenses { get; set; }
    }
}