using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using rsl_challenge.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
}
}
