using Microsoft.AspNetCore.Mvc;
using rsl_challenge.Services;

namespace rsl_challenge.Controllers
{
    public class ResultsController : Controller
    {
        public IActionResult Draw([Bind(Prefix="id")]string productId) => View(LotteryService.GetLotteryResultsList(productId));
    }
}
