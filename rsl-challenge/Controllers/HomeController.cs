using Microsoft.AspNetCore.Mvc;
using rsl_challenge.Models;
using rsl_challenge.Repository;
using rsl_challenge.Services;

namespace rsl_challenge.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDrawRepository _drawRepository;
        private readonly ILotteryService _lotteryService;
        public HomeController(IDrawRepository DrawRepository, ILotteryService  LotteryService)
        {
            _drawRepository = DrawRepository;
            _lotteryService = LotteryService;
        }

        public IActionResult Index() {
            var drawsList = new DrawsList();
            drawsList = _lotteryService.GetOpenDrawList();
            //If drawsList contains data, hydrate it for the view
            var hydratedModel = drawsList?.Draws.Count > 0 ? _drawRepository.HydrateDraws(drawsList) : null;
            return View(hydratedModel);
        }
    }
}

