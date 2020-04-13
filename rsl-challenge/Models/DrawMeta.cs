using System;

namespace rsl_challenge.Models
{
    public class DrawMeta
    {
        public string ProductId { get; set; }
        public int DrawNumber { get; set; }
        public DateTime DrawDate { get; set; }
        public string DrawDisplayName { get; set; }
        public string DrawLogoUrl { get; set; }
    }
}
