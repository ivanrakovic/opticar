using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Opticar.Models.Optics
{
    public class LenseType
    {
        public int LenseTypeId { get; set; }
        [Required]
        [StringLength(100)]
        [Index("IX_LenseTypeDesc", IsUnique = true)]
        public string DisplayName { get; set; }

        public virtual ICollection<Lense> Lenses { get; set; }
    }
}