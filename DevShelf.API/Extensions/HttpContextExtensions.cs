using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace DevShelf.API.Extensions
{
    public static class HttpContextExtensions
    {
        public static string UserEmail(this IIdentity identityBase)
        {
            var identity = identityBase as ClaimsIdentity;
            if(identity != null)
            {
                return identity.FindFirst("username").Value;
            }

            return null;
        }
    }
}
