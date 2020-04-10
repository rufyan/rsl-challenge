using System.Collections.Generic;

namespace rsl_challenge.Models
{
    public class LotteryResultsList : ILotteryResultsList
    {
        public List<LotteryResult> DrawResults { get; set; }
    }

    public interface ILotteryResultsList
    {
        List<LotteryResult> DrawResults { get; set; }
    }
}
