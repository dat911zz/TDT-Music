using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace TDT.CAdmin.Models
{
    public class RealtimeHub : Hub
    {
        public async Task SendRealtimeContent(string htmlContent)
        {
            await Clients.All.SendAsync("ReceiveRealtimeContent", htmlContent);
        }
    }
}
