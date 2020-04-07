using Microsoft.AspNetCore.Mvc;
using rsl_challenge.Models;

namespace rsl_challenge.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            var model = new LotteryResultsList();
            model = Services.theLott.GetLotteryResultsList();
            return View(model);
        }

        public IActionResult Draws()
        {
            var model = new DrawsList();
            model = Services.theLott.GetOpenDrawList();
            return View(model);
        }
    }
}
