using Microsoft.AspNetCore.Mvc;
using rsl_challenge.Models;
using rsl_challenge.Repository;
using rsl_challenge.Services;

namespace rsl_challenge.Controllers
{
    public class HomeController : Controller
    {
        private readonly ItheLott _theLott;
        private readonly IDrawsRepository _drawRepository;

        public HomeController(ItheLott theLott, IDrawsRepository DrawRepository)
        {
            _theLott = theLott;
            _drawRepository = DrawRepository;
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
            var hydrateModel = _drawRepository.HydrateDraws(model);
            return View(hydrateModel);
        }
    }
}
