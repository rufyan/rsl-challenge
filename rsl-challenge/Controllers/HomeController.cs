using Microsoft.AspNetCore.Mvc;
using rsl_challenge.Models;
using rsl_challenge.Repository;
using rsl_challenge.Services;

namespace rsl_challenge.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() {
            var drawsList = new DrawsList();
            drawsList = LotteryService.GetOpenDrawList();
            //If drawsList contains data, hydrate it for the view
            var hydratedModel = drawsList != null && drawsList.Draws.Count > 0 ? DrawRepository.HydrateDraws(drawsList) : null;
            return View(hydratedModel);
        }
    }
}
