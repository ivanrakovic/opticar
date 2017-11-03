using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Opticar.Models.Optics
{
    public class MaterialType
    {
        public int MaterialTypeId { get; set; }
        [Required]
        [StringLength(50)]
        [Index("IX_MaterialTypeDesc", IsUnique = true)]
        public string Description { get; set; }
        public virtual ICollection<Material> Materials { get; set; }
    }
}