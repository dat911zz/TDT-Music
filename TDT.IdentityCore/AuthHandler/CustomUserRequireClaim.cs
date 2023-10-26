using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDT.IdentityCore.AuthHandler
{
    public class CustomUserRequireClaim : IAuthorizationRequirement
    {
        public string ClaimType { get; }
        public CustomUserRequireClaim(string claimType)
        {
            ClaimType = claimType;
        }
    }
}
