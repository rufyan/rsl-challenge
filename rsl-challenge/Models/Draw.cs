using System;

namespace rsl_challenge.Models
{
    public class Draw : DrawMeta
    {
        public string DrawType { get; set; }
        public decimal Div1Amount { get; set; }
        public bool IsDiv1Estimated { get; set; }
        public bool IsDiv1Unknown { get; set; }
        public DateTime DrawCloseDateTimeUTC { get; set; }
    }
}
