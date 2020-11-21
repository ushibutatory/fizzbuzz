using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NabeAtsu.Core;
using NabeAtsu.Web.Controllers.Abstracts;
using NabeAtsu.Web.Models;
using System.Diagnostics;

namespace NabeAtsu.Web.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(ILogger<HomeController> logger, IOptions<AppSettings> appSettings)
            : base(logger, appSettings)
        {
        }

        public IActionResult Index()
        {
            return View(new IndexViewModel
            {
                AppSettings = _appSettings,
                Start = 1,
                Count = 15,
            });
        }

        public IActionResult Submit(IndexViewModel form)
        {
            var player = new Player.Builder()
                .AutoBuild();

            var results = player.Answer(form.Start, form.Count);

            return View("Index", new IndexViewModel
            {
                AppSettings = _appSettings,
                Start = form.Start,
                Count = form.Count,
                Results = results,
            });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
