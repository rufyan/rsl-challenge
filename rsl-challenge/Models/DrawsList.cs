using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rsl_challenge.Models
{
    public class DrawsList
    {
        //Collection of draws
        public List<Draw> Draws { get; set; }
        public string ErrorInfo { get; set; }
        public bool Success { get; set; }
    }
}
