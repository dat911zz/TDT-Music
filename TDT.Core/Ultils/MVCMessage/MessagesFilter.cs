using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Net;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Html;
using TDT.Core.Extensions;

namespace TDT.Core.Ultils.MVCMessage
{
    public class MessagesFilter : ActionFilterAttribute
	{
        private MessageViewData _messageViewData;
        private ITempDataDictionary _tempData;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                InitMessageViewData(filterContext);
                base.OnActionExecuting(filterContext);
            }
            catch (Exception)
            {

            }
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            try
            {
                DisplayModelStateErrors((Controller)filterContext.Controller);
                base.OnActionExecuted(filterContext);
            }
            catch (Exception)
            {
                
            }
            
        }

        private void InitMessageViewData(ActionExecutingContext filterContext)
        {
            try
            {
                Controller controller = (Controller)filterContext.Controller;
                _tempData = controller.TempData;
                _messageViewData = (!_tempData.ContainsKey("Messages")) 
                    ? new MessageViewData() : new MessageViewData(_tempData.Get< MessageViewData>("Messages"));
                _messageViewData.FlashMessageAdded += MessageViewData_FlashMessageAdded;
                controller.ViewData["Messages"] = (object)_messageViewData;
                controller.TempData.Save();
            }
            catch (InvalidCastException e) { }
        }

        private void MessageViewData_FlashMessageAdded(object sender, EventArgs e)
        {
            //_tempData["Messages"] = (object)_messageViewData;
			_tempData.Put("Messages", _messageViewData);
		}

        private void DisplayModelStateErrors(Controller currentController)
        {
            try
            {
				if (!currentController.ViewData.ModelState.IsValid)
				{
					string text = "Some errors have occured:";
					TagBuilder tagBuilder = new TagBuilder("ul");
					StringBuilder stringBuilder = new StringBuilder();
					foreach (KeyValuePair<string, ModelStateEntry> item in currentController.ViewData.ModelState)
					{
						if (((Collection<ModelError>)(object)item.Value.Errors).Count <= 0)
						{
							continue;
						}

						foreach (ModelError item2 in (Collection<ModelError>)(object)item.Value.Errors)
						{
							if (item2.Exception != null && (!string.IsNullOrWhiteSpace(item2.ErrorMessage) || 1 == 0))
							{
								TagBuilder tagBuilder2 = new TagBuilder("li");
								tagBuilder2.InnerHtml.SetHtmlContent(item2.ErrorMessage);
								stringBuilder.AppendLine(tagBuilder2.ToString());
							}
						}

						if (stringBuilder.Length != 0)
						{
							tagBuilder.InnerHtml.SetContent(stringBuilder.ToString());
							_messageViewData.AddErrorMessage(text + tagBuilder.ToString());
						}

						break;
					}
				}

				_messageViewData.FlashMessageAdded -= MessageViewData_FlashMessageAdded;
			}
			catch (InvalidCastException e) { }            
        }
    }
}
