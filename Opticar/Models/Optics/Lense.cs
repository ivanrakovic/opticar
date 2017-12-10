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
        [StringLength(100)]
        [Index("IX_LenseNameDesc", IsUnique = true)]
        public string LenseName { get; set; }
        [Required]
        public bool Lager { get; set; }
        [Required]
        public bool LocalLager { get; set; }
        [Required]
        public bool Special { get; set; }
        public virtual Layer Layer { get; set; }
        public virtual Material Material { get; set; }
        public virtual LenseType LenseType { get; set; }
    }
}