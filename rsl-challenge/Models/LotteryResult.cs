using System.Collections.Generic;

namespace rsl_challenge.Models
{
    public class LotteryResult : DrawMeta
    {
        public List<int> PrimaryNumbers { get; set; }
        public List<int> SecondaryNumbers { get; set; }
        public string TicketNumbers { get; set; }
        public List<Dividend> Dividends { get; set; }
    }
}
