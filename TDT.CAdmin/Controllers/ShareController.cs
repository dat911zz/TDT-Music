using Microsoft.AspNetCore.Mvc;
using System;
using TDT.Core.Ultils.MVCMessage;

namespace TDT.CAdmin.Controllers
{
	public class ShareController : Controller
	{
		protected MessageViewData Messages
		{
			get
			{
				if (!this.ViewData.ContainsKey(nameof(Messages)))
					throw new InvalidOperationException("Messages are not available. Did you add the MessageFilter attribute to the controller?");
				return (MessageViewData)this.TempData[nameof(Messages)];
			}
		}
	}
}
