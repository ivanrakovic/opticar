using System.ComponentModel.DataAnnotations;

namespace Opticar.Models.Optics
{
    public class Material
    {
        public int MaterialId { get; set; }
        public MaterialType MaterialTypeId { get; set; }
        [Required]
        public decimal Value { get; set; }
    }
}