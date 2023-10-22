using Microsoft.AspNetCore.Mvc;

namespace TDT_Music.Controllers
{
    public class ArtistController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
