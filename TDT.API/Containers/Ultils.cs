using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Protocols;
using TDT.Core.Models;

namespace TDT.API.Containers
{
    public class Ultils
    {
        private QLDVModelDataContext db;
        private static Ultils instance;
        public static Ultils Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Ultils();
                }
                return instance;
            }
        }


        private Ultils() { }
        public QLDVModelDataContext Db { get => db; }

        public void Init(string conStr)
        {
            db = new QLDVModelDataContext(conStr);
        }
    }
}
