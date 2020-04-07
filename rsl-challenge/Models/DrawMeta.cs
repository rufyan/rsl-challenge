using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rsl_challenge.Models
{
    public class DrawMeta
    {
        //Draw metadata
        public string ProductId { get; set; }
        public int DrawNumber { get; set; }
        public DateTime DrawDate { get; set; }
        public string DrawDisplayName { get; set; }
        public string DrawLogoUrl { get; set; }
    }
}
