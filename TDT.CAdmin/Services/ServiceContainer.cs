using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using TDT.Core.Models;

namespace TDT.CAdmin.Services
{
    public class ServiceContainer
    {
        private readonly IConfiguration config;
        private ServiceContainer instance;
        private QLDVModelDataContext dbContext;
        private ServiceContainer(IConfiguration config)
        {
            this.config = config;
            dbContext = new QLDVModelDataContext(config.GetConnectionString("Default"));
        }
        public ServiceContainer Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ServiceContainer();
                }
                return instance;
            }
        }

        public QLDVModelDataContext DbContext { get => dbContext; set => dbContext = value; }
    }
}
