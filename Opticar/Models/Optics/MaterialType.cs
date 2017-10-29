using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Opticar.Models.Optics
{
    public class MaterialType
    {
        public string MaterialTypeId { get; set; }
        [Required]
        public string Description { get; set; }

    }
}