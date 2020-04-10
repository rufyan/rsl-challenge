using Microsoft.AspNetCore.Mvc;
using rsl_challenge.Models;
using rsl_challenge.Repository;
using rsl_challenge.Services;

namespace rsl_challenge.Controllers
{
    public class ResultsController : Controller
    {
        public IActionResult Draw(string productId)
        {
            return View(LotteryService.GetLotteryResultsList(productId));
        }
    }
}
