using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDT.Core.Models
{
    public class RealtimeHub : Hub
    {
        public async Task SendRealtimeContent(string htmlContent)
        {
            await Clients.All.SendAsync("ReceiveRealtimeContent", htmlContent);
        }
    }
}
