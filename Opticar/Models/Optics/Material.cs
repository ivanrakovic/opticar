using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Opticar.Models.Optics
{
    public class Material
    {
        public int MaterialId { get; set; }

        [Required]
        public decimal Value { get; set; }
    
        public int MaterialTypeId { get; set; }
        public virtual MaterialType MaterialType { get; set; }
    }
}