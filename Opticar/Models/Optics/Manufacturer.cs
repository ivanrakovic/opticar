using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc.Html;

namespace Opticar.Models.Optics
{
    public class Manufacturer
    {
        public int ManufacturerId { get; set; }
        [Required]
        [StringLength(100)]
        [MaxLength(50), MinLength(2)]
        [Index("IX_ManufacturerName", IsUnique = true)]
        public string Name { get; set; }
    }
}