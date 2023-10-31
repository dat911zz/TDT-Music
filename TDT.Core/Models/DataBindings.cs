using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using TDT.Core.DTO;
using TDT.Core.Models;
using TDT.Core.Ultils;

namespace TDT.Core.Models
{
    public class DataBindings
    {
        private static DataBindings instance;
        public static DataBindings Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataBindings();
                }
                return instance;
            }
        }
        private DataBindings(){}
        public IList<RoleDTO> Roles { get; set; }
        public IList<PermissionDTO> Permissions { get; set; }
        public IList<UserDTO> Users { get; set; }

        public string LoginAsAPI()
        {
            var auth = APICallHelper.Post<AuthDTO>("auth/login?isCadmin=true", new LoginModel()
            {
                UserName = "API",
                Password = "123"
            }.ToString()).Result;
            return auth.Token;
        }
        public void LoadDataFromAPI(HttpContext context, ILogger logger, int iterator = 2000)
        {
            try
            {
                new Thread(async () =>
                {
                    string token = "";
                    if (context != null)
                    {
                        token = context.User.Claims.FirstOrDefault(c => c.Type.Equals("token")).Value;
                    }
                    await LoadUsers(token, logger, iterator);
                    await LoadRoles(token, logger, iterator);
                    await LoadPermissions(token, logger, iterator);
                }).Start();
                
            }
            catch (System.Exception ex)
            {
                logger.LogCritical(ex, "Exception");
            }
        }
        public async Task LoadRoles(string token, ILogger logger, int iterator = 2000)
        {
            if (string.IsNullOrEmpty(token))
            {
                token = LoginAsAPI();
            }
            ResponseDataDTO<RoleDTO> rolesRes = await APICallHelper.Get<ResponseDataDTO<RoleDTO>>("Role", token: token);
            Task.Delay(iterator).Wait();
            Roles = rolesRes.Data;
        }
        public async Task LoadPermissions(string token, ILogger logger, int iterator = 2000)
        {
            if (string.IsNullOrEmpty(token))
            {
                token = LoginAsAPI();
            }
            ResponseDataDTO<PermissionDTO> permsRes = await APICallHelper.Get<ResponseDataDTO<PermissionDTO>>("Permission", token: token);
            Task.Delay(iterator).Wait();
            Permissions = permsRes.Data;
        }
        public async Task LoadUsers(string token, ILogger logger, int iterator = 2000)
        {
            if (string.IsNullOrEmpty(token))
            {
                token = LoginAsAPI();
            }
            ResponseDataDTO<UserDTO> usersRes = await APICallHelper.Get<ResponseDataDTO<UserDTO>>("User", token: token);
            Task.Delay(iterator).Wait();
            Users = usersRes.Data;
        }
    }
}
