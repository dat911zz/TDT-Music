﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDT.IdentityCore.Filters
{
    public class SessionRequirementAttribute : TypeFilterAttribute
    {
        public SessionRequirementAttribute() : base(typeof(SessionRequirementFilter))
        {
        }
    }
}