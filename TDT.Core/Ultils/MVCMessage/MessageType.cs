using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDT.Core.Ultils.MVCMessage
{
	public enum ToastMessageType
	{
		Info,
		Success,
		Warning,
		Error
	}
	public class MessageType
	{
		public const string Info = "info";
		public const string Success = "success";
		public const string Warning = "warning";
		public const string Error = "error";

		public static string[] GetTypes()
		{
			return new string[4] { "info", "success", "warning", "error" };
		}
	}
}
