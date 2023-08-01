using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using TDT.Core.IService;
using TDT.Core.Models;
using TDT.Core.ServiceImp;

namespace TDT.CAdmin.Services
{
    public class IdentityEmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            try
            {
                IMailingService<SMail> mailing = MailingService.Instance;
                SMail mail = new SMail("", "datcy2011@gmail.com", "Xin Chào", "Súp pờ rai mo đờ phắc cờ!");
                mailing.MailSender(mail);
                return Task.FromResult(1);
            }
            catch (System.Exception)
            {
                return Task.FromResult(0);
            }
            
        }
    }
}
