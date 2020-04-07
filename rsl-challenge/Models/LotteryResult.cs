using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rsl_challenge.Models
{
    public class LotteryResult : DrawMeta
    {
        //Result data, inheriting DrawMeta
        public List<int> PrimaryNumbers { get; set; }
        public List<int> SecondaryNumbers { get; set; }
        public string TicketNumbers { get; set; }
        public List<Dividend> Dividends { get; set; }
    }
}
