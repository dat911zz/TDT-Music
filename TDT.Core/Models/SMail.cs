using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDT.Core.Models
{
    public class SMail
    {
        private string from, to, subject, body;

        public string From { get => from; set => from = value; }
        public string To { get => to; set => to = value; }
        public string Subject { get => subject; set => subject = value; }
        public string Body { get => body; set => body = value; }
        public SMail()
        {

        }
        public SMail(string from, string to, string subject, string body)
        {
            From = from;
            To = to;
            Subject = subject;
            Body = body;
        }
    }
}
