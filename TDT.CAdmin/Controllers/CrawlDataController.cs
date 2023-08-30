using Microsoft.AspNetCore.Mvc;

namespace TDT.CAdmin.Controllers
{
    public class CrawlDataController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
