using System.ComponentModel.DataAnnotations;

namespace Opticar.Models.Optics
{
    public class Material
    {
        public int MaterialId { get; set; }

        [Required]
        public decimal Value { get; set; }

        public MaterialType MaterialTypeId { get; set; }
        public MaterialType MaterialType { get; set; }
    }
}