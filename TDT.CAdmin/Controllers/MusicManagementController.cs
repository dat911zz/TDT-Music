using Microsoft.AspNetCore.Mvc;

namespace TDT.CAdmin.Controllers
{
    public class MusicManagementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
