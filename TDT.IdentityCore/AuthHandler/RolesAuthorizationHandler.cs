using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TDT.Core.DTO;
using TDT.Core.Ultils;

namespace TDT.IdentityCore.AuthHandler
{
    public class RolesAuthorizationHandler : AuthorizationHandler<RolesAuthorizationRequirement>, IAuthorizationHandler
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                       RolesAuthorizationRequirement requirement)
        {
            if (context.User == null || !context.User.Identity.IsAuthenticated)
            {
                context.Fail();
                return Task.CompletedTask;
            }

            var validRole = false;
            if (requirement.AllowedRoles == null ||
                requirement.AllowedRoles.Any() == false)
            {
                validRole = true;
            }
            else
            {
                var claims = context.User.Claims;
                var userName = claims.FirstOrDefault(c => c.Type == "UserName").Value;
                var roles = requirement.AllowedRoles;

                //Detect role right below
                var apiResponse = APICallHelper.Get<ResponseDataDTO<UserDTO>>("user", token: context.User.Claims.FirstOrDefault(c => c.Type.Equals("token")).Value).Result;
                if (apiResponse == null || apiResponse.Data == null || apiResponse.Code == Core.Enums.APIStatusCode.AccessDenied)
                {
                    context.Fail();
                }
                else
                {
                    //validRole = apiResponse.Data.Where(p => roles.Contains(p.Role) && p.UserName == userName).Any();
                }
            }

            if (validRole)
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }
            return Task.CompletedTask;
        }
    }
}
