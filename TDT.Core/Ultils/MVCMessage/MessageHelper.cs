using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDT.Core.Ultils.MVCMessage
{
	public class MessageHelper
	{
		private static MessageHelper instance;
		public static MessageHelper Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new MessageHelper();
				}
				return instance;
			}
		}
		private MessageHelper() { }
		//protected MessageViewData Messages
		//{
		//	get
		//	{
		//		if (!this.ViewData.ContainsKey(nameof(Messages)))
		//			throw new InvalidOperationException("Messages are not available. Did you add the MessageFilter attribute to the controller?");
		//		return (MessageViewData)this.ViewData[nameof(Messages)];
		//	}
		//}

	}
}
