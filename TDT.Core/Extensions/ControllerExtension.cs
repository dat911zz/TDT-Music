using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDT.Core.Ultils.MVCMessage;

namespace TDT.Core.Extensions
{
	public static class ControllerExtension
	{
		public static MessageViewData MessageContainer(this Controller controller)
		{
			if (!controller.ViewData.ContainsKey("Messages"))
				throw new InvalidOperationException("Messages are not available. Did you add the MessageFilter attribute to the controller?");
			return (MessageViewData)controller.ViewData["Messages"];
		}
	}
}
