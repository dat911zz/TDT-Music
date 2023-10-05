using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TDT.API.Models;
using TDT.Core.Models;

namespace TDT.API.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _cfg;
        private readonly ILogger<HomeController> _logger;
        private readonly QLDVModelDataContext _db;

        public HomeController(IConfiguration cfg, ILogger<HomeController> logger, QLDVModelDataContext db)
        {
            _logger = logger;
            _cfg = cfg;
            _db = db;
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
