using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Opticar.Models.ViewModels
{
    public class LayersViewModel
    {
        public int LayerId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int ManufacturerId { get; set; }
        public IEnumerable<SelectListItem> Manufacturers { get; set; }
        public string SelectedText { get; set; }
    }
}