using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Threading;
using System.Threading.Tasks;
using TDT.Core.Models;

namespace TDT.CAdmin.Controllers
{
    public class CrawlDataController : Controller
    {
        private readonly IHubContext<RealtimeHub> _hubContext;
        public CrawlDataController(IHubContext<RealtimeHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GenerateAndSendRealtimeContent()
        {
            for(int i = 0; i < 100; i++)
            {
                await _hubContext.Clients.All.SendAsync("ReceiveRealtimeContent", string.Format("<div>{0}</div>", i));
                Thread.Sleep(1000);
            }
            return Redirect("Index");
        }
    }
}
