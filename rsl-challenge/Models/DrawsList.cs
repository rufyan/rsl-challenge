using System.Collections.Generic;

namespace rsl_challenge.Models
{
    public class DrawsList : ILottery
    {
        public List<Draw> Draws { get; set; }
        public string ErrorInfo { get; set; }
        public bool Success { get; set; }
    }
}
