using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using rsl_challenge.Models;
using rsl_challenge.Services;

namespace rsl_challenge.Controllers
{
    public class HomeController : Controller
    {
        private readonly ItheLott _theLott;

        public HomeController(ItheLott theLott)
        {
            _theLott = theLott;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var model = new LotteryResultsList();
            //model = _theLott.GetLotteryResultsList();
            return View(model);
        }

        public IActionResult Draws()
        {

            var model = new DrawsList();

            model = _theLott.GetOpenDrawList();
            return View(model);
        }
    }
}
