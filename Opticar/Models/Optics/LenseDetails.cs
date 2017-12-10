using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Opticar.Models.Optics
{
    public class LenseDetails
    {
        public int LenseDetailsId { get; set; }
        
        
        public IEnumerable<Lense> Lenses { get; set; }
    }
}