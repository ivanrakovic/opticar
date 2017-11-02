using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Opticar.Models.Optics
{
    public class Diameter
    {
        public int DiameterId { get; set; }
        [Required]
        [Index("IX_DiameterValue", IsUnique = true)]
        public decimal Value { get; set; }
    }
}