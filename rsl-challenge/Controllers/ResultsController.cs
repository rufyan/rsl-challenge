using Microsoft.AspNetCore.Mvc;
using rsl_challenge.Services;

namespace rsl_challenge.Controllers
{
    public class ResultsController : Controller
    {
        private readonly ILotteryService _lotteryService;

        public ResultsController(ILotteryService LotteryService)
        {
            _lotteryService = LotteryService;
        }

        public IActionResult Draw([Bind(Prefix="id")]string productId) => View(_lotteryService.GetLotteryResultsList(productId));
    }
}
