using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDT.Core.IService
{
    public interface IMailingService<T>
    {
        public void MailSender(T mailObj);
    }
}
