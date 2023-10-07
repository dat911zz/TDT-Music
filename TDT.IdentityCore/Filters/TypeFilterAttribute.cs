using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDT.IdentityCore.Filters
{
    public class TypeFilterAttribute : Attribute, IFilterFactory, IOrderedFilter
    {
        public TypeFilterAttribute(Type type)
        {
            ImplementaionType = type ?? throw new ArgumentNullException(nameof(Type));
        }
        public Type ImplementaionType { get; }
        public int Order { get;}

        public bool IsReusable { get; }

        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
            throw new NotImplementedException();
        }
    }
}
