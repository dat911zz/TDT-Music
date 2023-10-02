using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TDT.API.Containers;
using TDT.API.Models;

namespace TDT.API.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _cfg;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IConfiguration cfg, ILogger<HomeController> logger)
        {
            _logger = logger;
            _cfg = cfg;
            Ultils.Instance.Init(cfg.GetConnectionString("Local"));
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Index?");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
