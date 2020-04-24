using rsl_challenge.Models;
using System.Threading.Tasks;

namespace rsl_challenge.Services
{
    public interface ILotteryService
    {
        Task<T> GetApiResultsAsync<T>(string path, string productId) where T : class, ILottery;
        LotteryResultsList GetLotteryResultsList(string productId);
        DrawsList GetOpenDrawList();
    }
}
