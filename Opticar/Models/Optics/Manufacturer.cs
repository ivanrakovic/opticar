using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Opticar.Models.Optics
{
    public class Manufacturer
    {
        public int ManufacturerId { get; set; }
        [Required]
        [MaxLength(50), MinLength(2)]
        public string Name { get; set; }
    }
}