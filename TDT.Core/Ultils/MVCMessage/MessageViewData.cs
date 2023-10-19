using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDT.Core.Ultils.MVCMessage
{
    [Serializable]
    public class MessageViewData
    {
        private readonly IDictionary<string, IList<string>> _messages = new Dictionary<string, IList<string>>();

        private readonly IDictionary<string, IList<string>> _flashMessages = new Dictionary<string, IList<string>>();

        private readonly IDictionary<string, object[]> _messageParams = new Dictionary<string, object[]>();

        public IDictionary<string, IList<string>> Messages => _messages;

        public IDictionary<string, IList<string>> FlashMessages => _flashMessages;

        public IDictionary<string, object[]> MessageParams => _messageParams;

        public bool HasFlashMessages
        {
            get
            {
                int count = 0;
                foreach (var item in MessageType.GetTypes())
                {
                    count += _flashMessages[item].Count;
				}
                return count > 0;
			}
        }

        public event EventHandler FlashMessageAdded;

        public IDictionary<string, IList<string>> GetDisplayMessages()
        {
            IDictionary<string, IList<string>> dictionary = new Dictionary<string, IList<string>>();
            foreach (KeyValuePair<string, IList<string>> message in _messages)
            {
                dictionary.Add(message.Key, new List<string>());
                foreach (string item in message.Value)
                {
                    if (_messageParams.ContainsKey(item))
                    {
                        dictionary[message.Key].Add(string.Format(item, _messageParams[item]));
                    }
                    else
                    {
                        dictionary[message.Key].Add(item);
                    }
                }
            }

            return dictionary;
        }

        protected void OnFlashMessageAdded()
        {
            if (this.FlashMessageAdded != null)
            {
                this.FlashMessageAdded(this, EventArgs.Empty);
            }
        }

        public MessageViewData()
        {
            Initialize();
        }

        public MessageViewData GetFlashMessages()
        {
            MessageViewData messageViewData = new MessageViewData();
            foreach (KeyValuePair<string, IList<string>> flashMessage in _flashMessages)
            {
                messageViewData.Messages[flashMessage.Key] = flashMessage.Value;
            }

            return messageViewData;
        }

        public MessageViewData(MessageViewData messagesFromPreviousRequest)
        {
            Initialize();
            if (messagesFromPreviousRequest == null)
            {
                return;
            }

            foreach (KeyValuePair<string, IList<string>> message in messagesFromPreviousRequest.Messages)
            {
                _messages[message.Key] = message.Value;
            }

            foreach (KeyValuePair<string, object[]> messageParam in messagesFromPreviousRequest.MessageParams)
            {
                _messageParams.Add(messageParam.Key, messageParam.Value);
            }
        }

        public void AddMessage(string message, ToastMessageType type = ToastMessageType.Info)
        {   
            AddMessage(message, type.ToString().ToLower(), persistForNextRequest: false);
        }

        public void AddMessageWithParams(string message, ToastMessageType type = ToastMessageType.Info, params object[] parameters)
        {
            AddMessage(message, type.ToString().ToLower(), persistForNextRequest: false);
            _messageParams[message] = parameters;
        }

        public void AddFlashMessage(string message, ToastMessageType type = ToastMessageType.Info)
        {
            AddMessage(message, type.ToString().ToLower(), persistForNextRequest: true);
        }

        public void AddFlashMessageWithParams(string message, ToastMessageType type = ToastMessageType.Info, params object[] parameters)
        {
            AddMessage(message, type.ToString().ToLower(), persistForNextRequest: true);
            _messageParams[message] = parameters;
        }

        public void AddErrorMessage(string errorMessage)
        {
            AddMessage(errorMessage, ToastMessageType.Error.ToString().ToLower());
        }

        public void AddErrorMessageWithParams(string errorMessage, params object[] parameters)
        {
            AddMessage(errorMessage, "error");
            _messageParams[errorMessage] = parameters;
        }

        public void AddErrorFlashMessage(string errorMessage)
        {
            AddMessage(errorMessage, "error", persistForNextRequest: true);
        }

        public void AddErrorFlashMessageWithParams(string errorMessage, params object[] parameters)
        {
            AddMessage(errorMessage, "error", persistForNextRequest: true);
            _messageParams[errorMessage] = parameters;
        }

        public void AddException(Exception exception)
        {
            AddException(exception, persistForNextRequest: false);
        }

        public void AddFlashException(Exception exception)
        {
            AddException(exception, persistForNextRequest: true);
        }

        private void AddException(Exception exception, bool persistForNextRequest)
        {
            AddMessage(exception.Message, "error", persistForNextRequest);
            while (exception.InnerException != null)
            {
                exception = exception.InnerException;
                AddMessage(exception.Message, "error", persistForNextRequest);
            }
        }

        private void AddMessage(string message, string messageType)
        {
            AddMessage(message, messageType, persistForNextRequest: false);
        }

        private void AddMessage(string message, string messageType, bool persistForNextRequest)
        {
            _messages[messageType].Add(new HtmlString(message).Value);
            if (persistForNextRequest)
            {
                _flashMessages[messageType].Add(message);
                OnFlashMessageAdded();
            }
        }

        private void Initialize()
        {
            _messages["info"] = new List<string>();
            _messages["success"] = new List<string>();
            _messages["warning"] = new List<string>();
			_messages["error"] = new List<string>();
			_flashMessages["info"] = new List<string>();
			_flashMessages["success"] = new List<string>();
			_flashMessages["warning"] = new List<string>();
			_flashMessages["error"] = new List<string>();
		}
    }
}
