using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Opticar.Models.Base;

namespace Opticar.Models.ViewModels
{
    public class MaterialViewModel
    {
        public int MaterialId { get; set; }
        [Required]
        public decimal Value { get; set; }
        [Required]
        public int MaterialTypeId { get; set; }
        public IEnumerable<SelectListItem> MaterialTypes { get; set; }
    }
}