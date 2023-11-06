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
        private DataBindings(){
        Users ??= new List<UserDTO>();
                    Roles ??= new List<RoleDTO>();
                    Permissions ??= new List<PermissionDTO>();}
        public IList<RoleDTO> Roles { get; set; }
        public IList<PermissionDTO> Permissions { get; set; }
        public IList<UserDTO> Users { get; set; }

        public string LoginAsAPI()
        {
            var request = Task.WhenAll(APICallHelper.Post<AuthDTO>("auth/login?isCadmin=true", new LoginModel()
            {
                UserName = "API",
                Password = "123"
            }.ToString())).Result;
            var auth = request[0];
            return auth.Token;
        }
        public void LoadDataFromAPI(HttpContext context, ILogger logger)
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

                    await LoadUsers(token);
                    await LoadRoles(token);
                    await LoadPermissions(token);
                }).Start();
                
            }
            catch (System.Exception ex)
            {
                logger.LogCritical(ex, "Exception");
            }
        }
        public async Task LoadRoles(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                token = LoginAsAPI();
            }
            ResponseDataDTO<RoleDTO>[] rolesRes = await Task.WhenAll(APICallHelper.Get<ResponseDataDTO<RoleDTO>>("Role", token: token));
            foreach (var role in rolesRes[0].Data)
            {
                if (!Roles.Any(r => r.Id == role.Id))
                {
                    Roles.Add(role);
                }
            }
            //Roles = rolesRes[0].Data;
        }
        public async Task LoadPermissions(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                token = LoginAsAPI();
            }
            ResponseDataDTO<PermissionDTO>[] permsRes = await Task.WhenAll(APICallHelper.Get<ResponseDataDTO<PermissionDTO>>("Permission", token: token));
            foreach (var perm in permsRes[0].Data)
            {
                if (!Permissions.Any(p => p.Id == perm.Id))
                {
                    Permissions.Add(perm);
                }
            }
            //Permissions = permsRes[0].Data;
        }
        public async Task LoadUsers(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                token = LoginAsAPI();
            }
            ResponseDataDTO<UserDTO>[] usersRes = await Task.WhenAll(APICallHelper.Get<ResponseDataDTO<UserDTO>>("User", token: token));
            foreach (var user in usersRes[0].Data)
            {
                if (!Users.Any(u => u.UserName.Equals(user.UserName)))
                {
                    Users.Add(user);
                }
            }
            //Users = usersRes[0].Data;
        }
    }
}
