using System.Collections.Generic;

namespace rsl_challenge.Models
{
    public class LotteryResultsList : ILottery
    {
        public List<LotteryResult> DrawResults { get; set; }
    }
}
